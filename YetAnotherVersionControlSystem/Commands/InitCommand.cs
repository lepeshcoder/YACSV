using YetAnotherVersionControlSystem.Constants;
using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Exceptions;
using YetAnotherVersionControlSystem.Services;

namespace YetAnotherVersionControlSystem.Commands;

public class InitCommand : ICommand
{
    private readonly IFileSystemService _fileSystemService;

    public InitCommand(IFileSystemService fileSystemService)
    {
        _fileSystemService = fileSystemService;
    }

    //TODO
    //Write a description for the command
    public string Description { get; set; }
    
    public void Execute(params string[] parameters)
    {
        var vcsRootDirectory = Environment.CurrentDirectory;
        if (Directory.Exists(vcsRootDirectory))
        {
            throw new InvalidInputException("Repository already exists");
        }

        //Create root directory
        var directoryInfo = Directory.CreateDirectory(vcsRootDirectory);
        directoryInfo.Attributes |= FileAttributes.Hidden;
        
        // Create index file
        var indexFile = _fileSystemService.GetVcsIndexFilePath();
        File.Create(indexFile);

        // Create head file
        var headFile = _fileSystemService.GetVcsHeadFilePath();
        File.Create(headFile);
        
        // Create Objects directory
        var objectsDirectory = _fileSystemService.GetVcsObjectsDirectory();
        Directory.CreateDirectory(objectsDirectory);
       
        // Create Refs Directory 
        var refsDirectory = _fileSystemService.GetVcsRefsDirectory();
        Directory.CreateDirectory(refsDirectory);
        

        //TODO
        //Create config file storing as JSON
    }
}