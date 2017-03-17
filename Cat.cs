using System;

namespace Bash
{
    internal class Cat : ICommandSubscriber
    {
        public string GetName()
        {
            return "cat";
        }

        public void ExecuteCommand(Command c)
        {
            string[] tokens = c.CommandLine.Split();
            if (!c.Bash.CurrentDirectory.HasChild(tokens[1]))
            {
                Console.WriteLine("[{0}] Error: Child not found.", tokens[1]);
                return;
            }
            if (c.Bash.CurrentDirectory.GetChild(tokens[1]) is LocalDirectory)
            {
                Console.WriteLine("[{0}] Error: Not a file.", tokens[1]);
                return;
            }

            Console.WriteLine(((LocalFile) c.Bash.CurrentDirectory.GetChild(tokens[1])).Content);
        }
    }
}
