using System;
using System.Collections.Generic;

namespace Bash
{
    public class Bash
    {
        private readonly ICommandPublisher _publisher;
        private const string Exit = "exit";

        public LocalDirectory HomeDirectory;
        public LocalDirectory CurrentDirectory;

        public Bash()
        {
            _publisher = new BashCommandPublisher();

            HomeDirectory = new LocalDirectory("/", null);
            CurrentDirectory = HomeDirectory;

            _publisher.Subscribe(new Echo());
            _publisher.Subscribe(new Cd());
            _publisher.Subscribe(new Ls());
            _publisher.Subscribe(new Touch());
            _publisher.Subscribe(new Mkdir());
            _publisher.Subscribe(new Tree());
            _publisher.Subscribe(new Pwd());
            _publisher.Subscribe(new Rm());
            _publisher.Subscribe(new Rmdir());
            _publisher.Subscribe(new Cat());
        }

        public void Start()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input != null && input.Equals(Exit))
                {
                    break;
                }

                Command command = new Command(this, input);
                _publisher.Publish(command);
            }
        }

        private class BashCommandPublisher : ICommandPublisher
        {
            private List<ICommandSubscriber> Subscribers = new List<ICommandSubscriber>();

            public void Subscribe(ICommandSubscriber subscriber)
            {
                Subscribers.Add(subscriber);
            }

            public void Publish(Command command)
            {
                string name = command.CommandLine.Split()[0];

                foreach (var subscriber in Subscribers)
                {
                    if (subscriber.GetName().Equals(name))
                    {
                        subscriber.ExecuteCommand(command);
                    }
                }
            }
        }
    }
}