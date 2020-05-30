using DataCollector.Models.Entities;

namespace DataCollector.Models.Interfaces
{
    /// <summary>
    /// The interface contains logic of mapping TSource in User entity.
    /// </summary>
    /// <typeparam name="TSource">Entity which need mapping to User entity.</typeparam>
    public interface IUserMapper<TSource>
    {
        /// <summary>
        /// Map TSource to user entity.
        /// </summary>
        /// <param name="source">Entity which need mapping.</param>
        /// <returns>The user entity.</returns>
        User MapToUser(TSource source);
    }
}
