using System;
using System.Security.Cryptography;
using FluentAssertions;
using NUnit.Framework;

namespace SecurityTraining.Encryption.Tests
{
    [TestFixture]
    public class StringEncryptorTest
    {
        [Test]
        public void StringEncryptor_GivenCorrectKey_DecryptsMessage()
        {
            string plainText = "Mary had a little lamb.";
            string key = "Behold, I've become the destroyer of worlds.";

            string encryptedText = StringEncryptor.Encrypt(plainText, key);

            string decryptedText = StringEncryptor.Decrypt(encryptedText, key);

            decryptedText.Should().Be(plainText, "the encryptor decrypted the encrypted test.");
        }

        [Test]
        public void StringEncryptor_GivenIncorrectKey_CannotDecryptMessage()
        {
            string plainText = "Mary had a little lamb.";
            string key = "Behold, I've become the destroyer of worlds.";

            string encryptedText = StringEncryptor.Encrypt(plainText, key);

            Action act = () => StringEncryptor.Decrypt(encryptedText, "wrong key");

            act.ShouldThrow<CryptographicException>();
        }
    }
}

