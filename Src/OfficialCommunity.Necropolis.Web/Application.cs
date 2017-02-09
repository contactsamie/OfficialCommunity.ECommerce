using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ExpressMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using Scrutor;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OfficialCommunity.Necropolis.Web
{
    public static class Application
    {
        private static IList<IModule> _modules;

        public static void Startup(IConfigurationBuilder configurationBuilder)
        {
            var assemblies = GetAssemblies();

            var moduleCollection = new ServiceCollection();

            moduleCollection.Scan(scan => scan.FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo<IModule>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime()
            );

            var moduleServiceProvider = moduleCollection.BuildServiceProvider();

            _modules = moduleServiceProvider.GetServices<IModule>().ToList();

            foreach (var module in _modules)
            {
                module.RegisterMappings();
                module.ConfigureConfiguration(configurationBuilder);
            }

            Mapper.Compile();
        }

        public static void ConfigureServices(IConfiguration configuration
            , IServiceCollection services)
        {
            foreach (var module in _modules)
            {
                module.ConfigureServices(configuration, services);
            }
        }

        public static void Configure(IConfiguration configuration
            , IServiceProvider serviceProvider
            , ILoggerFactory loggerFactory)
        {
            foreach (var module in _modules)
            {
                module.Configure(configuration, serviceProvider,loggerFactory);
            }
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            var assemblies = new List<Assembly>
            {
                Assembly.GetEntryAssembly()
            };

            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var d = new DirectoryInfo(path);
            var files = d.GetFiles("OfficialCommunity.*.dll");

            assemblies.AddRange(files.Select(fileInfo => Assembly.LoadFile(fileInfo.FullName)).ToList());

            return assemblies;
        }
    }
}
