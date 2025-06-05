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
            var algorithms = new (string Name, Func<SymmetricAlgorithm> Create, CipherMode[] Modes, PaddingMode Padding)[]
            {
                ("DES", DES.Create, new[] { CipherMode.ECB, CipherMode.CBC, CipherMode.CFB }, PaddingMode.PKCS7),
                ("TripleDES", TripleDES.Create, new[] { CipherMode.ECB, CipherMode.CBC, CipherMode.CFB }, PaddingMode.PKCS7),
                ("RC2", RC2.Create, new[] { CipherMode.ECB, CipherMode.CBC, CipherMode.CFB }, PaddingMode.PKCS7),
                ("Rijndael", Rijndael.Create, new[] { CipherMode.ECB, CipherMode.CBC, CipherMode.CFB }, PaddingMode.PKCS7),
                ("AES", Aes.Create, new[] { CipherMode.ECB, CipherMode.CBC, CipherMode.CFB }, PaddingMode.PKCS7)
            };

            foreach (var (name, factory, modes, padding) in algorithms)
            {
                foreach (var modeValue in modes)
                {
                    var algorithm = factory();
                    algorithm.Mode = modeValue;
                    algorithm.Padding = padding;
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
                        Mode = modeValue,
                        EncryptionTime = encryptionTime,
                        DecryptionTime = decryptionTime
                    });
                }
            }

            return results;
        }
    }
}
