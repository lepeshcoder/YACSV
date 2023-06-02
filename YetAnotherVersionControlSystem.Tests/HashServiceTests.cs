
using System.Security.Cryptography;
using YetAnotherVersionControlSystem.Services;

namespace YetAnotherVersionControlSystem.Tests;

public class HashServiceTests
{
    private HashService _sut = new();
    
    [Fact]
    public void GetSHA1_ShouldReturnHexString()
    {
        // Arrange
        byte[] bytes = { 0x3, 0x1, 0x6, 0xA };
        var expected = BitConverter.ToString(SHA1.HashData(bytes)).Replace("-", "").ToLower();;
        // Act
        var result = _sut.GetSha1(bytes);
        // Assert
        Assert.Equal(expected,result);
    }
}