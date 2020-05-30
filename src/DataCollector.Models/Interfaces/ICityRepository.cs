using DataCollector.Models.Entities;
using System.Threading.Tasks;

namespace DataCollector.Models.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetByCityAsync(string city);
    }
}
