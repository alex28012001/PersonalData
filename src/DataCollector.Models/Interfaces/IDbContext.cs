using DataCollector.Models.Entities;
using MongoDB.Driver;

namespace DataCollector.Models.Interfaces
{
    /// <summary>
    /// The interface provides with database.
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Contains list of user entity.
        /// </summary>
        IMongoCollection<User> Users { get; }

        /// <summary>
        /// Contains list of city entity.
        /// </summary>
        IMongoCollection<City> Cities { get; }
    }
}
