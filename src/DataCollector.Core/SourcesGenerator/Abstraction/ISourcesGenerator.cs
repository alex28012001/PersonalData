using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.Core.SourcesGenerator.Abstraction
{
    /// <summary>
    /// The interface provides generating sources.
    /// </summary>
    public interface ISourcesGenerator
    {
        /// <summary>
        /// Generate sources.
        /// </summary>
        /// <param name="amount">The count needed sources.</param>
        /// <param name="skip">The count skiped sources.</param>
        /// <returns>The collection of sources.</returns>
        Task<IEnumerable<string>> GenerateAsync(int count, int skip = 0);
    }
}
