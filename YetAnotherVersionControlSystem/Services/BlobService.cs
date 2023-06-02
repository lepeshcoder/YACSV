using YetAnotherVersionControlSystem.Constants;
using YetAnotherVersionControlSystem.Contracts;

namespace YetAnotherVersionControlSystem.Services;

public class BlobService : IBlobService
{
    private readonly IFileSystemService _fileSystemService = new FileSystemService();
    private readonly IHashService _hashService = new HashService();


    public void CreateBlob(string hash,byte[] data)
    {
        var blobPath = _fileSystemService.GetVcsBlobsDirectory() + "/" + hash;
        File.WriteAllBytes(blobPath, data);
    }

    public bool IsBlobExist(string hash)
    {
        var blobsDirectory = _fileSystemService.GetVcsBlobsDirectory();
        var blobPath = blobsDirectory + '/' + hash;
        return File.Exists(blobPath);
    }

    public void DeleteBlob(string hash)
    {
        var blobsDirectory = _fileSystemService.GetVcsBlobsDirectory();
        File.Delete(blobsDirectory + "/" + hash);
    }
}