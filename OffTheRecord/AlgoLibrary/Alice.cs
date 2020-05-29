using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AlgoLibrary
{
    public class Alice
    {
        public static byte[] AlicePublicKey;

        public static void Main(string[] args)
        {
            using var alice = new ECDiffieHellmanCng
            {
                KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
                HashAlgorithm = CngAlgorithm.Sha256
            };

            AlicePublicKey = alice.PublicKey.ToByteArray();
            var bob = new Bob();
            var k = CngKey.Import(bob.BobPublicKey, CngKeyBlobFormat.EccPublicBlob);
            var aliceKey = alice.DeriveKeyMaterial(CngKey.Import(bob.BobPublicKey, CngKeyBlobFormat.EccPublicBlob));
            Send(aliceKey, "Secret message", out var encryptedMessage, out var iv);
            bob.Receive(encryptedMessage, iv);
        }

        private static void Send(byte[] key, string secretMessage, out byte[] encryptedMessage, out byte[] iv)
        {
            using Aes aes = new AesCryptoServiceProvider();
            aes.Key = key;
            iv = aes.IV;

            // Encrypt the message
            using var cipherText = new MemoryStream();
            using var cs = new CryptoStream(cipherText, aes.CreateEncryptor(), CryptoStreamMode.Write);
            var plaintextMessage = Encoding.UTF8.GetBytes(secretMessage);
            cs.Write(plaintextMessage, 0, plaintextMessage.Length);
            cs.Close();
            encryptedMessage = cipherText.ToArray();
        }
    }

    public class Bob
    {
        public byte[] BobPublicKey;
        private readonly byte[] _bobKey;

        public Bob()
        {
            using var bob = new ECDiffieHellmanCng
            {
                KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
                HashAlgorithm = CngAlgorithm.Sha256
            };

            BobPublicKey = bob.PublicKey.ToByteArray();
            _bobKey = bob.DeriveKeyMaterial(CngKey.Import(Alice.AlicePublicKey, CngKeyBlobFormat.EccPublicBlob));
        }

        public void Receive(byte[] encryptedMessage, byte[] iv)
        {
            using Aes aes = new AesCryptoServiceProvider();
            aes.Key = _bobKey;
            aes.IV = iv;

            // Decrypt the message
            using var plaintext = new MemoryStream();
            using var cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(encryptedMessage, 0, encryptedMessage.Length);
            cs.Close();
            var message = Encoding.UTF8.GetString(plaintext.ToArray());
            Console.WriteLine(message);
        }
    }
}
