namespace FakeUserProject.Service.Helpers
{
    // custom exception class for throwing application specific exceptions (e.g. for validation) 
    // that can be caught and handled within the application
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message) { }
    }


}