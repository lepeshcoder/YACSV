using YetAnotherVersionControlSystem.Contracts;

namespace YetAnotherVersionControlSystem.Commands;

public class LogCommand : ICommand
{
    public string Description { get; set; } = "";
    
    public void Execute(params string[] parameters)
    {
        throw new NotImplementedException();
    }
}