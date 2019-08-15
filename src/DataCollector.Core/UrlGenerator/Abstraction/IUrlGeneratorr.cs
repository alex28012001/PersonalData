using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.Core.UrlGenerator.Abstraction
{
    /// <summary>
    /// The interface provides generating urls.
    /// </summary>
    public interface IUrlGenerator
    {
        /// <summary>
        /// Generate urls by url template.
        /// </summary>
        /// <param name="urlTemplate">The web site url template.</param>
        /// <returns>The Collection of url.</returns>
        Task<IEnumerable<string>> GenerateAsync(string urlTemplate);
    }
}
