using System;
using DataCollector.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataCollector.Core.Models;

namespace DataCollector.Core.Services.Abstraction
{
    /// <summary>
    /// The interface contains logic of generating users by sources info.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Generating users by sources info.
        /// </summary>
        /// <param name="sourcesInfo">The source title and him template.</param>
        /// <returns>The task.</returns>
        Task GeneratingUsersAsync(IEnumerable<SourceData> sourcesInfo);

        /// <summary>
        /// The event, which called when user generated.
        /// </summary>
        event Action<User> GeneratedUser;
    }
}
