using DataCollector.Models.Entities;
using System.Threading.Tasks;

namespace DataCollector.DataProviders.Repositories.Abstraction
{
    public interface ICityRepository
    {
        Task<City> GetByCityAsync(string city);
    }
}
