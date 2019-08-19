using DataCollector.Core.Services.Abstraction;
using DataCollector.Core.Services.Implementation;
using DataCollector.Core.Settings;
using DataCollector.DataProviders.Repositories.Abstraction;
using DataCollector.DataProviders.Repositories.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DataCollector.Shell.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceollection = new ServiceCollection();
            ConfigureServices(serviceollection);
        }

        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Environment.CurrentDirectory)
               .AddJsonFile("appsettings.json")
               .Build();

            serviceCollection.AddOptions();
           
            serviceCollection.Configure<SourcesConfig>(configuration.GetSection("SourcesConfig"));
        }
    }
}
