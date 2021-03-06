using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace MyERP
{
    public class Cryptography
    {
        /// <summary>
        /// Generate the key used to perform the encryption/decryption for the AES algorithm
        /// </summary>
        /// <param name="hashKey">Generate the keys or username+password </param>
        /// <returns></returns>
        public static byte[] GetHashKey(string hashKey)
        {
            // Initialise
            UTF8Encoding encoder = new UTF8Encoding();

            // Get the salt
            string salt = "I am a nice little salt";
            byte[] saltBytes = encoder.GetBytes(salt);

            // Setup the hasher
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);

            // Return the key
            return rfc.GetBytes(16);
        }

        public static byte[] GetHashKey(string hashKey, string salt)
        {
            // Initialise
            UTF8Encoding encoder = new UTF8Encoding();

            // Get the salt
            byte[] saltBytes = encoder.GetBytes(salt);

            // Setup the hasher
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);

            // Return the key
            return rfc.GetBytes(16);
        }

        public static string Encrypt(byte[] key, string dataToEncrypt)
        {
            // Initialise
            AesManaged encryptor = new AesManaged {Key = key, IV = key};

            // Set the key

            // create a memory stream
            using (MemoryStream encryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(dataToEncrypt);
                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.FlushFinalBlock();
                    encrypt.Close();

                    // Return the encrypted data
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }

        public static string Decrypt(byte[] key, string encryptedString)
        {
            // Initialise
            AesManaged decryptor = new AesManaged {Key = key, IV = key};

            // Set the key

            byte[] encryptedData = Convert.FromBase64String(encryptedString);

            // create a memory stream
            using (MemoryStream decryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream decrypt = new CryptoStream(decryptionStream, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    decrypt.Write(encryptedData, 0, encryptedData.Length);
                    decrypt.Flush();
                    decrypt.Close();

                    // Return the unencrypted data
                    byte[] decryptedData = decryptionStream.ToArray();
                    return UTF8Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
                }
            }
        }
    }
}