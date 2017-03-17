using System;

namespace Bash
{
    internal class Cd : ICommandSubscriber
    {
        public string GetName()
        {
            return "cd";
        }

        public void ExecuteCommand(Command c)
        {
            var currentDirectory = c.Bash.CurrentDirectory;

            if (c.CommandLine.Trim().EndsWith(".."))
            {
                if (currentDirectory.Parent != null)
                {
                    c.Bash.CurrentDirectory = currentDirectory.Parent;
                }
            }
            else
            {
                if (c.CommandLine.StartsWith("/"))
                {
                    var iteratorDirectory = c.Bash.HomeDirectory;
                    string[] directoryStrings = c.CommandLine.Substring(3).Trim(' ', '/').Split('/');

                    foreach (var directoryString in directoryStrings)
                    {
                        if (iteratorDirectory.HasChild(directoryString))
                        {
                            if (iteratorDirectory.GetChild(directoryString) is LocalDirectory)
                            {
                                iteratorDirectory = (LocalDirectory) iteratorDirectory.GetChild(directoryString);
                            }
                            else
                            {
                                Console.WriteLine("[{0}] Error: Not a folder.", directoryString);
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("[{0}] Error: Child not found.", directoryString);
                            return;
                        }
                    }

                    c.Bash.CurrentDirectory = iteratorDirectory;
                }
                if (c.CommandLine.StartsWith("."))
                {
                    var iteratorDirectory = c.Bash.HomeDirectory;
                    string[] directoryStrings = c.CommandLine.Substring(3).Trim(' ', '/').Split('/');

                    foreach (var directoryString in directoryStrings)
                    {
                        if (directoryString.Equals(".."))
                        {
                            if (iteratorDirectory.Equals(c.Bash.HomeDirectory))
                            {
                                Console.WriteLine("[{0}] Error: Wrong path.", directoryString);
                            }
                            else
                            {
                                iteratorDirectory = iteratorDirectory.Parent;
                            }
                        }
                        else
                        {
                            if (iteratorDirectory.HasChild(directoryString))
                            {
                                if (iteratorDirectory.GetChild(directoryString) is LocalDirectory)
                                {
                                    iteratorDirectory = (LocalDirectory)iteratorDirectory.GetChild(directoryString);
                                }
                                else
                                {
                                    Console.WriteLine("[{0}] Error: Not a folder.", directoryString);
                                    return;
                                }
                            }
                            else
                            {
                                Console.WriteLine("[{0}] Error: Child not found.", directoryString);
                                return;
                            }
                        }
                    }
                }
                else //A child folder requested.
                {
                    if (!currentDirectory.HasChild(c.CommandLine.Substring(3))) return;

                    if (currentDirectory.GetChild(c.CommandLine.Substring(3)) is LocalDirectory)
                    {
                        c.Bash.CurrentDirectory =
                            (LocalDirectory) currentDirectory.GetChild(c.CommandLine.Substring(3));
                    }
                    else
                    {
                        Console.WriteLine("[{0}] Error: Not a folder.", c.CommandLine.Substring(3));
                    }
                }
            }
        }
    }
}
