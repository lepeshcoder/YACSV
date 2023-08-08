using YetAnotherVersionControlSystem.Models;

namespace YetAnotherVersionControlSystem.Contracts;

public interface IHashService
{
    string GetSha1(byte[] bytes);
  
}