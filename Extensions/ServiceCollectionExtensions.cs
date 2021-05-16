﻿namespace AutofacCircDepResolution.Extensions
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    // Source: https://thomaslevesque.com/2020/03/18/lazily-resolving-services-to-fix-circular-dependencies-in-net-core/

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLazyResolution(this IServiceCollection services)
        {
            return services.AddTransient(typeof(Lazy<>), typeof(LazilyResolved<>));
        }
    }

    public class LazilyResolved<T> : Lazy<T>
    {
        public LazilyResolved(IServiceProvider serviceProvider) : base(serviceProvider.GetRequiredService<T>)
        {

        }
    }
}
