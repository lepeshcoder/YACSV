namespace YetAnotherVersionControlSystem.Models;

public class IndexRecord
{
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
    
    public string Hash { get; set; }
    public string Path { get; set; }
    
    public override string ToString()
    {
        return Hash + " " + Path;
    }
}