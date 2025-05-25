using Symetric;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Symetric
{
    public static class PerformanceTester
    {
        public static List<EncryptionResult> TestAlgorithms(byte[] data)
        {
            var results = new List<EncryptionResult>();
            var algorithms = new (string Name, Func<SymmetricAlgorithm> Create, string[] Modes)[]
            {
                ("DES", DES.Create, new[] { "ECB", "CBC" }),
                ("TripleDES", TripleDES.Create, new[] { "ECB", "CBC" }),
                ("RC2", RC2.Create, new[] { "ECB", "CBC" }),
                ("Rijndael", Rijndael.Create, new[] { "ECB", "CBC" })
            };

            foreach (var (name, factory, modes) in algorithms)
            {
                foreach (var modeStr in modes)
                {
                    var algorithm = factory();
                    algorithm.Mode = (CipherMode)Enum.Parse(typeof(CipherMode), modeStr);
                    algorithm.Padding = PaddingMode.PKCS7;
                    algorithm.GenerateKey();
                    algorithm.GenerateIV();

                    var stopwatch = Stopwatch.StartNew();
                    var encrypted = EncryptionService.Encrypt(algorithm, data);
                    stopwatch.Stop();
                    var encryptionTime = stopwatch.Elapsed;

                    stopwatch.Restart();
                    var decrypted = EncryptionService.Decrypt(algorithm, encrypted);
                    stopwatch.Stop();
                    var decryptionTime = stopwatch.Elapsed;

                    results.Add(new EncryptionResult
                    {
                        Algorithm = name,
                        Mode = modeStr,
                        EncryptionTime = encryptionTime,
                        DecryptionTime = decryptionTime
                    });
                }
            }

            return results;
        }
    }
}
