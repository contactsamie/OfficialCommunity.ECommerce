using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IService
    {
        string Name { get; }
        Guid Key { get; }

        IEnumerable<string> ConfigurationProperties();
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

        public abstract IEnumerable<string> ConfigurationProperties();
    }
}
