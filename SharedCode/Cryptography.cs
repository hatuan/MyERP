using System;
using System.IO;
//using System.Collections;
//using System.Collections.Generic;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text;


namespace MyERP.Global
{
    public class Cryptography
    {
        private static readonly string strDefaultKey = "65EA7902-C2A0-436E-8345-22260DC104C0";

        [DebuggerStepThrough()]
        private static byte[] GetKey(string strkey)
        {
            byte[] key = Encoding.UTF8.GetBytes(strkey);
            return key;
        }

        #region Encrypt

        [DebuggerStepThrough()]
        public static string Encrypt(string str, string strkey)
        {
            byte[] keyBytes = strkey == null ? GetKey(strDefaultKey) : GetKey(strkey);
            System.Security.Cryptography.HMACSHA256 sha1 = new System.Security.Cryptography.HMACSHA256(keyBytes);

            byte[] hashBytes = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));

            string hash = Convert.ToBase64String(hashBytes);

            return hash;
        }

        #endregion

        #region Decrypt

        [DebuggerStepThrough()]
        public static string Decrypt(string str, string strkey)
        {
            byte[] cryptoBytes = Convert.FromBase64String(str);
            return Decrypt(cryptoBytes, strkey);
        }

        [DebuggerStepThrough()]
        public static string Decrypt(byte[] str, string strkey)
        {

            byte[] keyBytes = strkey == null ? GetKey(strDefaultKey) : GetKey(strkey);
            System.Security.Cryptography.HMACSHA256 sha1 = new System.Security.Cryptography.HMACSHA256(keyBytes);

            byte[] plainBytes = sha1.ComputeHash(str);

            UTF8Encoding ae = new UTF8Encoding();
            return ae.GetString(plainBytes, 0, str.Length).Replace("\0", "");
        }

        #endregion
    }
}