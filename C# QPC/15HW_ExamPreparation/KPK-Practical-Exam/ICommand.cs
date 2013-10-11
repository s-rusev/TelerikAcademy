using System;

namespace CatalogFreeContent
{
    public interface ICommand
    {
        CommandsType Type { get; set; }

        string OriginalForm { get; set; }

        string Name { get; set; }

        string[] Parameters { get; set; }

        CommandsType ParseCommandType(string commandName);

        string ParseName();

        string[] ParseParameters();
    }
}
