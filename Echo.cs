using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bash
{
    class Echo : ICommandSubscriber
    {
        public string GetName()
        {
            return "echo";
        }

        public void ExecuteCommand(Command c)
        {
            if (c.CommandLine.Contains('>'))
            {
                string[] parts = c.CommandLine.Split('>');
                string fileName = parts[1].Trim();
                if (c.Bash.CurrentDirectory.HasChild(fileName))
                {
                    if (c.Bash.CurrentDirectory.GetChild(fileName) is LocalDirectory)
                    {
                        Console.WriteLine("[{0}] Error: Cannot write in a directory.", fileName);
                    }
                    else
                    {
                        ((LocalFile) c.Bash.CurrentDirectory.GetChild(fileName)).Content =
                            parts[0].Substring(4).Trim(' ', '"');
                    }

                }
                else
                {
                    Console.WriteLine("[{0,1}] Error: No such file.", fileName);
                }
            }
            else
            {
                Console.WriteLine(c.CommandLine.Substring(4).Trim(' ', '"'));
            }
        }
    }
}