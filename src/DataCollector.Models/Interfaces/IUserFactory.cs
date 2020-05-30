namespace DataCollector.Models.Interfaces
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
        /// Create source validator.
        /// </summary>
        /// <returns>The implementation of ISourcesValidator interface.</returns>
        ISourcesValidator CreateSourcesValidator();

        /// <summary>
        /// Create User provider.
        /// </summary>
        /// <returns>The implementation of IUserProvider interface.</returns>
        IUserProvider CreateUserProvider();
    }
}
