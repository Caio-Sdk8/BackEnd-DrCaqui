using System.Security.Cryptography;
using System.Text;

namespace DrCaquiV1._2.Services
{
    public class Criptografia
    {   

        public string Encrypt(string texto) {
            using(Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Key"));
                aesAlg.IV = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("IV"));

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt =  new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(texto);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        public string Decrypt(string texto)
        {
            byte[] chipherText = Convert.FromBase64String(texto);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Key"));
                aesAlg.IV = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("IV"));

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(chipherText))
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
}
