using DataCollector.DataProviders.Repositories.Abstraction;
using DataCollector.Models.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Linq;

namespace DataCollector.DataProviders.Repositories.Implementation
{
    public class CitiRepository : BaseRepository, ICityRepository
    {
        public CitiRepository(string connectionString)
            : base(connectionString)
        {
        }

        public async Task<City> GetByCityAsync(string city)
        {
            var filter = Builders<City>.Filter.Eq(p => p.CityRU, city);

            var cursor = await Db.Cities.FindAsync(filter);
            await cursor.MoveNextAsync();

            return cursor.Current.SingleOrDefault();
        }
    }
}
