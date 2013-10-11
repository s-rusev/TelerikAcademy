using System;
using System.Text;

namespace CatalogFreeContent
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output);
    }
}
