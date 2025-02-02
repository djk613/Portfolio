﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Protocol
{
    public class MessageUtil
    {
        public static void Send(Stream writer, Message Msg)
        {
            writer.Write(Msg.GetBytes(), 0, Msg.GetSize());
        }

        public static Message Receive(Stream reader)
        {
            int totalRecv = 0;
            int sizeToRead = 16;
            byte[] hBuffer = new byte[sizeToRead];

            while (sizeToRead > 0)
            {
                byte[] buffer = new byte[sizeToRead];
                int recv = reader.Read(buffer, 0, sizeToRead);

                if (recv == 0)
                {
                    return null;
                }

                buffer.CopyTo(hBuffer, totalRecv);
                totalRecv += recv;
                sizeToRead -= recv;
            }

            Header header = new Header(hBuffer);

            totalRecv = 0;
            byte[] bBuffer = new byte[header.BODYLEN];
            sizeToRead = (int)header.BODYLEN;

            while (sizeToRead > 0)
            {
                byte[] buffer = new byte[sizeToRead];
                int recv = reader.Read(buffer, 0, sizeToRead);

                if (recv == 0)
                {
                    return null;
                }

                buffer.CopyTo(bBuffer, totalRecv);
                totalRecv += recv;
                sizeToRead -= recv;
            }

            ISerializable body = null;

            switch (header.MSGTYPE)
            {
                case CONSTANTS.REQ_FILE_SEND:
                case CONSTANTS.REQ_FILE_RECEIVE:
                    body = new BodyRequest(bBuffer);
                    break;
                case CONSTANTS.REP_FILE_SEND:
                case CONSTANTS.REP_FILE_RECEIVE:
                    body = new BodyResponse(bBuffer);
                    break;
                case CONSTANTS.FILE_SEND_DATA:
                case CONSTANTS.FILE_RECEIVE_DATA:
                    body = new BodyData(bBuffer);
                    break;
                case CONSTANTS.FILE_SEND_RES:
                case CONSTANTS.FILE_RECEIVE_RES:
                    body = new BodyResult(bBuffer);
                    break;
                default:
                    throw new Exception(string.Format("Unknown MSGTYPE: {0}", header.MSGTYPE));
            }

            return new Message() { Header = header, Body = body };
        }
    }
}
