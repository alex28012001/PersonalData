using DataCollector.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.DataProviders.Repositories.Abstraction
{
    public interface IUserRepository
    {
        Task BulkInsertAsync(IEnumerable<User> users);
    }
}
