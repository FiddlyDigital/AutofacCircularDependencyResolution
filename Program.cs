using Autofac;
using AutofacCircDepResolution.Extensions;
using AutofacCircDepResolution.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AutofacCircDepResolution
{
    public class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            DIRegistration();
            RunTests();
        }

        public static void DIRegistration()
        {
            var builder = new ContainerBuilder();

            // Source: https://stackoverflow.com/a/48220306
            builder.Register<IServiceProvider>(context =>
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddLazyResolution();
                return serviceCollection.BuildServiceProvider();
            }).SingleInstance();

            builder.RegisterType<ItemManager>().As<IItemManager>();
            builder.RegisterType<ItemTestManager>().As<IItemTestManager>();

            Container = builder.Build();
        }

        public static void RunTests()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var itemMgr = scope.Resolve<IItemManager>();
                itemMgr.LoadAndTest();

                var itemTestMgr = scope.Resolve<IItemTestManager>();
                itemTestMgr.StandaloneTest();
            }
        }
    }
}
