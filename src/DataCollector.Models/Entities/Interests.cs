using System.Collections.Generic;

namespace DataCollector.Models.Entities
{
    /// <summary>
    /// The class contains user interests.
    /// </summary>
    public class Interests
    {
        /// <summary>
        /// Contains the liked books.
        /// </summary>
        public IEnumerable<string> Books { get; set; }

        /// <summary>
        /// Contains the liked films.
        /// </summary>
        public IEnumerable<string> Films { get; set; }

        /// <summary>
        /// Contains the liked games.
        /// </summary>
        public IEnumerable<string> Games { get; set; }

        /// <summary>
        /// Contains the liked types of music.
        /// </summary>
        public IEnumerable<string> TypesOfMusic { get; set; }

        /// <summary>
        /// Contains the hobbies.
        /// </summary>
        public IEnumerable<string> Hobbies { get; set; }
    }
}
