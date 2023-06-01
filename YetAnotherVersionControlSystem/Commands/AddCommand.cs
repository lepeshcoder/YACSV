using YetAnotherVersionControlSystem.Contracts;

namespace YetAnotherVersionControlSystem.Commands;

public class AddCommand : ICommand
{
    public string Description { get; set; }
    public void Execute(params string[] parameters)
    {
        
    }
}