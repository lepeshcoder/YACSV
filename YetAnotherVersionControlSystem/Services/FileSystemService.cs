using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Models;

namespace YetAnotherVersionControlSystem.Services;

public class FileSystemService : IFileSystemService
{
    private VcsRootDirectory? _vcsRootDirectory;
    public VcsRootDirectory GetVcsRootDirectory()
    {
        if (_vcsRootDirectory is not null)
        {
            return _vcsRootDirectory;
        }
        
        var currentDirectory = Environment.CurrentDirectory;
        while (currentDirectory is not null)
        {
            if (IsVcsRootDirectory())
            { 
                _vcsRootDirectory = new VcsRootDirectory(currentDirectory);
                return _vcsRootDirectory;
            }
            currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
        }
        
        //TODO Create custom exception (RepositoryNotFoundException)
        throw new Exception("Repository not found");
    }

    //TODO Think about how validate is this root directory
    private static bool IsVcsRootDirectory()
    {
        return Directory.Exists(VcsRootDirectory.Name);
    }
    
    
}