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
        private string serverIP;
        private int serverPort;
        private string filePath;
        private IPEndPoint clientAddress;
        private IPEndPoint serverAddress;
        private NetworkStream netStream;
        private static uint msgId;
        static private string dir = "C:\\download";

        public Net_Client(string _serverIP, int _serverPort = 8001)
        {
            serverIP = _serverIP;
            serverPort = _serverPort;
            clientAddress = new IPEndPoint(0, 0);
            serverAddress = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
            msgId = 0;
        }

        public void Run(Protocol.CLIENT_REQ req, string _filePath)
        {
            filePath = new string(_filePath);

            try
            {
                /*connect to server*/
                TcpClient client = new TcpClient(clientAddress);
                client.Connect(serverAddress);

                netStream = client.GetStream();

                if (req == Protocol.CLIENT_REQ.SEND_FILE)
                {
                    RequestFileSend();

                    if (CheckServerResponse_send(netStream) == false)
                    {
                        return;
                    }

                    SendFile();

                }
                else if (req == Protocol.CLIENT_REQ.RECEIVE_FILE)
                {
                    RequestFileReceive();

                    if (CheckServerResponse_receive(netStream) == false)
                    {
                        return;
                    }

                    ReceiveFile();
                }

                netStream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
        }

        private void RequestFileSend()
        {
            Message reqMsg = new Message();
            reqMsg.Body = new BodyRequest()
            {
                FILESIZE = (ulong)new FileInfo(filePath).Length,
                FILENAME = Encoding.Default.GetBytes(Path.GetFileName(filePath))
            };
            reqMsg.Header = new Header()
            {
                MSGID = msgId++,
                MSGTYPE = CONSTANTS.REQ_FILE_SEND,
                BODYLEN = (uint)reqMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            // 클라이언트는 서버에 접속하자마자 파일 전송 요청 메시지를 보냄
            MessageUtil.Send(netStream, reqMsg);
        }

        private bool CheckServerResponse_send(NetworkStream netStream)
        {
            Message rspMsg = MessageUtil.Receive(netStream);

            if (rspMsg.Header.MSGTYPE != CONSTANTS.REP_FILE_SEND)
            {
                Console.WriteLine("정상적인 서버 응답이 아닙니다.{0}", rspMsg.Header.MSGTYPE);
                return false;
            }

            if (((BodyResponse)rspMsg.Body).RESPONSE == CONSTANTS.DENIED)
            {
                Console.WriteLine("서버에서 파일 전송을 거부했습니다.");
                return false;
            }

            return true;
        }

        private void SendFile()
        {
            using (Stream fileStream = new FileStream(filePath, FileMode.Open))
            {
                byte[] rbytes = new byte[Protocol.CONSTANTS.SIZE_CHUNK];

                long readValue = BitConverter.ToInt64(rbytes, 0);

                int totalRead = 0;
                ushort msgSeq = 0;
                byte fragmented = (fileStream.Length < Protocol.CONSTANTS.SIZE_CHUNK) ? CONSTANTS.NOT_FRAGMENTED : CONSTANTS.FRAGMENTED;
               
                while (totalRead < fileStream.Length)
                {
                    int read = fileStream.Read(rbytes, 0, Protocol.CONSTANTS.SIZE_CHUNK);
                    totalRead += read;
                    Message fileMsg = new Message();

                    byte[] sendBytes = new byte[read];
                    Array.Copy(rbytes, 0, sendBytes, 0, read);

                    fileMsg.Body = new BodyData(sendBytes);
                    fileMsg.Header = new Header()
                    {
                        MSGID = msgId,
                        MSGTYPE = CONSTANTS.FILE_SEND_DATA,
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

        private void RequestFileReceive()
        {
            Message reqMsg = new Message();
            reqMsg.Body = new BodyRequest()
            {
                /*not know the size of the file, yet file path is needed*/
                FILESIZE = 1,
                FILENAME = Encoding.Default.GetBytes(filePath)
            };

            reqMsg.Header = new Header()
            {
                MSGID = msgId++,
                MSGTYPE = CONSTANTS.REQ_FILE_RECEIVE,
                BODYLEN = (uint)reqMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            /*the first step of TCP, client send massage to server for request*/
            MessageUtil.Send(netStream, reqMsg);
        }

        private bool CheckServerResponse_receive(NetworkStream netStream)
        {
            Message rspMsg = MessageUtil.Receive(netStream);

            if (rspMsg.Header.MSGTYPE != CONSTANTS.REP_FILE_RECEIVE)
            {
                Console.WriteLine("정상적인 서버 응답이 아닙니다.{0}", rspMsg.Header.MSGTYPE);
                return false;
            }

            if (((BodyResponse)rspMsg.Body).RESPONSE == CONSTANTS.DENIED)
            {
                Console.WriteLine("서버에서 파일 전송을 거부했습니다.");
                return false;
            }

            return true;
        }

        private void ReceiveFile()
        {
            Message reqMsg = MessageUtil.Receive(netStream);

            BodyRequest reqBody = reqMsg.Body as BodyRequest;

            ulong fileSize = reqBody.FILESIZE;
            string fileName = Encoding.Default.GetString(reqBody.FILENAME);
            fileName = fileName.Replace("\0", string.Empty);
            fileName = Path.GetFileName(fileName);

            // 파일 스트림 생성
            FileStream file = new FileStream(dir + "\\" + fileName, FileMode.Create);

            /*준비끝 메세지 서버로 출력... 이건 TCP를 위해서 추가함*/
            Message readyMsg = new Message();
            readyMsg.Body = new BodyResponse()
            {
                MSGID = reqMsg.Header.MSGID,
                RESPONSE = CONSTANTS.ACCEPTED
            };

            readyMsg.Header = new Header()
            {
                MSGID = msgId++,
                MSGTYPE = CONSTANTS.REP_FILE_RECEIVE,
                BODYLEN = (uint)readyMsg.Body.GetSize(),
                FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                LASTMSG = CONSTANTS.LASTMSG,
                SEQ = 0
            };

            MessageUtil.Send(netStream, readyMsg);

            uint? dataMsgId = null;
            ushort prevSeq = 0;
            while ((reqMsg = MessageUtil.Receive(netStream)) != null)
            {
                if (reqMsg.Header.MSGTYPE != CONSTANTS.FILE_RECEIVE_DATA)
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
                MSGID = msgId++,
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
        }
    }
}
