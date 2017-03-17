using System;
using static System.String;

namespace Bash
{
    internal class Pwd : ICommandSubscriber
    {
        public string GetName()
        {
            return "pwd";
        }

        public void ExecuteCommand(Command c)
        {
            var currentDirectory = c.Bash.CurrentDirectory.Parent;
            string path = c.Bash.CurrentDirectory.Name;

            while (currentDirectory != null)
            {
                if (currentDirectory == c.Bash.HomeDirectory)
                {
                    path = "/" + path;
                    break;
                }
                path = currentDirectory.Name + "/" + path;
                currentDirectory = currentDirectory.Parent;
            }

            Console.WriteLine(path);
        }
    }
}