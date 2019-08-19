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
        /// Generate sources by template.
        /// </summary>
        /// <param name="template">The template source.</param>
        /// <returns>The collection of sources.</returns>
        Task<IEnumerable<string>> GenerateAsync(string template, int amount, int skip = 0);
    }
}
