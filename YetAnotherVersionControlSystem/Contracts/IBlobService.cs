namespace YetAnotherVersionControlSystem.Contracts;

public interface IBlobService
{
    void CreateBlob(string hash, byte[] data);

    bool IsBlobExist(string hash);

    void DeleteBlob(string hash);
}