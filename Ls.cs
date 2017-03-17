using System;

namespace Bash
{
    internal class Ls : ICommandSubscriber
    {
        public string GetName()
        {
            return "ls";
        }

        public void ExecuteCommand(Command c)
        {
            foreach (var currentDirectoryChild in c.Bash.CurrentDirectory.Children)
            {
                Console.Write("{0, 7}", currentDirectoryChild.Name);
            }

            Console.WriteLine();
        }
    }
}
