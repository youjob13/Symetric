using System;
using System.Security.Cryptography;

namespace Symetric
{
    public class EncryptionResult
    {
        public string Algorithm { get; set; }
        public CipherMode Mode { get; set; }
        public TimeSpan EncryptionTime { get; set; }
        public TimeSpan DecryptionTime { get; set; }
    }
}