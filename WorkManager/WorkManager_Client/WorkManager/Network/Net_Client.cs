using Protocol;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP_SOCKET_NETWORK
{
    class Net_Client
    {
        private string m_strServer_IP;
        private int  m_nServer_port;
        private string m_strFile_path;
        private IPEndPoint m_client_address;
        private IPEndPoint m_server_address;
        private NetworkStream m_net_stream;
        private static uint m_nMsgId;
        static private string m_str_dir = "C:\\download";

        public Net_Client(string _serverIP, int _serverPort = 10387)
        {
            m_strServer_IP = _serverIP;
            m_nServer_port = _serverPort;
            m_client_address = new IPEndPoint(0, 0);
            m_server_address = new IPEndPoint(IPAddress.Parse(m_strServer_IP), m_nServer_port);
            m_nMsgId = 0;
        }

        public void Run(Protocol.CLIENT_REQ req, string _filePath)
        {
            m_strFile_path = new string(_filePath);

            try
            {
                /*connect to server*/
                TcpClient client = new TcpClient(m_client_address);
                client.Connect(m_server_address);

                m_net_stream = client.GetStream();

                if (req == Protocol.CLIENT_REQ.SEND_FILE)
                {
                    RequestFileSend();

                    if (CheckServerResponse_send(m_net_stream) == false)
                    {
                        return;
                    }

                    SendFile();

                }
                else if (req == Protocol.CLIENT_REQ.RECEIVE_FILE)
                {
                    RequestFileReceive();

                    if (CheckServerResponse_receive(m_net_stream) == false)
                    {
                        return;
                    }

                    ReceiveFile();
                }

                m_net_stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        private void RequestFileSend()
        {
            Message reqMsg = new Message();
            reqMsg.Body = new BodyRequest()
            {
                m_nFile_size = (ulong)new FileInfo(m_strFile_path).Length,
                m_file_name = Encoding.Default.GetBytes(Path.GetFileName(m_strFile_path))
            };
            reqMsg.Header = new Header()
            {
                MSGID = m_nMsgId++,
                MSGTYPE = CONSTANTS.REQ_FILE_SEND,
                BODYLEN = (uint)reqMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            // 클라이언트는 서버에 접속하자마자 파일 전송 요청 메시지를 보냄
            MessageUtil.Send(m_net_stream, reqMsg);
        }

        private bool CheckServerResponse_send(NetworkStream netStream)
        {
            Message rspMsg = MessageUtil.Receive(netStream);

            if (rspMsg.Header.MSGTYPE != CONSTANTS.REP_FILE_SEND)
            {
                return false;
            }

            if (((BodyResponse)rspMsg.Body).m_reponse == CONSTANTS.DENIED)
            {
                return false;
            }

            return true;
        }

        private void SendFile()
        {
            using (Stream fileStream = new FileStream(m_strFile_path, FileMode.Open))
            {
                byte[] rbytes = new byte[Protocol.CONSTANTS.SIZE_CHUNK];

                int n_tota_read = 0;
                ushort n_msg_seq = 0;
                byte fragmented = (fileStream.Length < Protocol.CONSTANTS.SIZE_CHUNK) ? CONSTANTS.NOT_FRAGMENTED : CONSTANTS.FRAGMENTED;
               
                while (n_tota_read < fileStream.Length)
                {
                    int n_read = fileStream.Read(rbytes, 0, Protocol.CONSTANTS.SIZE_CHUNK);
                    n_tota_read += n_read;
                    Message fileMsg = new Message();

                    byte[] sendBytes = new byte[n_read];
                    Array.Copy(rbytes, 0, sendBytes, 0, n_read);

                    fileMsg.Body = new BodyData(sendBytes);
                    fileMsg.Header = new Header()
                    {
                        MSGID = m_nMsgId,
                        MSGTYPE = CONSTANTS.FILE_SEND_DATA,
                        BODYLEN = (uint)fileMsg.Body.GetSize(),
                        FRAGMENTED = fragmented,
                        LASTMSG = (n_tota_read < fileStream.Length) ? CONSTANTS.NOT_LASTMSG : CONSTANTS.LASTMSG,
                        SEQ = n_msg_seq++
                    };

                    // 모든 파일의 내용이 전송될 때까지 파일 스트림을 0x03 메시지에 담아 서버로 보냄
                    MessageUtil.Send(m_net_stream, fileMsg);
                }

                // 서버에서 파일을 제대로 받았는지에 대한 응답을 받음
                Message rstMsg = MessageUtil.Receive(m_net_stream);

                BodyResult result = rstMsg.Body as BodyResult;
            }
        }

        private void RequestFileReceive()
        {
            Message reqMsg = new Message();
            reqMsg.Body = new BodyRequest()
            {
                /*not know the size of the file, yet file path is needed*/
                m_nFile_size = 1,
                m_file_name = Encoding.Default.GetBytes(m_strFile_path)
            };

            reqMsg.Header = new Header()
            {
                MSGID = m_nMsgId++,
                MSGTYPE = CONSTANTS.REQ_FILE_RECEIVE,
                BODYLEN = (uint)reqMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            /*the first step of TCP, client send massage to server for request*/
            MessageUtil.Send(m_net_stream, reqMsg);
        }

        private bool CheckServerResponse_receive(NetworkStream netStream)
        {
            Message rspMsg = MessageUtil.Receive(netStream);

            if (rspMsg.Header.MSGTYPE != CONSTANTS.REP_FILE_RECEIVE)
            {
                return false;
            }

            if (((BodyResponse)rspMsg.Body).m_reponse == CONSTANTS.DENIED)
            {
                return false;
            }

            return true;
        }

        private void ReceiveFile()
        {
            Message reqMsg = MessageUtil.Receive(m_net_stream);

            BodyRequest reqBody = reqMsg.Body as BodyRequest;

            ulong n_file_size = reqBody.m_nFile_size;
            string str_file_name = Encoding.Default.GetString(reqBody.m_file_name);
            str_file_name = str_file_name.Replace("\0", string.Empty);
            str_file_name = Path.GetFileName(str_file_name);

            // 파일 스트림 생성
            FileStream file = new FileStream(m_str_dir + "\\" + str_file_name, FileMode.Create);

            /*준비끝 메세지 서버로 출력... 이건 TCP를 위해서 추가함*/
            Message readyMsg = new Message();
            readyMsg.Body = new BodyResponse()
            {
                m_nMsgid = reqMsg.Header.MSGID,
                m_reponse = CONSTANTS.ACCEPTED
            };

            readyMsg.Header = new Header()
            {
                MSGID = m_nMsgId++,
                MSGTYPE = CONSTANTS.REP_FILE_RECEIVE,
                BODYLEN = (uint)readyMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(m_net_stream, readyMsg);

            uint? n_data_msgId = null;
            ushort n_prev_seq = 0;
            while ((reqMsg = MessageUtil.Receive(m_net_stream)) != null)
            {
                if (reqMsg.Header.MSGTYPE != CONSTANTS.FILE_RECEIVE_DATA)
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
                MSGID = m_nMsgId++,
                MSGTYPE = CONSTANTS.FILE_SEND_RES,
                BODYLEN = (uint)rstMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            if (n_file_size == n_recv_file_size)
            {
                // 파일 전송 요청에 담겨온 파일 크기와 실제로 받은 파일 크기를 비교
                // 같으면 성공 메지시를 보냄
                MessageUtil.Send(m_net_stream, rstMsg);
            }
            else
            {
                rstMsg.Body = new BodyResult()
                {
                    m_nMsgid = reqMsg.Header.MSGID,
                    m_result = CONSTANTS.FAIL
                };

                // 파일 크기에 이상이 있다면 실패 메시지를 보냄
                MessageUtil.Send(m_net_stream, rstMsg);
            }
        }
    }
}
