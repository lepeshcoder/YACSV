namespace YetAnotherVersionControlSystem.Models;

public class IndexRecord
{
    public string Hash { get; set; }
    public string Path { get; set; }
    
    public IndexRecord(string indexRecordString)
    {
        var parts = indexRecordString.Split(' ');
        Hash = parts[0];
        Path = parts[1];
    }

    public IndexRecord(string hash, string path)
    {
        Hash = hash;
        Path = path;
    }
    
    public override string ToString() => Hash + " " + Path;
}