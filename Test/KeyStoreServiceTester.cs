﻿using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.KeyStore;
namespace Nethereum.KeyStore.UnitTests
{
    public class KeyStoreServiceTester
    {
        private readonly string pbkdf2KeyStoreDocument = @"
{
    ""crypto"" : {
        ""cipher"" : ""aes-128-ctr"",
        ""cipherparams"" : {
            ""iv"" : ""6087dab2f9fdbbfaddc31a909735c1e6""
        },
        ""ciphertext"" : ""5318b4d5bcd28de64ee5559e671353e16f075ecae9f99c7a79a38af5f869aa46"",
        ""kdf"" : ""pbkdf2"",
        ""kdfparams"" : {
            ""c"" : 262144,
            ""dklen"" : 32,
            ""prf"" : ""hmac-sha256"",
            ""salt"" : ""ae3cd4e7013836a3df6bd7241b12db061dbe2c6785853cce422d148a624ce0bd""
        },
        ""mac"" : ""517ead924a9d0dc3124507e3393d175ce3ff7c1e96529c6c555ce9e51205e9b2""
    },
    ""id"" : ""3198bc9c-6672-5ab3-d995-4942343ae5b6"",
    ""version"" : 3
}";

        private readonly string scryptKeyStoreDocument = @"{
    ""crypto"" : {
        ""cipher"" : ""aes-128-ctr"",
        ""cipherparams"" : {
            ""iv"" : ""83dbcc02d8ccb40e466191a123791e0e""
        },
        ""ciphertext"" : ""d172bf743a674da9cdad04534d56926ef8358534d458fffccd4e6ad2fbde479c"",
        ""kdf"" : ""scrypt"",
        ""kdfparams"" : {
            ""dklen"" : 32,
            ""n"" : 262144,
            ""r"" : 1,
            ""p"" : 8,
            ""salt"" : ""ab0c7876052600dd703518d6fc3fe8984592145b591fc8fb5c6d43190334ba19""
        },
        ""mac"" : ""2103ac29920d71da29f15d75b4a16dbe95cfd7ff8faea1056c33131d846e3097""
    },
    ""id"" : ""3198bc9c-6672-5ab3-d995-4942343ae5b6"",
    ""version"" : 3
}";

     //   [Fact]
        public void ShouldDecryptPbkdf2_Kdf()
        {
            var password = "testpassword";
            var privateKey = "7a28b5ba57c53603b0b07b56bba752f7784bf506fa95edc395f5cf6c7514fe9d";
            var keyStorePbkdf2Service = new KeyStorePbkdf2Service();
            var keyStore = keyStorePbkdf2Service.DeserializeKeyStoreFromJson(pbkdf2KeyStoreDocument);
            var privateKeyDecrypted = keyStorePbkdf2Service.DecryptKeyStore(password, keyStore);
  //          Assert.Equal(privateKey, privateKeyDecrypted.ToHex());
        }

   //     [Fact]
        public void ShouldDecryptScrypt_Kdf()
        {
            var password = "testpassword";
            var privateKey = "7a28b5ba57c53603b0b07b56bba752f7784bf506fa95edc395f5cf6c7514fe9d";
            var keyStoreScryptService = new KeyStoreScryptService();
            var keyStore = keyStoreScryptService.DeserializeKeyStoreFromJson(scryptKeyStoreDocument);
            var privateKeyDecrypted = keyStoreScryptService.DecryptKeyStore(password, keyStore);
    //        Assert.Equal(privateKey, privateKeyDecrypted.ToHex());
        }

     //   [Fact]
        public void ShouldEncryptAndDecryptPbkdf2_Kdf()
        {
            var password = "testpassword";
            var privateKey = "7a28b5ba57c53603b0b07b56bba752f7784bf506fa95edc395f5cf6c7514fe9d";
            var account = "x";
            var keyStorePbkdf2Service = new KeyStorePbkdf2Service();
            var keyStoreJson =
                keyStorePbkdf2Service.EncryptAndGenerateKeyStoreAsJson(password, privateKey.HexToByteArray(), account);
            var keyStore = keyStorePbkdf2Service.DeserializeKeyStoreFromJson(keyStoreJson);
            var privateKeyDecrypted = keyStorePbkdf2Service.DecryptKeyStore(password, keyStore);
    //        Assert.Equal(privateKey, privateKeyDecrypted.ToHex());
        }

   //     [Fact]
        public void ShouldEncryptAndDecryptScrypt_Kdf()
        {
            var password = "testpassword";
            var privateKey = "7a28b5ba57c53603b0b07b56bba752f7784bf506fa95edc395f5cf6c7514fe9d";
            var account = "x";
            var keyStoreScryptService = new KeyStoreScryptService();
            var keyStoreJson =
                keyStoreScryptService.EncryptAndGenerateKeyStoreAsJson(password, privateKey.HexToByteArray(), account);
            var keyStore = keyStoreScryptService.DeserializeKeyStoreFromJson(keyStoreJson);
            var privateKeyDecrypted = keyStoreScryptService.DecryptKeyStore(password, keyStore);
    //        Assert.Equal(privateKey, privateKeyDecrypted.ToHex());
        }

     //   [Fact]
        public void ShouldIdentifyPbkdf2_Kdf()
        {
            var keyStoreKdfChecker = new KeyStoreKdfChecker();
            var kdfType = keyStoreKdfChecker.GetKeyStoreKdfType(pbkdf2KeyStoreDocument);
    //        Assert.Equal(KeyStoreKdfChecker.KdfType.pbkdf2, kdfType);
        }

     //   [Fact]
        public void ShouldIdentifyScrypt_Kdf()
        {
            var keyStoreKdfChecker = new KeyStoreKdfChecker();
            var kdfType = keyStoreKdfChecker.GetKeyStoreKdfType(scryptKeyStoreDocument);
    //        Assert.Equal(KeyStoreKdfChecker.KdfType.scrypt, kdfType);
        }
    }
}