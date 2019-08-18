using DataCollector.Core.Services.Abstraction;
using DataCollector.Core.Services.Implementation;
using DataCollector.Core.Settings;
using DataCollector.DataProviders.Repositories.Abstraction;
using DataCollector.DataProviders.Repositories.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace DataCollector.Shell.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceollection = new ServiceCollection();
            ConfigureServices(serviceollection);

            var serviceProvider = serviceollection.BuildServiceProvider();

            var userService = serviceProvider.GetService<IUserService>();
            userService.GeneratingUsersAsync().Wait();
        }

        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(@"C:\Users\star4\Documents\DataCollector\src\DataCollector.Shell.ConsoleUI\appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("MongoDbConnection");

            serviceCollection.AddOptions();
           
            serviceCollection.Configure<SourcesConfig>(configuration.GetSection("SourcesConfig"));

            serviceCollection.AddScoped<IUserRepository>(p => new UserRepository(connectionString));
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}
