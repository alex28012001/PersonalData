using DataCollector.Core.Ioc;
using DataCollector.Core.Services.Abstraction;
using DataCollector.Core.Settings;
using DataCollector.DataProviders.Repositories.Abstraction;
using DataCollector.DataProviders.Repositories.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.Shell.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.UTF8;

            Aaaa().GetAwaiter().GetResult();
        }

        private static async Task Aaaa()
        {
            var serviceollection = new ServiceCollection();
            ConfigureServices(serviceollection);

            var serviceProvider = serviceollection.BuildServiceProvider();

            var userService = serviceProvider.GetRequiredService<IUserService>();

            userService.GeneratedUser += UserService_GeneratedUser;

            await userService.GeneratingUsersAsync();
        }

        private static void UserService_GeneratedUser(Models.Entities.User obj)
        {
             Console.WriteLine($"{obj.CommonInfo.FirstName} {obj.CommonInfo.LastName} | tel:{obj.Contacts.MobilePhone} | vk:{obj.Contacts.Vk} | email:{obj.Contacts.Email} | inst:{obj.Contacts.Instagram}");
        }

        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Environment.CurrentDirectory)
               .AddJsonFile("appsettings.json")
               .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<SourcesConfig>(configuration.GetSection("SourcesConfig"));
            serviceCollection.Configure<InterestsGeneratorConstansts>(configuration.GetSection("InterestsGeneratorConstansts"));

            var connectionString = configuration.GetConnectionString("MongoDbConnection");
            serviceCollection.AddScoped<IUserRepository>(p => new UserRepository(connectionString));

            serviceCollection.AddCoreServices();
        }
    }
}
