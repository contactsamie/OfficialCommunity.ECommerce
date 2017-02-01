using System;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IService
    {
        string Name { get; }
        Guid Key { get; }
    }

    [Serializable]
    public abstract class Service : IService
    {
        protected Service(string name, Guid key)
        {
            Name = name;
            Key = key;
        }

        public string Name { get; private set; }
        public Guid Key { get; private set; }
    }
}
