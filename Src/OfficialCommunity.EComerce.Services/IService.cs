using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Domains.Services;

namespace OfficialCommunity.ECommerce.Services
{
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
    }

    [Serializable]
    public abstract class ServiceFactory<T> : ServiceBase, IServiceFactory<T>
        where T : class, IService
    {
        protected ServiceFactory(string name, Guid key)
            : base(name,key)
        {
        }

        public abstract IEnumerable<string> ConfigurationProperties();
        public abstract Task<IStandardResponse<T>> GetInstance(string passport
                    , Dictionary<string, string> properties
        );
    }
}
