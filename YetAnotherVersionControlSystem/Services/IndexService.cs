using YetAnotherVersionControlSystem.Contracts;

namespace YetAnotherVersionControlSystem.Services;

public class IndexService : IIndexService
{
    
    //TODO вынести парсер индекса в отдельный класс, сделать методы для получения коллекции хэшей и путей
    private readonly IFileSystemService _fileSystemService;

    public IndexService(IFileSystemService fileSystemService)
    {
        _fileSystemService = fileSystemService;
    }

    public string GetHashByPath(string path)
    {
        throw new NotImplementedException();
    }

    public string? GetPathByHash(string hash)
    {
        throw new NotImplementedException();
    }

    public void WriteToIndex(string objectHash, string objectPath)
    {
        using StreamWriter writer = File.AppendText(objectPath);
        writer.WriteLine(objectHash + " " + objectPath);
    }

    public bool IsInIndex(string objectHash, string objectPath)
    {
        throw new NotImplementedException();
    }

    public void DeleteFromIndex(string objectHash)
    {
        var records = new List<string>(File.ReadAllLines(_fileSystemService.GetVcsIndexFilePath()));
        foreach (var record in records)
        {
            string[] parts = record.Split(' ');
            string hash = parts[0];
            if (hash == objectHash)
            {
                records.Remove(record);
            }
        } 
        File.WriteAllLines(_fileSystemService.GetVcsIndexFilePath(),records);
    }

    public void ClearIndex()
    {
        File.WriteAllText(_fileSystemService.GetVcsIndexFilePath(),"");
    }
}