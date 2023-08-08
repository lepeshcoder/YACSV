using System.Security.Cryptography;
using System.Text;
using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Models;

namespace YetAnotherVersionControlSystem.Services;

public class HashService : IHashService
{
    public string GetSha1(byte[] bytes)
    {
        var hashBytes = SHA1.HashData(bytes);
        var hexString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        return hexString;
    }

}