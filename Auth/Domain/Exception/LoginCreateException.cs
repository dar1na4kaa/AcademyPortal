namespace Domain.Exception;

public class LoginCreateException: UserCreateException
{
    public LoginCreateException(string message): base(message)
    {
        
    }
}