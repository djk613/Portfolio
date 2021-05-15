using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUP
{
    public class CONSTANTS
    {
        public const ushort REQ_FILE_SEND = 0x01;
        public const ushort REP_FILE_SEND = 0x02;
        public const ushort FILE_SEND_DATA = 0x03;
        public const ushort FILE_SEND_RES = 0x04;

        public const ushort REQ_FILE_RECEIVE = 0x05;
        public const ushort REP_FILE_RECEIVE = 0x06;
        public const ushort FILE_RECEIVE_DATA = 0x07;
        public const ushort FILE_RECEIVE_RES = 0x08;

        public const byte NOT_FRAGMENTED = 0x00;
        public const byte FRAGMENTED = 0x01;

        public const byte NOT_LASTMSG = 0x00;
        public const byte LASTMSG = 0x01;

        public const byte ACCEPTED = 0x00;
        public const byte DENIED = 0x01;

        public const byte FAIL = 0x00;
        public const byte SUCCESS = 0x01;

        public const byte SIZE_HEADER = 0x10;

        public const ushort SIZE_CHUNK = 0x1000;
    }

    public enum CLIENT_REQ
    {
        SEND_FILE = 0x01,
        RECEIVE_FILE = 0x02
    }

    public interface ISerializable
    {
        byte[] GetBytes();
        int GetSize();
    }

    public class Message : ISerializable
    {
        public Header Header { get; set; }
        public ISerializable Body { get; set; }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];

            Header.GetBytes().CopyTo(bytes, 0);
            Body.GetBytes().CopyTo(bytes, Header.GetSize());

            return bytes;
        }

        public int GetSize()
        {
            return Header.GetSize() + Body.GetSize();
        }
    }

}
