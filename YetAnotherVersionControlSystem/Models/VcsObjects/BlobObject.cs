namespace YetAnotherVersionControlSystem.Models.VcsObjects;

public class BlobObject : VcsObject
{
    public BlobObject(string name, string hash) : base(name, hash)
    {
        
    }

    public override string ToString()
    {
        return Hash + " " + Name;
    }
}