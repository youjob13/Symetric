using System;

namespace Symetric
{
    public class EncryptionResult
    {
        public string Algorithm { get; set; }
        public string Mode { get; set; }
        public TimeSpan EncryptionTime { get; set; }
        public TimeSpan DecryptionTime { get; set; }
    }
}