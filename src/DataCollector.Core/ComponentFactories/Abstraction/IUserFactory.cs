using DataCollector.Core.Providers;
using DataCollector.Core.SourcesGenerator.Abstraction;

namespace DataCollector.Core.ComponentFactories.Abstraction
{
    /// <summary>
    /// The interface provides creating components for creating user entity.
    /// </summary>
    public interface IUserFactory
    {
        /// <summary>
        /// Create source generator.
        /// </summary>
        /// <returns>The implementation of ISourcesGenerator interface.</returns>
        ISourcesGenerator CreateSourcesGenerator();

        /// <summary>
        /// Create User provider.
        /// </summary>
        /// <returns>The implementation of IUserProvider interface.</returns>
        IUserProvider CreateUserProvider();
    }
}
