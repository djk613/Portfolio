using FUP;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSender
{
    class Server
    {
        public TcpListener server { get; private set; }
        public bool b_server_block { get; set; }
        private NetworkStream netStream = null;
        private TcpClient client;
        private const int bindPort = 5425;/*확정아님*/

        static private uint msgid = 0;
        static private string dir = "C:\\Upload";

        Server()
        {
            IPEndPoint localAddress = new IPEndPoint(0, bindPort);

            /*Server Declaration and start to run here*/
            server = new TcpListener(localAddress);
            server.Start();

            b_server_block = false;

        }

        public void Run()
        {
            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }

            try
            {
                while (true)
                {
                    /*waiting client sign*/
                    client = server.AcceptTcpClient();
                    netStream = client.GetStream();

                    /*receive request message from client*/
                    Message reqMsg = MessageUtil.Receive(netStream);

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
                        SendFile(reqMsg);
                    }
                    else
                    {
                        netStream.Close();
                        client.Close();
                        continue;
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                server.Stop();
            }
        }

        private void SendApprovalMsg_send(Message reqMsg)
        {
            Message rspMsg = new Message();

            rspMsg.Body = new BodyResponse()
            {
                MSGID = reqMsg.Header.MSGID,
                RESPONSE = CONSTANTS.ACCEPTED
            };

            rspMsg.Header = new Header()
            {
                MSGID = msgid++,
                MSGTYPE = CONSTANTS.REP_FILE_SEND,
                BODYLEN = (uint)rspMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(netStream, rspMsg);
        }

        private void SendApprovalMsg_receive(Message reqMsg)
        {
            Message rspMsg = new Message();

            rspMsg.Body = new BodyResponse()
            {
                MSGID = reqMsg.Header.MSGID,
                RESPONSE = CONSTANTS.ACCEPTED
            };

            rspMsg.Header = new Header()
            {
                MSGID = msgid++,
                MSGTYPE = CONSTANTS.REP_FILE_RECEIVE,
                BODYLEN = (uint)rspMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(netStream, rspMsg);
        }

        private void SendFileInfo(Message _reqMsg)
        {
            /*server to client need to send request message,
             * cause client doesn't have detail information*/

            BodyRequest reqBody = _reqMsg.Body as BodyRequest;

            Message reqMsg = new Message();
            reqMsg.Body = new BodyRequest()
            {
                FILESIZE = (ulong)new FileInfo(reqBody.FILENAME.ToString()).Length,
                FILENAME = Encoding.Default.GetBytes(reqBody.FILENAME.ToString())
            };
            reqMsg.Header = new Header()
            {
                MSGID = msgid++,
                MSGTYPE = CONSTANTS.REQ_FILE_SEND,
                BODYLEN = (uint)reqMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(netStream, reqMsg);
        }

        private void ReceiveFile(Message reqMsg)
        {
            BodyRequest reqBody = reqMsg.Body as BodyRequest;

            ulong fileSize = reqBody.FILESIZE;
            string fileName = Encoding.Default.GetString(reqBody.FILENAME);

            // 파일 스트림 생성
            FileStream file = new FileStream(dir + "\\" + fileName, FileMode.Create);

            uint? dataMsgId = null;
            ushort prevSeq = 0;

            /*wating and receiving file data from client*/
            while ((reqMsg = MessageUtil.Receive(netStream)) != null)
            {
                if (reqMsg.Header.MSGTYPE != CONSTANTS.FILE_SEND_DATA)
                    break;

                if (dataMsgId == null)
                {
                    dataMsgId = reqMsg.Header.MSGID;
                }
                else
                {
                    if (dataMsgId != reqMsg.Header.MSGID)
                    {
                        break;
                    }
                        
                }

                // 메시지 순서가 어긋나면 전송 중단
                if (prevSeq++ != reqMsg.Header.SEQ)
                {
                    Console.WriteLine("{0}, {1}", prevSeq, reqMsg.Header.SEQ);
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

            ulong recvFileSize = (ulong)file.Length;
            file.Close();

            Console.WriteLine();
            Console.WriteLine("수신 파일 크기 : {0} bytes", recvFileSize);

            Message rstMsg = new Message();
            rstMsg.Body = new BodyResult()
            {
                MSGID = reqMsg.Header.MSGID,
                RESULT = CONSTANTS.SUCCESS
            };
            rstMsg.Header = new Header()
            {
                MSGID = msgid++,
                MSGTYPE = CONSTANTS.FILE_SEND_RES,
                BODYLEN = (uint)rstMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            if (fileSize == recvFileSize)
            {
                // 파일 전송 요청에 담겨온 파일 크기와 실제로 받은 파일 크기를 비교
                // 같으면 성공 메지시를 보냄
                MessageUtil.Send(netStream, rstMsg);
            }
            else
            {
                rstMsg.Body = new BodyResult()
                {
                    MSGID = reqMsg.Header.MSGID,
                    RESULT = CONSTANTS.FAIL
                };

                // 파일 크기에 이상이 있다면 실패 메시지를 보냄
                MessageUtil.Send(netStream, rstMsg);
            }
            Console.WriteLine("파일 전송을 마쳤습니다.");

            netStream.Close();
            client.Close();
        }

        private void SendFile(Message reqMsg)
        {
            BodyRequest reqBody = reqMsg.Body as BodyRequest;

            using (Stream fileStream = new FileStream(reqBody.FILENAME.ToString(), FileMode.Open))
            {
                byte[] rbytes = new byte[FUP.CONSTANTS.SIZE_CHUNK];

                long readValue = BitConverter.ToInt64(rbytes, 0);

                int totalRead = 0;
                ushort msgSeq = 0;
                byte fragmented = (fileStream.Length < FUP.CONSTANTS.SIZE_CHUNK) ? CONSTANTS.NOT_FRAGMENTED : CONSTANTS.FRAGMENTED;

                while (totalRead < fileStream.Length)
                {
                    int read = fileStream.Read(rbytes, 0, FUP.CONSTANTS.SIZE_CHUNK);
                    totalRead += read;
                    Message fileMsg = new Message();

                    byte[] sendBytes = new byte[read];
                    Array.Copy(rbytes, 0, sendBytes, 0, read);

                    fileMsg.Body = new BodyData(sendBytes);
                    fileMsg.Header = new Header()
                    {
                        MSGID = msgid,
                        MSGTYPE = CONSTANTS.FILE_RECEIVE_DATA,
                        BODYLEN = (uint)fileMsg.Body.GetSize(),
                        FRAGMENTED = fragmented,
                        LASTMSG = (totalRead < fileStream.Length) ? CONSTANTS.NOT_LASTMSG : CONSTANTS.LASTMSG,
                        SEQ = msgSeq++
                    };

                    // 모든 파일의 내용이 전송될 때까지 파일 스트림을 0x03 메시지에 담아 서버로 보냄
                    MessageUtil.Send(netStream, fileMsg);
                }

                // 서버에서 파일을 제대로 받았는지에 대한 응답을 받음
                Message rstMsg = MessageUtil.Receive(netStream);

                BodyResult result = rstMsg.Body as BodyResult;
            }
        }

        private void SendDenialMsg(Message reqMsg)
        {
            Message rspMsg = new Message();

            rspMsg.Body = new BodyResponse()
            {
                MSGID = reqMsg.Header.MSGID,
                RESPONSE = CONSTANTS.DENIED
            };

            rspMsg.Header = new Header()
            {
                MSGID = msgid++,
                MSGTYPE = CONSTANTS.REP_FILE_SEND,
                BODYLEN = (uint)rspMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(netStream, rspMsg);

            netStream.Close();
            client.Close();
        }

    }
}
