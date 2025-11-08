namespace Domain.Exception;

public class UserCreateException: ArgumentException
{
    public UserCreateException(string message): base(message)
    {
        
    }
}