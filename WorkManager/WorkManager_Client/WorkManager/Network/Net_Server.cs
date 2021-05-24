using Protocol;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCP_SOCKET_NETWORK
{
    public class Net_Server
    {
        public TcpListener m_server { get; private set; }
        public bool b_server_block { get; set; }
        private NetworkStream m_netStream = null;
        private TcpClient m_client;

        static private uint m_nMsgid = 0;
        static private string m_strDir = "C:\\upload";

        public Net_Server(string ip, int port)
        {
            IPEndPoint localAddress;

            IPAddress ipv4 = IPAddress.Parse(ip);
            localAddress = new IPEndPoint(ipv4, port);

            /*Server Declaration and start to run here*/
            m_server = new TcpListener(localAddress);
            m_server.Start();

            b_server_block = false;
        }

        public void Run()
        {
            if (Directory.Exists(m_strDir) == false)
            {
                Directory.CreateDirectory(m_strDir);
            }

            try
            {
                while (true)
                {
                    /*waiting client sign*/
                    m_client = m_server.AcceptTcpClient();
                    m_netStream = m_client.GetStream();

                    /*receive request message from client*/
                    Message reqMsg = MessageUtil.Receive(m_netStream);

                    if (b_server_block == true)
                    {
                        /*server status - lock*/
                        SendDenialMsg(reqMsg);
                        continue;
                    }
                    else if (reqMsg.Header.MSGTYPE == CONSTANTS.REQ_FILE_SEND)
                    {
                        SendApprovalMsg_send(reqMsg);
                        ReceiveFile(reqMsg);
                    }
                    else if (reqMsg.Header.MSGTYPE == CONSTANTS.REQ_FILE_RECEIVE)
                    {
                        SendApprovalMsg_receive(reqMsg);
                        SendFileInfo(reqMsg);
                        GetReadyMsg();
                        SendFile(reqMsg);
                    }
                    else
                    {
                        m_netStream.Close();
                        m_client.Close();
                        continue;
                    }
                }
            }
            catch (SocketException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            finally
            {
                m_server.Stop();
            }
        }

        private void SendApprovalMsg_send(Message reqMsg)
        {
            Message rspMsg = new Message();

            rspMsg.Body = new BodyResponse()
            {
                m_nMsgid = reqMsg.Header.MSGID,
                m_reponse = CONSTANTS.ACCEPTED
            };

            rspMsg.Header = new Header()
            {
                MSGID = m_nMsgid++,
                MSGTYPE = CONSTANTS.REP_FILE_SEND,
                BODYLEN = (uint)rspMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(m_netStream, rspMsg);
        }

        private void SendApprovalMsg_receive(Message reqMsg)
        {
            Message rspMsg = new Message();

            rspMsg.Body = new BodyResponse()
            {
                m_nMsgid = reqMsg.Header.MSGID,
                m_reponse = CONSTANTS.ACCEPTED
            };

            rspMsg.Header = new Header()
            {
                MSGID = m_nMsgid++,
                MSGTYPE = CONSTANTS.REP_FILE_RECEIVE,
                BODYLEN = (uint)rspMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(m_netStream, rspMsg);
        }

        private void SendFileInfo(Message _reqMsg)
        {
            /*server to client need to send request message,
             * cause client doesn't have detail information*/

            BodyRequest reqBody = _reqMsg.Body as BodyRequest;

            string str_req_file_path = Encoding.Default.GetString(reqBody.m_file_name);
            str_req_file_path = str_req_file_path.Replace("\0", string.Empty);
            string str_req_file = m_strDir + "\\" + str_req_file_path;

            Message reqMsg = new Message();
            reqMsg.Body = new BodyRequest()
            {
                m_nFile_size = (ulong)new FileInfo(str_req_file).Length,
                m_file_name = Encoding.Default.GetBytes(str_req_file)
            };
            reqMsg.Header = new Header()
            {
                MSGID = m_nMsgid++,
                MSGTYPE = CONSTANTS.REQ_FILE_SEND,
                BODYLEN = (uint)reqMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(m_netStream, reqMsg);
        }

        private void ReceiveFile(Message reqMsg)
        {
            BodyRequest reqBody = reqMsg.Body as BodyRequest;

            ulong n_fileSize = reqBody.m_nFile_size;
            string str_file_name = Encoding.Default.GetString(reqBody.m_file_name);
            str_file_name = str_file_name.Replace("\0", string.Empty);

            // 파일 스트림 생성
            FileStream file = new FileStream(m_strDir + "\\" + str_file_name, FileMode.Create);

            uint? n_data_msgId = null;
            ushort n_prev_seq = 0;

            /*wating and receiving file data from client*/
            while ((reqMsg = MessageUtil.Receive(m_netStream)) != null)
            {
                if (reqMsg.Header.MSGTYPE != CONSTANTS.FILE_SEND_DATA)
                    break;

                if (n_data_msgId == null)
                {
                    n_data_msgId = reqMsg.Header.MSGID;
                }
                else
                {
                    if (n_data_msgId != reqMsg.Header.MSGID)
                    {
                        break;
                    }
                        
                }

                // 메시지 순서가 어긋나면 전송 중단
                if (n_prev_seq++ != reqMsg.Header.SEQ)
                {
                    break;
                }

                file.Write(reqMsg.Body.GetBytes(), 0, reqMsg.Body.GetSize());

                // 분할 메시지가 아니면 반복을 한번만하고 빠져나옴
                if (reqMsg.Header.FRAGMENTED == CONSTANTS.NOT_FRAGMENTED)
                {
                    break;
                }
                 
                //마지막 메시지면 반복문을 빠져나옴
                if (reqMsg.Header.LASTMSG == CONSTANTS.LASTMSG)
                {
                    break;
                }
                    
            }

            ulong n_recv_file_size = (ulong)file.Length;
            file.Close();

            Message rstMsg = new Message();
            rstMsg.Body = new BodyResult()
            {
                m_nMsgid = reqMsg.Header.MSGID,
                m_result = CONSTANTS.SUCCESS
            };
            rstMsg.Header = new Header()
            {
                MSGID = m_nMsgid++,
                MSGTYPE = CONSTANTS.FILE_SEND_RES,
                BODYLEN = (uint)rstMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            if (n_fileSize == n_recv_file_size)
            {
                // 파일 전송 요청에 담겨온 파일 크기와 실제로 받은 파일 크기를 비교
                // 같으면 성공 메지시를 보냄
                MessageUtil.Send(m_netStream, rstMsg);
            }
            else
            {
                rstMsg.Body = new BodyResult()
                {
                    m_nMsgid = reqMsg.Header.MSGID,
                    m_result = CONSTANTS.FAIL
                };

                // 파일 크기에 이상이 있다면 실패 메시지를 보냄
                MessageUtil.Send(m_netStream, rstMsg);
            }

            m_netStream.Close();
            m_client.Close();
        }

        private void GetReadyMsg()
        {
            Message readyMsg = MessageUtil.Receive(m_netStream);
        }


        private void SendFile(Message reqMsg)
        {
            BodyRequest reqBody = reqMsg.Body as BodyRequest;
            string str_file_name = Encoding.Default.GetString(reqBody.m_file_name);
            str_file_name = str_file_name.Replace("\0", string.Empty);
            str_file_name = m_strDir + "\\" + Path.GetFileName(str_file_name);

            using (Stream fileStream = new FileStream(str_file_name, FileMode.Open))
            {
                byte[] rbytes = new byte[Protocol.CONSTANTS.SIZE_CHUNK];

                int n_total_read = 0;
                ushort n_msg_seq = 0;
                byte fragmented = (fileStream.Length < Protocol.CONSTANTS.SIZE_CHUNK) ? CONSTANTS.NOT_FRAGMENTED : CONSTANTS.FRAGMENTED;

                while (n_total_read < fileStream.Length)
                {
                    int n_read = fileStream.Read(rbytes, 0, Protocol.CONSTANTS.SIZE_CHUNK);
                    n_total_read += n_read;
                    Message fileMsg = new Message();

                    byte[] sendBytes = new byte[n_read];
                    Array.Copy(rbytes, 0, sendBytes, 0, n_read);

                    fileMsg.Body = new BodyData(sendBytes);
                    fileMsg.Header = new Header()
                    {
                        MSGID = m_nMsgid,
                        MSGTYPE = CONSTANTS.FILE_RECEIVE_DATA,
                        BODYLEN = (uint)fileMsg.Body.GetSize(),
                        FRAGMENTED = fragmented,
                        LASTMSG = (n_total_read < fileStream.Length) ? CONSTANTS.NOT_LASTMSG : CONSTANTS.LASTMSG,
                        SEQ = n_msg_seq++
                    };

                    // 모든 파일의 내용이 전송될 때까지 파일 스트림을 0x03 메시지에 담아 서버로 보냄
                    MessageUtil.Send(m_netStream, fileMsg);
                }

                // 서버에서 파일을 제대로 받았는지에 대한 응답을 받음
                Message rstMsg = MessageUtil.Receive(m_netStream);

                BodyResult result = rstMsg.Body as BodyResult;
            }
        }

        private void SendDenialMsg(Message reqMsg)
        {
            Message rspMsg = new Message();

            rspMsg.Body = new BodyResponse()
            {
                m_nMsgid = reqMsg.Header.MSGID,
                m_reponse = CONSTANTS.DENIED
            };

            rspMsg.Header = new Header()
            {
                MSGID = m_nMsgid++,
                MSGTYPE = CONSTANTS.REP_FILE_SEND,
                BODYLEN = (uint)rspMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(m_netStream, rspMsg);

            m_netStream.Close();
            m_client.Close();
        }

    }
}
