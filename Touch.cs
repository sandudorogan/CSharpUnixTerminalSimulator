using System;

namespace Bash
{
    internal class Touch : ICommandSubscriber
    {
        public string GetName()
        {
            return "touch";
        }

        public void ExecuteCommand(Command c)
        {
            string[] parts = c.CommandLine.Trim().Split();

            if (c.Bash.CurrentDirectory.HasChild(parts[1].Trim()))
            {
                Console.WriteLine("[{0}] Error: Entry allready exists.", parts[1].Trim());
            }

            c.Bash.CurrentDirectory.AddChild(new LocalFile(parts[1], c.Bash.CurrentDirectory));
        }
    }
}
