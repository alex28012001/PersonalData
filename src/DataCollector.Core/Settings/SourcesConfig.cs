using System.Collections.Generic;

namespace DataCollector.Core.Settings
{
    /// <summary>
    /// The class provides sources configuration.
    /// </summary>
    public class SourcesConfig
    {
        /// <summary>
        /// Contains collection of sources.
        /// </summary>
        public IEnumerable<SourceInfo> Sources { get; set; }
    }
}
