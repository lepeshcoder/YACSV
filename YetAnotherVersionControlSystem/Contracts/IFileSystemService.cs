namespace YetAnotherVersionControlSystem.Contracts;

public interface IFileSystemService
{
    public string? GetVcsRootDirectory();
    public string? GetVcsObjectsDirectory();
    public string? GetVcsRefsDirectory();
    public string GetVcsBlobsDirectory();
    public string GetVcsTreesDirectory();
    public string GetVcsCommitsDirectory();
    public string GetVcsIndexFilePath();
    public string GetVcsHeadFilePath();
}