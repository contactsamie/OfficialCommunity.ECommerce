using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using ExpressMapper;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using Scrutor;
using Serilog;
using Serilog.Events;

namespace OfficialCommunity.Necropolis.Console
{
    public static class Application
    {
        private static TelemetryClient _telemetryClient;

        public static IConfiguration Configuration { get; private set; }
        public static ILoggerFactory LoggerFactory { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Startup(string instrumentationKey = null)
        {
            //var path = System.IO.Directory.GetCurrentDirectory();
            //var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            var assemblies = GetAssemblies();

            var moduleCollection = new ServiceCollection();

            moduleCollection.Scan(scan => scan.FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo<IModule>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime()
            );

            var moduleServiceProvider = moduleCollection.BuildServiceProvider();

            var modules = moduleServiceProvider.GetServices<IModule>().ToList();

            foreach (var module in modules)
            {
                module.RegisterMappings();
            }
            Mapper.Compile();

            var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                ;

            ConfigureIfDebug(configurationBuilder);

            foreach (var module in modules)
            {
                module.ConfigureConfiguration(configurationBuilder);
            }

            Configuration = configurationBuilder.Build();

            var serviceProvider = new ServiceCollection()
                    .AddLogging()
                    .AddOptions()
            ;

            foreach (var module in modules)
            {
                module.ConfigureServices(Configuration,serviceProvider);
            }

            ServiceProvider = serviceProvider.BuildServiceProvider();

            if (!string.IsNullOrWhiteSpace(instrumentationKey))
            {
                _telemetryClient = new TelemetryClient()
                {
                    InstrumentationKey = instrumentationKey
                };
            }

            var loggerConfiguration = new LoggerConfiguration();

            loggerConfiguration
                .Enrich.WithThreadId()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithMachineName()
                .Enrich.FromLogContext()
                .Enrich.With<ExceptionEnricher>()
                ;

            if (!string.IsNullOrWhiteSpace(instrumentationKey))
            {
                loggerConfiguration
                    .WriteTo.ApplicationInsights(_telemetryClient
                        , SerilogHelpers.ConvertLogEventsToCustomTraceTelemetry
                        , restrictedToMinimumLevel: LogEventLevel.Information)
                    ;
            }

            Log.Logger = loggerConfiguration.CreateLogger();

            LoggerFactory = new LoggerFactory();
            LoggerFactory.AddSerilog();

            foreach (var module in modules)
            {
                module.Configure(Configuration,ServiceProvider,LoggerFactory);
            }
        }

        public static void CloseAndFlush()
        {
            Log.CloseAndFlush();

            if (_telemetryClient == null)
                return;

            _telemetryClient.Flush();
            System.Threading.Thread.Sleep(1000);
        }

        [Conditional("DEBUG")]
        private static void ConfigureIfDebug(IConfigurationBuilder configurationBuilder)
        {
            //configurationBuilder.AddUserSecrets();
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            var list = new List<string>();
            var stack = new Stack<Assembly>();

            stack.Push(Assembly.GetEntryAssembly());

            do
            {
                var asm = stack.Pop();

                yield return asm;

                foreach (var reference in asm.GetReferencedAssemblies())
                    if (!list.Contains(reference.FullName))
                    {
                        stack.Push(Assembly.Load(reference));
                        list.Add(reference.FullName);
                    }

            }
            while (stack.Count > 0);
        }
    }
}
