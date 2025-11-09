using Domain.ValueObject;

namespace Tests.Domain;

public class ValueObjectPasswordTest
{
    [Fact]
    public void Create_ReturnsPasswordWithNonEmptyHash()
    {
        var plain = "MyPassword123!";

        var password = Password.Create(plain);

        Assert.NotNull(password);
        Assert.False(string.IsNullOrWhiteSpace(password.Value));
    }

    [Fact]
    public void Verify_ReturnTrue()
    {
        var passString = "qwerty123";
        var pass = Password.Create(passString);
        Assert.True(pass.Verify(passString));
    }
    
    [Fact]
    public void Verify_ReturnFalse()
    {
        var passString = "qwerty123";
        var passString2 = "qwert123";
        var pass = Password.Create(passString);
        Assert.False(pass.Verify(passString2));
    }

    [Fact]
    public void Equal_ShouldThrowNotSupported()
    {
        var passwordString = "qwerty123";
        var passOne = Password.Create(passwordString);
        var passTwo = Password.Create(passwordString);
        Assert.Throws<NotSupportedException>(() => passOne.Equals(passTwo));
    }
    
    
    [Fact]
    public void GetHashCode_ShouldThrowNotSupported()
    {
        var passwordString = "qwerty123";
        var pass = Password.Create(passwordString);
        Assert.Throws<NotSupportedException>(() => pass.GetHashCode());
    }
}