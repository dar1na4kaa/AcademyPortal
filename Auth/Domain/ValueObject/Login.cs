using System.Runtime.CompilerServices;
using Domain.Exception;

namespace Domain.ValueObject;

public class Email: ValueObject<string>
{
    public override string Value { get; }

    private Email(string value)
    {
        Value = value;
    }
    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new LoginCreateException("Emnail cannot be empty");
        if (value.Length > 30) throw new LoginCreateException("Email cannot be greater than 30");
        if (!IsValidEmail(value)) throw new LoginCreateException("Email is not valid");
        
        return new Email(value);
    }
    
    static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);

            if (addr.Address == email) 
                return true;
            
        }
        catch
        {
            return false;
        }

        return false;
    }
}