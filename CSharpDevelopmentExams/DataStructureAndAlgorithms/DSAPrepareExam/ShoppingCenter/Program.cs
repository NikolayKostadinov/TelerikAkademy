using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShoppingCenter
{
    public class Program
    {
        public static void Main()
        {
            var output = new StringBuilder();
            var catalog = new Catalog();
            ICommandExecutor c = new CommandExecutor();

            var commands = ParseCommands();
            foreach (var command in commands)
            {
                c.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output);
        }

        private static IEnumerable<ICommand> ParseCommands()
        {
            var commandList = new List<ICommand>();
#if DEBUG
            string line;
            using (StreamReader reader = new StreamReader(@"..\..\test1.txt"))
            {
                line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    commandList.Add(new Command(line));
                }
            }
#else
            while (true)
            {
                var line = Console.ReadLine();
                if (line != null && line.Trim() == "End")
                {
                    break;
                }
                commandList.Add(new Command(line));
            }
#endif

            return commandList;
        }
    }
}