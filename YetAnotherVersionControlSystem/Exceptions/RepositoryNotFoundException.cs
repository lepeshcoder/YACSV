namespace YetAnotherVersionControlSystem.Exceptions;

public class RepositoryNotFoundException : Exception
{
    public RepositoryNotFoundException(string? message) : base(message) {}
}