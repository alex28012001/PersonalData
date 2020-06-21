using DataCollector.Core.InterestsGenerator;
using DataCollector.Core.Services;
using DataCollector.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataCollector.Core.DI
{
    public static class CoreModule
    {
        public static void AddCoreServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IInterestsGenerator, DefaultInterestsGenerator>();
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}
