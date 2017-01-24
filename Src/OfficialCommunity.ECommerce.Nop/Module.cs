using System;
using ExpressMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Nop.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Nop
{
    public class Module : IModule
    {
        public void RegisterMappings()
        {
          
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
        }

        public void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<NopCommerceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("NopDbConnection")
                                                                                , opt => opt.UseRowNumberForPaging()));
        }

        public void Configure(IConfiguration configuration, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
        }
    }
}
