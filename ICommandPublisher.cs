namespace Bash
{
    internal interface ICommandPublisher
    {
        void Subscribe(ICommandSubscriber subscriber);

        void Publish(Command command);
    }
}