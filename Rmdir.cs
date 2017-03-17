using System;

namespace Bash
{
    internal class Rmdir : ICommandSubscriber
    {
        public string GetName()
        {
            return "rmdir";
        }

        public void ExecuteCommand(Command c)
        {
            string[] tokens = c.CommandLine.Split();

            if (!c.Bash.CurrentDirectory.HasChild(tokens[1]))
            {
                Console.WriteLine("[{0}] Error: Child not found.", tokens[1]);
                return;
            }

            if (c.Bash.CurrentDirectory.GetChild(tokens[1]) is LocalFile)
            {
                Console.WriteLine("[{0}] Error: Not a folder", tokens[1]);
            }
            else
            {
                c.Bash.CurrentDirectory.RemoveChild(new LocalDirectory(tokens[1], c.Bash.CurrentDirectory));
            }
        }
    }
}
