namespace Bash
{
    internal class Command
    {
        public Bash Bash { get; }

        public string CommandLine { get; }

        public Command(Bash bash, string commandLine)
        {
            Bash = bash;
            CommandLine = commandLine;
        }
    }
}