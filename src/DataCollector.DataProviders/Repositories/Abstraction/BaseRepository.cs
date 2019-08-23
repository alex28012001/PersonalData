using DataCollector.Models.Context;

namespace DataCollector.DataProviders.Repositories.Abstraction
{
    /// <summary>
    /// The class provides base state and functionality for repositories.
    /// </summary>
    public abstract class BaseRepository
    {
        protected IDbContext Db { get; set; }

        public BaseRepository(string connectionString)
        {
            Db = new DataCollectorContext(connectionString);
        }
    }
}
