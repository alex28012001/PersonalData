using DataCollector.Models.Entities;
using MongoDB.Driver;
using System;

namespace DataCollector.Models.Context
{
    /// <summary>
    /// The class provides work with database.
    /// </summary>
    public class DataCollectorContext : IDbContext
    {
        private readonly IMongoDatabase _db;

        /// <summary>
        /// Initialization <see cref="DataCollectorContext"/>
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        public DataCollectorContext(string connectionString)
        {
            if(connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            var client = new MongoClient(connectionString);
            var connection = new MongoUrlBuilder(connectionString);
            
            _db = client.GetDatabase(connection.DatabaseName);
        }

        /// <summary>
        /// Contains list of user entity.
        /// </summary>
        public IMongoCollection<User> Users
        {
            get
            {
                return _db.GetCollection<User>("Users");
            }
        }
    }
}
