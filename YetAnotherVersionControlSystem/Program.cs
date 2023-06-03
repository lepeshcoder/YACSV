using YetAnotherVersionControlSystem.Commands;
using YetAnotherVersionControlSystem.Contracts;
using YetAnotherVersionControlSystem.Services;

Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
var fileSystemService = new FileSystemService();
commands["init"] = new InitCommand(fileSystemService);
commands["add"] = new AddCommand(new BlobService(),new IndexService(fileSystemService),fileSystemService,new HashService());

commands[args[0]].Execute(args.Skip(1).ToArray());
 