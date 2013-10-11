using System;
using System.Linq;
using System.Text;

namespace CatalogFreeContent
{
    public class Command : ICommand
    {
        readonly char[] paramsSeparators = { ';' };
        readonly char commandEnd = ':';

        public CommandsType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();

            this.Parse();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        public CommandsType ParseCommandType(string commandName)
        {
            CommandsType commandType;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException();
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    {
                        commandType = CommandsType.AddBook;
                    }
                    break;
                case "Add movie":
                    {
                        commandType = CommandsType.AddMovie;
                    }
                    break;
                case "Add song":
                    {
                        commandType = CommandsType.AddSong;
                    }
                    break;
                case "Add application":
                    {
                        commandType = CommandsType.AddApplication;
                    }
                    break;
                case "Update":
                    {
                        commandType = CommandsType.Update;
                    }
                    break;
                case "Find":
                    {
                        commandType = CommandsType.Find;
                    }
                    break;
                default:
                    {
                        throw new ArgumentException("Invalid command name!");
                    }
            }

            return commandType;
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);

            string[] parameters = paramsOriginalForm.Split(paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(commandEnd) ;

            return endIndex;
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.Name + " ");

            foreach (string param in this.Parameters)
            {
                result.Append(param + " ");
            }

            return result.ToString();
        }
    }
}