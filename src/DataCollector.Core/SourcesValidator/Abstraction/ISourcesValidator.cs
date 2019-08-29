using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.Core.SourcesValidator.Abstraction
{
    /// <summary>
    /// The interface contains logic of validate sources.
    /// </summary>
    public interface ISourcesValidator
    {
        /// <summary>
        /// Validate Sources.
        /// </summary>
        /// <param name="sources">The collection of source.</param>
        /// <returns>The collection of validated sources.</returns>
        Task<IEnumerable<string>> ValidateAsync(IEnumerable<string> sources);
    }
}
