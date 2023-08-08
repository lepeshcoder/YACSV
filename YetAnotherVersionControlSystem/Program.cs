using System.Threading.Channels;
using YetAnotherVersionControlSystem.Commands;
using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Services;

try
{
    if (args.Length == 0) return;

    var commands = CreateCommandsDictionary();

    if (commands.TryGetValue(args[0], out var command))
        command.Execute(args.Skip(1).ToArray());
    else
        Console.WriteLine($"command \"{args[0]}\" not defined");


    Dictionary<string, ICommand> CreateCommandsDictionary()
    {
        var blobService = new BlobService();
        var hashService = new HashService();
        var fileSystemService = new FileSystemService();
        var indexService = new IndexService(fileSystemService);

        return new Dictionary<string, ICommand>
        {
            ["init"] = new InitCommand(fileSystemService),
            ["add"] = new AddCommand(blobService, indexService, fileSystemService, hashService)
        };
    }
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}