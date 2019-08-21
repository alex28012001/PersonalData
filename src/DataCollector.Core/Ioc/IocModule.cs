using DataCollector.Core.InterestsGenerator.Abstraction;
using DataCollector.Core.InterestsGenerator.Implementation;
using DataCollector.Core.Services.Abstraction;
using DataCollector.Core.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace DataCollector.Core.Ioc
{
    public static class IocModule
    {
        public static void AddCoreServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IInterestsGenerator, DefaultInterestsGenerator>();
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}
