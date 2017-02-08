using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Domains.Infrastructure
{
    public interface IServiceFactory
    {
        IStandardResponse<T> GetServiceInstance<T>(Guid key, Dictionary<string, string> configuration)
            where T : IService;
    }

    public abstract class ServiceFactory : IServiceFactory
    {
        private readonly ILogger _logger;
        private readonly Dictionary<string, IService> _services = new Dictionary<string, IService>(); 

        protected ServiceFactory(ILogger logger)
        {
            _logger = logger;
        }

        protected abstract IList<IService> GetServices();

        public IStandardResponse<T> GetServiceInstance<T>(Guid key, Dictionary<string, string> configuration) where T : IService
        {
            throw new NotImplementedException();
        }
    }

    public class FulfillmentServiceFactory : ServiceFactory
    {
        private readonly ILogger<FulfillmentServiceFactory> _logger;

        protected FulfillmentServiceFactory(ILogger<FulfillmentServiceFactory> logger)
            : base(logger)
        {
            _logger = logger;
        }

        protected override IList<IService> GetServices()
        {
            throw new NotImplementedException();
        }
    }
}
