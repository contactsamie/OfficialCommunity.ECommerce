using System;
using Microsoft.Extensions.DependencyInjection;
using OfficialCommunity.Necropolis.Domains.Services;

namespace OfficialCommunity.Necropolis.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /*
        public static IServiceCollection AddSingletonFactory<T, TFactory>(this IServiceCollection collection)
            where T : class, IService
            where TFactory : class, IServiceFactory<T>
        {
            collection.AddTransient<TFactory>();
            return AddInternal<T, TFactory>(collection, p => p.GetRequiredService<TFactory>(), ServiceLifetime.Singleton);
        }

        /* transient and scoped variants omitted */

            /*
        private static IServiceCollection AddInternal<T, TFactory>(
            this IServiceCollection collection,
            Func<IServiceProvider, TFactory> factoryProvider,
            ServiceLifetime lifetime) where T : class where TFactory : class, IServiceFactory<T>
        {
            Func<IServiceProvider, object> factoryFunc = provider =>
            {
                var factory = factoryProvider(provider);
                return factory.Build();
            };
            var descriptor = new ServiceDescriptor(typeof(T), factoryFunc, lifetime);
            collection.Add(descriptor);
            return collection;
        }
        */
    }
}