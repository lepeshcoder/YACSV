using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Exceptions;
using YetAnotherVersionControlSystem.Models;

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
        var vcsRootDirectory = new VcsRootDirectory(Environment.CurrentDirectory);
        if (Directory.Exists(vcsRootDirectory.FullName))
        {
            throw new InvalidInputException("Repository already exists");
        }

        //Create root directory
        var directoryInfo = Directory.CreateDirectory(vcsRootDirectory.FullName);
        directoryInfo.Attributes |= FileAttributes.Hidden;
        
        // Create index file
        var indexFile = vcsRootDirectory.IndexPath;
        File.Create(indexFile);

        // Create head file
        var headFile = vcsRootDirectory.HeadPath;
        File.Create(headFile);
        
        // Create Objects directory
        var objectsDirectory = vcsRootDirectory.ObjectsPath;
        Directory.CreateDirectory(objectsDirectory);
       
        // Create Refs Directory 
        var refsDirectory = vcsRootDirectory.RefsPath;
        Directory.CreateDirectory(refsDirectory);
        

        //TODO
        //Create config file storing as JSON
    }
}