namespace CountryServiceVrijdag.Model
{
    public class CountryException : Exception
    {
        public CountryException(string? message) : base(message)
        {
        }

        public CountryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
