using DataCollector.Core.DI;
using DataCollector.Core.Settings;
using DataCollector.DataProviders.Context;
using DataCollector.DataProviders.DI;
using DataCollector.Models.Interfaces;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.Shell.ConsoleUI
{
    class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));

        static async Task Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;

            try
            {
                await RunApp();
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }
        }

        private static async Task RunApp()
        {
            ConfigureLogger();

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
            serviceCollection.AddScoped<IDbContext, DataCollectorContext>(p => new DataCollectorContext(connectionString));

            serviceCollection.AddCoreServices();
            serviceCollection.AddDataProviderServices();
        }

        public static void ConfigureLogger()
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            var logRepository = LogManager.GetRepository(callingAssembly);

            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}
