using DataCollector.Models.Entities;
using DataCollector.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.DataProviders.Repositories
{
    /// <summary>
    /// The class provides work with user entity.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _db;
        public UserRepository(IDbContext db)
        {
            _db = db;
        }

        ///<inheritdoc />
        public async Task BulkInsertAsync(IEnumerable<User> users)
        {   
            await _db.Users.InsertManyAsync(users);
        }
    }
}
