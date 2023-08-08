using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Models;

namespace YetAnotherVersionControlSystem.Services;

public class TreeService : ITreeService
{
    private readonly IFileSystemService _fileSystemService;
    private readonly IHashService _hashService;

    public TreeService(IFileSystemService fileSystemService, IHashService hashService)
    {
        _fileSystemService = fileSystemService;
        _hashService = hashService;
    }

    
}