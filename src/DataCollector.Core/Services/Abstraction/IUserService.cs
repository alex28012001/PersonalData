using System;
using DataCollector.Models.Entities;
using System.Threading.Tasks;

namespace DataCollector.Core.Services.Abstraction
{
    /// <summary>
    /// The interface contains logic of generating users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Generating users by sources configuration.
        /// </summary>
        /// <returns>The task.</returns>
        Task GeneratingUsersAsync();

        /// <summary>
        /// The event, which called when user generated.
        /// </summary>
        event Action<User> GeneratedUser;
    }
}
