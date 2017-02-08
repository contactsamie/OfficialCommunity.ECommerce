using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IServiceBase
    {
        string Name { get; }
        Guid Key { get; }
    }

    public interface IService : IServiceBase
    {
        IEnumerable<string> ConfigurationProperties();
    }

    public interface IServiceFactory : IServiceBase
    {
    }

    [Serializable]
    public abstract class ServiceBase : IServiceBase
    {
        protected ServiceBase(string name, Guid key)
        {
            Name = name;
            Key = key;
        }

        public string Name { get; private set; }
        public Guid Key { get; private set; }
    }

    [Serializable]
    public abstract class Service : ServiceBase, IService
    {
        protected Service(string name, Guid key)
            : base(name,key)
        {
        }

        public abstract IEnumerable<string> ConfigurationProperties();
    }

    [Serializable]
    public abstract class ServiceFactory : ServiceBase, IServiceFactory
    {
        protected ServiceFactory(string name, Guid key)
            : base(name,key)
        {
        }
    }
}
