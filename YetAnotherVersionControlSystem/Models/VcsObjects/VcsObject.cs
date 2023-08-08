namespace YetAnotherVersionControlSystem.Models.VcsObjects;

public class VcsObject
{
    public VcsObject(string name, string hash)
    {
        Name = name;
        Hash = hash;
    }

    public string Name { get; set; }
    
    public string Hash { get; set; }
    
}