using MeuLivroDeReceitas.Application.Services.Cryptography;

namespace CommonTestUtilities.Cryptography
{
    public class PasswordEncripterBuilder
    {
        public static PasswordEncrypter Build() => new PasswordEncrypter();
    }
}
