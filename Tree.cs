using System;

namespace Bash
{
    internal class Tree : ICommandSubscriber
    {
        public string GetName()
        {
            return "tree";
        }

        public void ExecuteCommand(Command c)
        {
            ShowTree(c.Bash.CurrentDirectory, 0);
        }

        private void ShowTree(LocalDirectory directory, int nrOfTabs)
        {
            string directoryTabs = new string('\t', nrOfTabs);
            Console.WriteLine(directoryTabs + directory.Name);

            foreach (var entryChild in directory.Children)
            {
                if (entryChild is LocalFile)
                {
                    string fileTabs = new string('\t', nrOfTabs + 1);
                    Console.WriteLine(fileTabs + entryChild.Name);
                }
                else
                {
                    ShowTree((LocalDirectory) entryChild, nrOfTabs + 1);
                }
            }
        }
    }
}
