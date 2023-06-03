using YetAnotherVersionControlSystem.Contracts;

namespace YetAnotherVersionControlSystem.Services;

public class BlobService : IBlobService
{
    private readonly IFileSystemService _fileSystemService = new FileSystemService();
    
    public void CreateBlob(string hash,byte[] data)
    {
        var blobPath = _fileSystemService.GetVcsRootDirectory().BlobsPath(hash);
        File.WriteAllBytes(blobPath, data);
    }

    public bool IsBlobExist(string hash)
    {
        var blobPath = _fileSystemService.GetVcsRootDirectory().BlobsPath(hash);
        return File.Exists(blobPath);
    }

    public void DeleteBlob(string hash)
    {
        var blobPath = _fileSystemService.GetVcsRootDirectory().BlobsPath(hash);
        File.Delete(blobPath);
    }
}