using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Nuvango.Infrastructure;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Nuvango.Services
{
    public partial class NuvangoService
    {
        public class Factory : ServiceFactory
        {
            public Factory()
                : base(_name, _key)
            {
            }

            public async Task<IStandardResponse<IFulfillmentService>> GetInstance(
                        ILogger logger
                        , string passport
                        , Dictionary<string, string> properties
            )
            {
                var entry = EntryContext.Capture
                                            .Passport(passport)
                                            .Name(nameof(GetInstance))
                                            .EntryContext
                                        ;

                using (logger.BeginScope(entry))
                {
                    try
                    {
                        var configuration = new NuvangoConfiguration();
                        foreach (var property in typeof(NuvangoConfiguration).GetProperties(BindingFlags.Instance | BindingFlags.Public))
                        {
                            configuration.GetType().InvokeMember(property.Name,
                                BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
                                Type.DefaultBinder, obj, "MyName");
                        }

                        var session = new Session(logger);
                        var response = session.Configure(passport, configuration);

                        if (response.HasError)
                        {
                            return default(IFulfillmentService).GenerateStandardError(response.StandardError.Errors);
                        }

                        IFulfillmentService service = new NuvangoService(logger,session);

                        return service.GenerateStandardResponse();
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, nameof(GetInstance));
                        return default(IFulfillmentService).GenerateStandardError(nameof(GetInstance));
                    }
                }
            }
        }
    }
}
