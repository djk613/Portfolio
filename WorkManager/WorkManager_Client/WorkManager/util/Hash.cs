using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace WorkManager
{
    class HashForPassword
    {
        public static string SHA256Hash(string str)
        {
            SHA256 sha256 = new SHA256Managed();
            byte[] hash = sha256.ComputeHash(Encoding.ASCII.GetBytes(str));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }
    }
}
