using ConsoleTables;
using DirSize;

var directory = new DirectoryInfo(Environment.CurrentDirectory);

var directories = DirectorySize.GetDirectories(directory.FullName);

if (directories.Length <= 0)
    Environment.Exit(1);

Console.WriteLine($"\n\r Directory: {directory.Name} - {TreeSizeConsole.Format(directories.Sum(x => x.Size))} \r\n");

int nameLenghtMax = directories.Max(x => x.DirectoryInfo.Name.Length) + 10;

var table = new ConsoleTable("Directory", "Size");
table.Options.EnableCount = false;


foreach (var info in directories.OrderByDescending(x => x.Size))
{
    table.AddRow(info.DirectoryInfo.Name, TreeSizeConsole.Format(info.Size));
}

table.Write();

Environment.Exit(1);
