namespace DataCollector.Core.Settings
{
    /// <summary>
    /// The class contains information about source.
    /// </summary>
    public class SourceInfo
    {
        /// <summary>
        /// Contains title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Contains template.
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Contains max generated users at a time. 
        /// It's needed because before saved users they located in memory.
        /// If this property will be biggest than your memoty in computer, then app crashed! 
        /// </summary>
        public int MaxGeneratedUsers { get; set; }
    }
}
