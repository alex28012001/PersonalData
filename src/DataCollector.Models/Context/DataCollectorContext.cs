using DataCollector.Models.Entities;
using MongoDB.Driver;
using System;

namespace DataCollector.Models.Context
{
    public class DataCollectorContext : IDbContext
    {
        private readonly IMongoDatabase _db;

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

        public IMongoCollection<User> Users
        {
            get
            {
                return _db.GetCollection<User>("Users");
            }
        }
    }
}
