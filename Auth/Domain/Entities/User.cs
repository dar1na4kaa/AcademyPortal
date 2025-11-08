using Domain.ValueObject;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    
    public Guid Guid { get; set; }
    
    public required Password PasswordHash { get; set; }
    
    public required Email Email { get; set; }
}