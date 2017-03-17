namespace Bash
{
    internal interface ICommandSubscriber
    {
        string GetName();
        void ExecuteCommand(Command c);
    }
}