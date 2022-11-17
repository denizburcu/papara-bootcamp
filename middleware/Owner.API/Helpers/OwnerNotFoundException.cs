namespace OwnerApi
{
    // custom exception class for throwing application specific exceptions (e.g. for validation) 
    // that can be caught and handled within the application
    public class OwnerNotFoundException : Exception
    {
        public OwnerNotFoundException(string message) : base(message) { }
    }
}