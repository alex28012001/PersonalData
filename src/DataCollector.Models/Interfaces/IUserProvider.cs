using DataCollector.Models.Entities;
using System.Threading.Tasks;

namespace DataCollector.Models.Interfaces
{
    /// <summary>
    /// The interface contains logic of creating user entity.
    /// </summary>
    public interface IUserProvider
    {
        /// <summary>
        /// Create user by data.
        /// </summary>
        /// <param name="data">The data, which needed for creating user entity.</param>
        /// <returns>The user entity.</returns>
        Task<User> CreateUserAsync(string data);
    }
}
