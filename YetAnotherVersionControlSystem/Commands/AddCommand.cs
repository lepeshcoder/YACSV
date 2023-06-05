using System.Collections;
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

    //TODO попробуй сделать ParallelExecute
    public void ParallelExecute(params string[] parameters)
    {
        var workingDirectory = Environment.CurrentDirectory;
        var itemFullName = workingDirectory + '/' + parameters[0];
        if (Directory.Exists(itemFullName))
        {
            var paths = new Queue<string>(Directory.GetFileSystemEntries(itemFullName));
            while (paths.Count != 0)
            {
                var currPath = paths.Dequeue();
            }
        }
        else if (File.Exists(itemFullName))
        {
            StageFile(itemFullName);
        }
        else
        {
            throw new Exception("Unknown File Entry");
        }
    }
    
    public void Execute(params string[] parameters)
    {
        var workingDirectory = Environment.CurrentDirectory;
        var itemFullName = workingDirectory + '/' + parameters[0];
        
        if (File.Exists(itemFullName))
        {
            StageFile(itemFullName);
        }
        else if (Directory.Exists(itemFullName))
        {
            StageDirectory(itemFullName);
        }
        else
        {
            throw new Exception("not a File or Directory");
        }
    }

   
    private void StageDirectory(string directoryPath)
    {
        // TODO Add parallelism
        var childs = Directory.GetFileSystemEntries(directoryPath);
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
            else throw new Exception("directory include not only files or directories");
        }
        
    }

    private void StageFile(string filePath)
    {
        var bytesArray = File.ReadAllBytes(filePath);
        var hash = _hashService.GetSha1(bytesArray);
        var indexHash = _indexService.GetHashByPath(filePath);
            
        // If file already exist in index
        if (indexHash != null)
        {
            // if file modified after previous add 
            if (hash != indexHash)
            {
                // can delete blob if no another files in index have reference to it
                if (_indexService.GetPathByHash(indexHash).Count == 1)
                {
                    _blobService.DeleteBlob(indexHash);
                }
                _blobService.CreateBlob(hash, bytesArray);
                _indexService.DeleteFromIndexByPath(filePath);
                _indexService.WriteToIndex(hash, filePath);
            }
            else
            {
                throw new Exception("Item is already staged");
            }
        }
        else
        {
            if (!_blobService.IsBlobExist(hash))
            {
                _blobService.CreateBlob(hash, bytesArray);
            }
            _indexService.WriteToIndex(hash, filePath);
        }
    }
}