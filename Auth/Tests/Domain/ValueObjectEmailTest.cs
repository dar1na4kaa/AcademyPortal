using Domain.Exception;
using Domain.ValueObject;

namespace Tests.Domain;

public class ValueObjectEmailTest
{
    [Fact]
    public void Create_ReturnNewEmail()
    {
        var stringEmail = "test@mail.ru";
        var email = Email.Create(stringEmail);
        Assert.Equal(stringEmail, email.Value);
    }

    [Theory]
    [InlineData("testmail.ru")]
    [InlineData("teeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee@mail.ru")]
    [InlineData("")]
    public void Create_Invalid_ThrowsLoginCreateException(string email)
    {
        Assert.Throws<LoginCreateException>(() =>Email.Create(email));
    }
    
    [Fact]
    public void Equal_ShouldTrue()
    {
        var emailString = "test@mail.ru";
        var emailOne = Email.Create(emailString);
        var emailTwo = Email.Create(emailString);
        Assert.Equal(emailOne, emailTwo);
    }
}