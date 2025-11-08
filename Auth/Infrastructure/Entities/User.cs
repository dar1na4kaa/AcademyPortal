namespace Infrastructure.Entities;

public class User
{
    public int Id { get; set; }
    
    public Guid Guid { get; set; }
    
    public required string Login { get; set; }
    
    public required string PasswordHash { get; set; }
    
    public required string Email { get; set; }
    
    public required string Salt { get; set; }
}