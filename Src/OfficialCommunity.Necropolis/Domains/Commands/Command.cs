using System;

namespace OfficialCommunity.Necropolis.Domains.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
        DateTime CreatedUtc { get; }
        string MachineName { get; }
    }

    public abstract class Command : ICommand
    {
        public Guid Id { get; private set; }
        public DateTime CreatedUtc { get; private set; }

        public string MachineName { get; private set; }

        protected Command()
        {
            Id = Guid.NewGuid();
            CreatedUtc = DateTime.UtcNow;
            MachineName = Environment.MachineName;
        }
    }
}