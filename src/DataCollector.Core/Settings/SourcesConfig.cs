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


        /// <summary>
        /// Contains max generated users at a time. 
        /// It's needed because before saved users they located in memory.
        /// If memory occupied by users will be bigger than your computer memory, then app crashes! 
        /// </summary>
        public int MaxGeneratedUsers { get; set; }
    }
}
