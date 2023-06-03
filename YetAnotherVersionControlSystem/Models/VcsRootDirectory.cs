﻿namespace YetAnotherVersionControlSystem.Models;

public class VcsRootDirectory
{
    public VcsRootDirectory(string path)
    {
        Path = path;
    }
    
    public static string Name => ".yavcs";
    private static string Index => "index";
    private static string Head => "head";
    private static string Objects => "objects";
    private static string Blobs => "blobs";
    private static string Refs => "refs";
    
    public string Path { get; }
    public string FullName => Path + '/' + Name;
    public string IndexPath => FullName + '/' + Index;
    public string HeadPath => FullName + '/' + Head;
    public string ObjectsPath => FullName + '/' + Objects;
    public string RefsPath => FullName + '/' + Refs;
    public string BlobsPath(string? hash)
    {
        var postfix = hash is null ? "" : '/' + hash;
        return ObjectsPath + '/' + Blobs + postfix;
    }
}