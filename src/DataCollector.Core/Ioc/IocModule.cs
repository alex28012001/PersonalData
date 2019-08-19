using DataCollector.Core.Services.Abstraction;
using DataCollector.Core.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace DataCollector.Core.Ioc
{
    public static class IocModule
    {
        public static void AddCoreServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}
