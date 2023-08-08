namespace YetAnotherVersionControlSystem.Contracts;

public interface IIndexService
{
    // always return 1 record because path is unique
    string GetHashByPath(string path);

    // Can return collection of Files/Directory Paths cause files with same data have same hashes
    List<string> GetPathByHash(string hash);
    
    void WriteToIndex(string objectHash, string objectPath);
    void DeleteFromIndexByPath(string objectPath);
}