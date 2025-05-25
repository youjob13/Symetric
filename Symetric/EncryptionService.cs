using System;
using System.IO;
using System.Security.Cryptography;

namespace Symetric
{
    public static class EncryptionService
    {
        public static byte[] Encrypt(SymmetricAlgorithm algorithm, byte[] data)
        {
            var msEncrypt = new MemoryStream();
            var csEncrypt = new CryptoStream(msEncrypt, algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            csEncrypt.Write(data, 0, data.Length);
            csEncrypt.FlushFinalBlock();
            return msEncrypt.ToArray();
        }

        public static byte[] Decrypt(SymmetricAlgorithm algorithm, byte[] encryptedData)
        {
            var msDecrypt = new MemoryStream(encryptedData);
            var csDecrypt = new CryptoStream(msDecrypt, algorithm.CreateDecryptor(), CryptoStreamMode.Read);
            byte[] decrypted = new byte[encryptedData.Length];
            int bytesRead = csDecrypt.Read(decrypted, 0, decrypted.Length);
            Array.Resize(ref decrypted, bytesRead);
            return decrypted;
        }
    }
}