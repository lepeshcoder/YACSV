using YetAnotherVersionControlSystem.Constants;
using YetAnotherVersionControlSystem.Contracts;

namespace YetAnotherVersionControlSystem.Services;

public class FileSystemService : IFileSystemService
{

    public string? GetVcsObjectsDirectory()
    {
        return FileSystemConstants.AddVcsObjectsDirectory(GetVcsRootDirectory());
    }

    public string? GetVcsRefsDirectory()
    {
        return FileSystemConstants.AddVcsRefsDirectory(GetVcsRootDirectory());
    }

    public string GetVcsBlobsDirectory()
    {
        return FileSystemConstants.AddVcsBlobsDirectory(GetVcsObjectsDirectory());
    }
    
    public string GetVcsTreesDirectory()
    {
        return FileSystemConstants.AddVcsTreesDirectory(GetVcsObjectsDirectory());
    }
    
    public string GetVcsCommitsDirectory()
    {
        return FileSystemConstants.AddVcsCommitsDirectory(GetVcsObjectsDirectory());
    }

    public string GetVcsIndexFilePath()
    {
        return FileSystemConstants.AddVcsIndexFileName(GetVcsRootDirectory());
    }

    public string GetVcsHeadFilePath()
    {
        return FileSystemConstants.AddVcsHeadFileName(GetVcsRootDirectory());
    }

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

    //TODO Think about how validate is this root directory
    private static bool IsVcsRootDirectory()
    {
        return Directory.Exists(FileSystemConstants.VcsRootDirectoryName);
    }
    
    
}