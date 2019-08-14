using DataCollector.Models.Context;

namespace DataCollector.DataProviders.Repositories.Abstraction
{
    public abstract class BaseRepository
    {
        protected readonly IDbContext _db;

        //todo: change connectionString on IOptions<ConnectionConstants>
        public BaseRepository(string connectionString)
        {
            _db = new DataCollectorContext(connectionString);
        }
    }
}
