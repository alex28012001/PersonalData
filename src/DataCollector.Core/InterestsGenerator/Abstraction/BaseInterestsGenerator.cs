using DataCollector.Models.Entities;
using System;
using System.Collections.Generic;

namespace DataCollector.Core.InterestsGenerator.Abstraction
{
    /// <summary>
    /// The class contains structure creating user interests.
    /// </summary>
    public abstract class BaseInterestsGenerator : IInterestsGenerator
    {
        ///<inheritdoc />
        public Interests GenerateInterests(Activities activities)
        {
            if(activities == null)
            {
                throw new ArgumentNullException(nameof(activities));
            }

            var typesOfBooks = GenerateTypesOfBooks(activities.Books);
            var typesOfFilms = GenerateTypesOfFilms(activities.Films);
            var typesOfGames = GenerateTypesOfGames(activities.Games);
            var typesOfMusic = GenerateTypesOfMusic(activities.Musics);
            var hobbies = GenerateHobbies(activities.Groups);

            var interests = new Interests()
            {
                TypesOfBooks = typesOfBooks,
                TypesOfFilms = typesOfFilms,
                TypesOfGames = typesOfGames,
                TypesOfMusic = typesOfMusic,
                Hobbies = hobbies
            };

            return interests;
        }

        protected abstract IEnumerable<string> GenerateTypesOfBooks(IEnumerable<string> bookTitles);

        protected abstract IEnumerable<string> GenerateTypesOfFilms(IEnumerable<string> filmTitles);

        protected abstract IEnumerable<string> GenerateTypesOfGames(IEnumerable<string> gameTitles);

        protected abstract IEnumerable<string> GenerateTypesOfMusic(IEnumerable<string> musicTitles);

        protected abstract IEnumerable<string> GenerateHobbies(IEnumerable<string> hobbyTitles);
    }
}
