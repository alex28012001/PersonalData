using DataCollector.DataProviders.Repositories.Abstraction;
using DataCollector.Models.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.DataProviders.Repositories.Implementation
{
    /// <summary>
    /// The class provides work with user entity.
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString)
            : base(connectionString)
        {
        }

        ///<inheritdoc />
        public async Task BulkInsertAsync(IEnumerable<User> users)
        {
            var bulkCollection = new List<WriteModel<User>>();

            foreach (var user in users)
            {
                var insertModel = new InsertOneModel<User>(user);
                bulkCollection.Add(insertModel);
            }

            await Db.Users.BulkWriteAsync(bulkCollection);
        }
    }
}
