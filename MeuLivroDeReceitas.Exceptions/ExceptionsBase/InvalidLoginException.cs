namespace MeuLivroDeReceitas.Exceptions.ExceptionsBase
{
    public class InvalidLoginException : MeuLivroDeRecitasException
    {
        public InvalidLoginException() : base(ResourceMessagesExceptions.EMAIL_OR_PASSWORD_INVALID)
        {
        }
    }
}
