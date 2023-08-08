namespace YetAnotherVersionControlSystem.Models.VcsObjects;

public class TreeObject : VcsObject
{
    private List<VcsObject> _childs = new();

    public TreeObject(string name, string hash) : base(name, hash)
    {
        
    }

    public override string ToString()
    {
        return base.ToString();
    }
}