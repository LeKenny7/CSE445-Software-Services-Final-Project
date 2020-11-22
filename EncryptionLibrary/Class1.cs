using System;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionLibrary
{
    public class Class1
    {
        private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        //async System.Threading.Tasks.Task<string>
        public string encryptAsync(string text)
        {
            try
            {
                SymmetricAlgorithm algorithm = DES.Create();
                ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
                byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                return Convert.ToBase64String(outputBuffer);
                /*
                EncryptService.ServiceClient encryptService = new EncryptService.ServiceClient();
                string temp = await encryptService.EncryptAsync(input);
                return temp;
                */
            }catch{
                return text;
            }


        }

        public string decryptAsync(string text)
        {
            try
            {
                SymmetricAlgorithm algorithm = DES.Create();
                ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
                byte[] inputbuffer = Convert.FromBase64String(text);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                return Encoding.Unicode.GetString(outputBuffer);
                /*EncryptService.ServiceClient decryptService = new EncryptService.ServiceClient();
                string temp = await decryptService.DecryptAsync(input);
                return temp;*/
            }
            catch
            {
                return text;
            }



        }
    }
}
