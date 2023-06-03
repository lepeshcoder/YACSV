using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Models;

namespace YetAnotherVersionControlSystem.Services;

public class IndexService : IIndexService
{

    private readonly List<IndexRecord> _indexRecords = new();
    
    private readonly IFileSystemService _fileSystemService;

    public IndexService(IFileSystemService fileSystemService)
    {
        _fileSystemService = fileSystemService;
        var indexPath = _fileSystemService.GetVcsRootDirectory().IndexPath;
        var records = File.ReadAllLines(indexPath);
        foreach (var record in records)
        {
            _indexRecords.Add(new IndexRecord(record));
        }
    }

    public string? GetHashByPath(string path)
    {
        return _indexRecords.Where(record => record.Path == path).Select(record => record.Hash).FirstOrDefault();
    }

    public List<string> GetPathByHash(string hash)
    {
        return (from record in _indexRecords where record.Hash == hash select record.Path).ToList();
    }

    public void WriteToIndex(string objectHash, string objectPath)
    {
        var newRecord = new IndexRecord(objectHash, objectPath);
        _indexRecords.Add(newRecord);
        using var writer = File.AppendText(objectPath);
        writer.WriteLine(newRecord);
    }
    
    public void DeleteFromIndexByPath(string objectPath)
    {
        foreach (var record in _indexRecords.Where(record => record.Path == objectPath))
        {
            _indexRecords.Remove(record);
        }
        var toWrite = _indexRecords.Select(record => record.ToString()).ToList();
        File.WriteAllLines(_fileSystemService.GetVcsRootDirectory().IndexPath,toWrite);
    }
    
}