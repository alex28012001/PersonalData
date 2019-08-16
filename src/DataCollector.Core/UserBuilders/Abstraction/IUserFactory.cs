using DataCollector.Core.Providers;
using DataCollector.Core.UrlGenerator.Abstraction;

namespace DataCollector.Core.UserBuilders.Abstraction
{
    /// <summary>
    /// The interface provides creating components for creating user entity.
    /// </summary>
    public interface IUserFactory
    {
        /// <summary>
        /// Create url generator.
        /// </summary>
        /// <returns>The implementation of IUrlGenerator interface.</returns>
        IUrlGenerator CreateUrlGenerator();

        /// <summary>
        /// Create User provider.
        /// </summary>
        /// <returns>The implementation of IUserProvider interface.</returns>
        IUserProvider CreateUserProvider();
    }
}
