using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatalogFreeContent;

namespace CatalogFreeContent
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contCat, ICommand command, StringBuilder sb)
        {
            switch (command.Type)
            {
                case CommandsType.AddBook:
                    {
                        contCat.Add(new Content(ContentType.Book, command.Parameters));
                        sb.AppendLine("Books Added");
                    }
                    break;
                case CommandsType.AddMovie:
                    {
                        contCat.Add(new Content(ContentType.Film, command.Parameters));

                        sb.AppendLine("Movie added");
                    }
                    break;
                case CommandsType.AddSong:
                    {
                        contCat.Add(new Content(ContentType.Music, command.Parameters));

                        sb.Append("Song added");
                    }
                    break;
                case CommandsType.AddApplication:
                    {
                        contCat.Add(new Content(ContentType.Application, command.Parameters));

                        sb.AppendLine("Application added");
                    }
                    break;
                case CommandsType.Update:
                    {
                        if (command.Parameters.Length == 2)
                        {
                        }
                        else
                        {
                            throw new FormatException("невалидни параметри!");
                        }

                        sb.AppendLine(String.Format("{0} items updated", contCat.UpdateContent(command.Parameters[0], command.Parameters[1]) - 1));
                    }
                    break;
                case CommandsType.Find:
                    {
                        if (command.Parameters.Length != 2)
                        {
                            Console.WriteLine("Invalid params!");
                            throw new Exception("Invalid number of parameters!");
                        }

                        Int32 numberOfElementsToList = Int32.Parse(command.Parameters[1]);

                        IEnumerable<IContent> foundContent = contCat.GetListContent(command.Parameters[0], numberOfElementsToList);

                        if (foundContent.Count() == 0)
                        {
                            sb.AppendLine("No items found");
                        }
                        else
                        {
                            foreach (IContent content in foundContent)
                            {
                                sb.AppendLine(content.TextRepresentation);
                            }
                        }
                    }
                    break;
                default:
                    {
                        throw new InvalidCastException("Unknown command!");
                    }
            }
        }
    }
}