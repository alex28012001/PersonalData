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
        /// Contains needed data for user creating components, can be null.
        /// </summary>
        public object Data { get; set; }
    }
}
