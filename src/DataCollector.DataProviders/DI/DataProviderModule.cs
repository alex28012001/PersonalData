using DataCollector.DataProviders.Repositories;
using DataCollector.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataCollector.DataProviders.DI
{
    public static class DataProviderModule
    {
        public static void AddDataProviderServices(this IServiceCollection serviceCollection)
        {       
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<ICityRepository, CityRepository>();
        }
    }
}
