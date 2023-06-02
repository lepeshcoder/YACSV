using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Services;

namespace YetAnotherVersionControlSystem.Commands;

public class AddCommand : ICommand
{
    private readonly IBlobService _blobService;
    private readonly IIndexService _indexService;
    private readonly IFileSystemService _fileSystemService;
    private readonly IHashService _hashService;

    public AddCommand(IBlobService blobService, IIndexService indexService, 
        IFileSystemService fileSystemService, IHashService hashService)
    {
        _blobService = blobService;
        _indexService = indexService;
        _fileSystemService = fileSystemService;
        _hashService = hashService;
    }

    public string Description { get; set; } = "";
    
    
    public void Execute(params string[] parameters)
    {
        var workingDirectory = Environment.CurrentDirectory;
        var vcsRootDirectory = _fileSystemService.GetVcsRootDirectory();
        var indexFile = _fileSystemService.GetVcsIndexFilePath();
        var itemFullName = workingDirectory + '/' + parameters[0];
        
        if (File.Exists(itemFullName))
        {
            StageFile(itemFullName);
        }
        else if (Directory.Exists(itemFullName))
        {
            StageDirectory(itemFullName);
        }
        else throw new Exception("not a File or Directory");

    }

    private void StageDirectory(string itemFullName)
    {
        string[] childs = Directory.GetFileSystemEntries(itemFullName);
        foreach (var child in childs)
        {
            if (Directory.Exists(child))
            {
                StageDirectory(child);
            }
            else if (File.Exists(child))
            {
                StageFile(child);
            }
            else throw new Exception("directory include not only files or directory");
        }
        
    }

    private void StageFile(string itemFullName)
    {
        byte[] bytesArray = File.ReadAllBytes(itemFullName);
        var hash = _hashService.GetSha1(bytesArray);
        var indexHash = _indexService.GetHashByPath(itemFullName);
            
        if (indexHash != null)
        {
            if (hash != indexHash)
            {
                //TODO REPLACE
                _blobService.DeleteBlob(indexHash);
                _blobService.CreateBlob(hash, bytesArray);
                _indexService.DeleteFromIndex(indexHash);
                _indexService.WriteToIndex(hash, itemFullName);
            }
            else
            {
                var indexPath = _indexService.GetPathByHash(hash);
                if (itemFullName != indexPath)
                {
                    _indexService.DeleteFromIndex(hash);
                    _indexService.WriteToIndex(hash, itemFullName);
                }
                else throw new Exception("Item is already staged");
            }
        }
        else
        {
            _blobService.CreateBlob(hash,bytesArray);
            _indexService.WriteToIndex(hash, itemFullName);
        }
    }
}