namespace OwnerApi
{
    // custom exception class for throwing application specific exceptions (e.g. for validation) 
    // that can be caught and handled within the application
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string message) : base(message) { }

    }
}