using DataCollector.Models.Entities;

namespace DataCollector.Core.Providers
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
        User CreateUser(string data);
    }
}
