namespace MeuLivroDeReceitas.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : MeuLivroDeRecitasException
    {
        public IList<string> ErrorMenssages { get; set; }

        public ErrorOnValidationException(IList<string> errorMenssages)
        {
            ErrorMenssages = errorMenssages;
        }
    }
}
