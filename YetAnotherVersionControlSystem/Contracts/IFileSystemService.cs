using YetAnotherVersionControlSystem.Models;

namespace YetAnotherVersionControlSystem.Contracts;

public interface IFileSystemService
{
    public VcsRootDirectory GetVcsRootDirectory();
}