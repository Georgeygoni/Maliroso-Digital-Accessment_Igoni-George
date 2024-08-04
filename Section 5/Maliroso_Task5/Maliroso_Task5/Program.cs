using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AesEncryption
{
    public static string EncryptString(string plainText, string key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(key);

            aesAlg.GenerateIV(); //Here I Generate a random IV
            byte[] iv = aesAlg.IV;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                //Prepend the IV to the encrypted data
                msEncrypt.Write(iv, 0, iv.Length);

                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
    }

    public static string DecryptString(string cipherText, string key)
    {
        byte[] fullCipher = Convert.FromBase64String(cipherText);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(key);

            //Extracting the IV from the beginning of the cipher text
            byte[] iv = new byte[aesAlg.BlockSize / 8];
            byte[] cipher = new byte[fullCipher.Length - iv.Length];

            Array.Copy(fullCipher, iv, iv.Length);
            Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipher))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}




public class Program
{
    public static void Main()
    {
        string original = "This is My Maliroso Assessment Task 5";
        string key = "1234567890123456"; // Key should be 16 characters for AES-128

        Console.WriteLine("Original:   " + original);

        string encrypted = AesEncryption.EncryptString(original, key);
        Console.WriteLine("Encrypted:  " + encrypted);

        string decrypted = AesEncryption.DecryptString(encrypted, key);
        Console.WriteLine("Decrypted:  " + decrypted);
    }
}