using System.Globalization;
using YetAnotherVersionControlSystem.Constants;
using YetAnotherVersionControlSystem.Contracts;

namespace YetAnotherVersionControlSystem.Services;

public class FileSystemService : IFileSystemService
{
    public string? GetVcsRootDirectory()
    {
        var currentDirectory = Environment.CurrentDirectory;
        while (currentDirectory is not null)
        {
            if (IsVcsRootDirectory())
            {
                return currentDirectory;
            }

            currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
        }
        
        //TODO Create custom exception (RepositoryNotFoundException)
        throw new Exception("Repository not found");
    }

    private static bool IsVcsRootDirectory()
    {
        return Directory.Exists(FileSystemConstants.VcsDirectoryName);
    }
}