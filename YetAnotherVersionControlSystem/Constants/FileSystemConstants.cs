namespace YetAnotherVersionControlSystem.Constants;

public static class FileSystemConstants
{
    public const string VcsRootDirectoryName = ".yavcs";
    public const string VcsIndexFileName = "index";
    public const string VcsObjectsDirectoryName = "objects";
    public const string VcsRefsDirectoryName = "refs";
    public const string VcsBlobsDirectoryName = "blobs";
    public const string VcsTreesDirectoryName = "trees";
    public const string VcsCommitsDirectoryName = "commits";
    public const string VcsHeadFileName = "HEAD";

    public static string? AddVcsRootDirectory(string path) => path + '/' + VcsRootDirectoryName;
    public static string AddVcsObjectsDirectory(string? path) => path + '/' + VcsObjectsDirectoryName;
    public static string AddVcsBlobsDirectory(string? path) => path + '/' + VcsBlobsDirectoryName;
    public static string AddVcsTreesDirectory(string? path) => path + '/' + VcsTreesDirectoryName;
    public static string AddVcsCommitsDirectory(string? path) => path + '/' + VcsCommitsDirectoryName;
    public static string AddVcsRefsDirectory(string? path) => path + '/' + VcsRefsDirectoryName;
    public static string AddVcsIndexFileName(string? path) => path + '/' + VcsIndexFileName;
    public static string AddVcsHeadFileName(string? path) => path + '/' + VcsHeadFileName;
}
    
