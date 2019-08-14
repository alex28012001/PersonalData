using DataCollector.Models.Entities;
using MongoDB.Driver;

namespace DataCollector.Models.Context
{
    public interface IDbContext
    {
        IMongoCollection<User> Users { get; }
    }
}
