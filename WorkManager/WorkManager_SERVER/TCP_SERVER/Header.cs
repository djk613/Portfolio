using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public class Header : ISerializable
    {
        public uint MSGID { get; set; }
        public ushort MSGTYPE { get; set; }
        public uint BODYLEN { get; set; }
        public byte FRAGMENTED { get; set; }
        public byte LASTMSG { get; set; }
        public uint SEQ { get; set; }


        public Header() { }
        public Header(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes, 0);
            MSGTYPE = BitConverter.ToUInt16(bytes, 4);
            BODYLEN = BitConverter.ToUInt32(bytes, 6);
            FRAGMENTED = bytes[10];
            LASTMSG = bytes[11];
            SEQ = BitConverter.ToUInt32(bytes, 12);
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[CONSTANTS.SIZE_HEADER];

            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);

            temp = BitConverter.GetBytes(MSGTYPE);
            Array.Copy(temp, 0, bytes, 4, temp.Length);

            temp = BitConverter.GetBytes(BODYLEN);
            Array.Copy(temp, 0, bytes, 6, temp.Length);

            bytes[10] = FRAGMENTED;
            bytes[11] = LASTMSG;

            temp = BitConverter.GetBytes(SEQ);
            Array.Copy(temp, 0, bytes, 12, temp.Length);

            return bytes;
        }

        public int GetSize()
        {
            return CONSTANTS.SIZE_HEADER;
        }

    }
}
