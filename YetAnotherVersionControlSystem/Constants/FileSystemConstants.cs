namespace YetAnotherVersionControlSystem.Constants;

public static class FileSystemConstants
{
    public const string VcsDirectoryName = ".yavcs";
    public const string VcsIndexDirectoryName = "index";
    public const string VcsObjectsDirectoryName = "objects";
    public const string VcsConfigFileName = "config";

    public static string AddVcsRootDirectory(string path) => path + '/' + VcsDirectoryName;
    public static string AddVcsIndexDirectory(string path) => path + '/' + VcsIndexDirectoryName;
    public static string AddVcsObjectsDirectory(string path) => path + '/' + VcsObjectsDirectoryName;
    }