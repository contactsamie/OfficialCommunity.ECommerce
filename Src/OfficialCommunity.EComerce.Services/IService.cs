using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IServiceBase
    {
        string Name { get; }
        Guid Key { get; }
    }

    public interface IService : IServiceBase
    {
    }

    public interface IServiceFactory : IServiceBase
    {
        IEnumerable<string> ConfigurationProperties();
    }

    public interface IFufillmentServiceFactory : IServiceFactory
    {
        Task<IStandardResponse<IFulfillmentService>> GetInstance(string passport
                    , Dictionary<string, string> properties
        );
    }

    public interface IStoreServiceFactory : IServiceFactory
    {
        Task<IStandardResponse<IStoreService>> GetInstance(string passport
                    , Dictionary<string, string> properties
        );
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
    }

    [Serializable]
    public abstract class ServiceFactory : ServiceBase, IServiceFactory
    {
        protected ServiceFactory(string name, Guid key)
            : base(name,key)
        {
        }

        public abstract IEnumerable<string> ConfigurationProperties();
    }
}
