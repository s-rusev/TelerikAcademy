using System;
using System.Linq;

namespace QualityEvents
{
    public class Program
    {
        private static readonly EventHolder events = new EventHolder();

        static void Main(string[] args)
        {
            while (ExecuteNextCommand())
            {
            }

            Console.WriteLine(Messages.Output);
        }

        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();
            
            if (command.StartsWith("AddEvent"))
            {
                AddEvent(command);
                return true;
            }

            if (command.StartsWith("DeleteEvents"))
            {
                DeleteEvents(command);
                return true;
            }

            if (command.StartsWith("ListEvents"))
            {
                ListEvents(command);
                return true;
            }

            if (command.StartsWith("Exit"))
            {
                return false;
            }

            return true;
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            string countString = command.Substring(pipeIndex + 1);
            DateTime date = GetDate(command, "ListEvents");
            int count = int.Parse(countString);
            events.ListEvents(date, count); // from the EventHolder class
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            events.DeleteEvents(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            GetParameters(command, "AddEvent", out date, out title, out location);
            events.AddEvent(date, title, location);
        }

        private static void GetParameters(string commandForExecution, string commandType, 
                                            out DateTime dateAndTime, out string eventTitle,
                                            out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = "";
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 19));
            return date;
        }
    }
}