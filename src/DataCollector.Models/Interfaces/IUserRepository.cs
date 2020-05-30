using DataCollector.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.Models.Interfaces
{
    /// <summary>
    /// The inteface provides work with user entity.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Insert collection of user through bulk technology.
        /// </summary>
        /// <param name="users">List of user entity</param>
        /// <returns>The Task</returns>
        Task BulkInsertAsync(IEnumerable<User> users);
    }
}
