using DataCollector.Models.Entities;
using MongoDB.Driver;

namespace DataCollector.Models.Context
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
    }
}
