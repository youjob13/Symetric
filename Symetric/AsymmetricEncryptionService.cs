using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Asymmetric
{
    public static class AsymmetricEncryptionService
    {
        public static (string PrivateKeyXml, string PublicKeyXml) GenerateKeys()
        {
            var rsa = new RSACryptoServiceProvider(2048);
            return (rsa.ToXmlString(true), rsa.ToXmlString(false));
        }

        public static void ExportKey(string keyXml, string filePath)
        {
            File.WriteAllText(filePath, keyXml);
        }

        public static string ImportKey(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public static byte[] Encrypt(byte[] data, string publicKeyXml)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKeyXml);
            return rsa.Encrypt(data, false);
        }

        public static byte[] Decrypt(byte[] encryptedData, string privateKeyXml)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKeyXml);
            return rsa.Decrypt(encryptedData, false);
        }
    }
}
