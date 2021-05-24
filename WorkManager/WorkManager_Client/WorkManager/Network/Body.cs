using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public class BodyRequest : ISerializable
    {
        public ulong m_nFile_size;
        public byte[] m_file_name;

        public BodyRequest() { }
        public BodyRequest(byte[] bytes)
        {
            m_nFile_size = BitConverter.ToUInt64(bytes, 0);
            m_file_name = new byte[bytes.Length - sizeof(long)];
            Array.Copy(bytes, sizeof(long), m_file_name, 0, m_file_name.Length);
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(m_nFile_size);

            Array.Copy(temp, 0, bytes, 0, temp.Length);
            Array.Copy(m_file_name, 0, bytes, temp.Length, m_file_name.Length);

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(long) * m_file_name.Length;
        }
    }

    public class BodyResponse : ISerializable
    {
        public uint m_nMsgid;
        public byte m_reponse;

        public BodyResponse() { }
        public BodyResponse(byte[] bytes)
        {
            m_nMsgid = BitConverter.ToUInt32(bytes, 0);
            m_reponse = bytes[4];
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(m_nMsgid);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            bytes[temp.Length] = m_reponse;

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(uint) + sizeof(byte);
        }
    }

    public class BodyData : ISerializable
    {
        public byte[] m_data;

        public BodyData(byte[] bytes)
        {
            m_data = new byte[bytes.Length];
            bytes.CopyTo(m_data, 0);
        }

        public byte[] GetBytes()
        {
            return m_data;
        }

        public int GetSize()
        {
            return m_data.Length;
        }
    }

    public class BodyResult : ISerializable
    {
        public uint m_nMsgid;
        public byte m_result;

        public BodyResult() { }
        public BodyResult(byte[] bytes)
        {
            m_nMsgid = BitConverter.ToUInt32(bytes, 0);
            m_result = bytes[4];
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(m_nMsgid);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            bytes[temp.Length] = m_result;

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(uint) + sizeof(byte);
        }

    }


}
