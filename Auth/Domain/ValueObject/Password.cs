using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using Domain.Tools;

namespace Domain.ValueObject;

public class Password: ValueObject<string>
{
    public override string Value { get; }

    private Password(string value)
    {
        Value = value;
    }

    public static Password Create(string value)
    {
        var hashPassword = PasswordGenerator.Generate(value);

        return new Password(hashPassword);
    }

    public bool Verify(string password) => PasswordGenerator.Verify(Value,password);
    
    
    public override bool Equals(object obj)
    {
        throw new NotSupportedException("Password objects should not be compared directly. Use Verify() instead.");
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException("Password objects should not be compared directly. Use Verify() instead.");
    }
}