using Domain.ValueObject;

namespace Domain.Entities;

public class User
{
    public int UserId { get; set; }
    
    public Guid UserGuid { get; }
    
    public Password Password { get; private set; }
    
    public Email Email { get; private set; }

    private User(string email, string password, Guid userGuid)
    {
        UserGuid = userGuid;
        Email = Email.Create(email);
        Password = Password.Create(password);
    }
    
    private User() {}
    

    public static User Create(string email, string password) => new(email, password, Guid.NewGuid());
    
    public static User Create(string email, string password, Guid guid) => new(email, password, guid);
    
    public void ChangePassword(string newPassword) => Password = Password.Create(newPassword);

    public void ChangeEmail(string newEmail) => Email = Email.Create(newEmail);
}