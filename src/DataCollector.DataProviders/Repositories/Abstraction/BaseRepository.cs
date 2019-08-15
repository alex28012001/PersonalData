using DataCollector.Models.Context;

namespace DataCollector.DataProviders.Repositories.Abstraction
{
    /// <summary>
    /// The class provides base state and functionality for repositories.
    /// </summary>
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
