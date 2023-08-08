using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Models;

namespace YetAnotherVersionControlSystem.Commands;

public class CommitCommand : ICommand
{
    private readonly IFileSystemService _fileSystemService;

    public CommitCommand(IFileSystemService fileSystemService)
    {
        _fileSystemService = fileSystemService;
    }

    public string Description { get; set; } = "";
    
    public void Execute(params string[] parameters)
    {
        var vscRootDirectory = new VcsRootDirectory(Environment.CurrentDirectory);
        
        
    }
}