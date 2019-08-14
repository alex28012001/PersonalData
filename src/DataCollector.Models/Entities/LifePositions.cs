namespace DataCollector.Models.Entities
{
    /// <summary>
    /// The class contains user life positions.
    /// </summary>
    public class LifePositions
    {
        /// <summary>
        /// Contains the world view.
        /// </summary>
        public string WorldView { get; set; }

        /// <summary>
        /// Contains the opinion about main in life.
        /// </summary>
        public string MainInLife { get; set; }

        /// <summary>
        /// Contains the opinion about main in people.
        /// </summary>
        public string MainInPeople { get; set; }

        /// <summary>
        /// Contains the position to sigarets.
        /// </summary>
        public string PositionToSigarets { get; set; }

        /// <summary>
        /// Contains the position to alhocol.
        /// </summary>
        public string PositionToAlhocol { get; set; }
    }
}
