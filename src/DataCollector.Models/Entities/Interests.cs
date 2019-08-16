using System.Collections.Generic;

namespace DataCollector.Models.Entities
{
    /// <summary>
    /// The class contains user interests.
    /// </summary>
    public class Interests
    {
        /// <summary>
        /// Contains the liked types of books.
        /// </summary>
        public IEnumerable<string> TypeOfBooks { get; set; }

        /// <summary>
        /// Contains the liked types of films.
        /// </summary>
        public IEnumerable<string> TypesOfFilms { get; set; }

        /// <summary>
        /// Contains the liked types of games.
        /// </summary>
        public IEnumerable<string> TypeOfGames { get; set; }

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
