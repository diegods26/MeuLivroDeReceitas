using System.Security.Cryptography;
using System.Text;

namespace MeuLivroDeReceitas.Application.Services.Cryptography
{
    public class PasswordEncrypter
    {
        public string Encrypt(string password)
        {
            var chaveAdicional = "ABC";
            var newPassword = $"{password}{chaveAdicional}";

            var bytes = Encoding.UTF8.GetBytes(newPassword);
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }

        private static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var hashByte in bytes)
            {
                sb.Append(hashByte.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
