namespace Tests.ResultTests;
using Result;
public class ResultTests
{
    [Fact]
    public void Create_Success_WithValue_Should_Success()
    {
        var result = Result.Success(5);
        Assert.Equal(5, result.Value);
        Assert.IsType<int>(result.Value);
        Assert.Equal(Error.None, result.Error);
    }

    [Fact]
    public void Create_Success_WithOutValue_Should_Success()
    {
        var result = Result.Success();
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
    }

    [Fact]
    public void Create_Failure_WithOutValue_Should_Failure()
    {
        var result = Result.Failure(Error.NotFound("Code.NotFound", "Code Not Found"));
        Assert.True(result.IsFailure);
        Assert.Equal(Error.NotFound("Code.NotFound", "Code Not Found"), result.Error);
    }

    [Fact]
    public void CreateFailure_WithValue_Should()
    {
        var result = Result.Failure<int>(Error.Failure("Code.NotFound", "Code Not Found"));
        Assert.True(result.IsFailure);
        Assert.Throws<InvalidOperationException>(() => result.Value);
    }
}