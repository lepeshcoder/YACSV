namespace YetAnotherVersionControlSystem.Contracts;

public interface ICommand
{
    string Description { get; set; }
    void Execute(params string[] parameters);
}