using DataCollector.Models.Entities;
using DataCollector.Models.Interfaces;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace DataCollector.DataProviders.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly IDbContext _db;
        public CityRepository(IDbContext db)
        {
            _db = db;
        }

        public async Task<City> GetByCityAsync(string city)
        {
            var filter = Builders<City>.Filter.Eq(p => p.CityRU, city);

            var cursor = await _db.Cities.FindAsync(filter);
            await cursor.MoveNextAsync();

            return cursor.Current.SingleOrDefault();
        }
    }
}
