using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Disclaimer: This code is still awful (slightly better though), no time - sorry for that :)

namespace CatalogFreeContent
{
    public class CatalogApp
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            List<ICommand> commandsToExecute = GetCommandsInput(); 

            foreach (ICommand command in commandsToExecute)
            {
                commandExecutor.ExecuteCommand(catalog, command, output); 
            }

            Console.Write(output);
        }

        private static List<ICommand> GetCommandsInput()
        {
            List<ICommand> commandsToExecute = new List<ICommand>();
            bool end = false;

            do
            {
                string input = Console.ReadLine();
                end = (input.Trim() == "End");
                if (!end)
                {
                    commandsToExecute.Add(new Command(input));
                }
            }
            while (!end);

            return commandsToExecute;
        }
    }
}
