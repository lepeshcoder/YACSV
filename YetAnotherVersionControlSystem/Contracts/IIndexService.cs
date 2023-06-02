namespace YetAnotherVersionControlSystem.Contracts;

public interface IIndexService
{
    string? GetHashByPath(string path);

    string? GetPathByHash(string hash);
    
    void WriteToIndex(string objectHash, string objectPath);

    bool IsInIndex(string objectHash, string objectPath);

    void DeleteFromIndex(string objectHash);

    void ClearIndex();
}