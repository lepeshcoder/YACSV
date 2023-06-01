using YetAnotherVersionControlSystem.Constants;
using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Exceptions;

namespace YetAnotherVersionControlSystem.Commands;

public class InitCommand : ICommand
{
    //TODO
    //Write a description for the command
    public string Description { get; set; }
    
    public void Execute(params string[] parameters)
    {
        var vcsRootDirectory = Environment.CurrentDirectory + '/' + FileSystemConstants.VcsDirectoryName;
        if (Directory.Exists(vcsRootDirectory))
        {
            throw new InvalidInputException("Repository already exists");
        }
        
        //Create root directory
        var directoryInfo = Directory.CreateDirectory(vcsRootDirectory);
        directoryInfo.Attributes |= FileAttributes.Hidden;
        var indexDirectory = FileSystemConstants.AddVcsIndexDirectory(vcsRootDirectory);
        Directory.CreateDirectory(indexDirectory);
        var objectsDirectory = FileSystemConstants.AddVcsObjectsDirectory(vcsRootDirectory);
        Directory.CreateDirectory(objectsDirectory);
        
        //TODO
        //Create config file storing as JSON
    }
}