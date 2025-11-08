using Domain.Entities;
using Domain.ValueObject;

namespace Tests.Domain;

public class UserTests
{
    [Fact]
    public void Create_WithValidEmailAndPassword_CreatesUser()
    {
        var email = "test@mail.ru";
        var password = "qwerty123";
        var user = User.Create(email, password);
        Assert.Equal(email, user.Email.Value);
        Assert.True(user.Password.Verify(password));
        Assert.NotEqual(Guid.Empty, user.Guid);
    }
    
    [Fact]
    public void Create_WithValidEmailAndPasswordAndGuid_CreatesUser()
    {
        var email = "test@mail.ru";
        var password = "qwerty123";
        var guid = Guid.NewGuid();
        var user = User.Create(email, password, guid);
        Assert.Equal(email, user.Email.Value);
        Assert.True(user.Password.Verify(password));
        Assert.Equal(user.Guid, guid);
    }

    [Fact]
    public void Change_Email_ShouldEqual()
    {
        var email = "test@mail.ru";
        var email2 = "newtest@mail.ru";
        var password = "qwerty123";
        var user = User.Create(email, password);
        user.ChangeEmail(email2);
        Assert.Equal(user.Email.Value, email2);
    }
    
    [Fact]
    public void Change_Password_ShouldReturnTrue()
    {
        var email = "test@mail.ru";
        var passString = "qwerty123";
        var passString2 = "QWERTY123";
        var user = User.Create(email, passString);
        user.ChangePassword(passString2);
        Assert.True(user.Password.Verify(passString2));
    }
}