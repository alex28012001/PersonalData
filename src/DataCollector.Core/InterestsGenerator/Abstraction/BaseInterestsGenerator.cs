using DataCollector.Models.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using DataCollector.Common.Helpers;
using System.Threading.Tasks;
using DataCollector.Core.Settings;

namespace DataCollector.Core.InterestsGenerator.Abstraction
{
    /// <summary>
    /// The class contains structure and basic logic of generating interests.
    /// </summary>
    public abstract class BaseInterestsGenerator : IInterestsGenerator
    {
        private readonly InterestsGeneratorConstansts _generatorConstansts;

        /// <summary>
        /// Initialize <see cref="BaseInterestsGenerator"/>.
        /// </summary>
        /// <param name="generatorConstansts">Contains constants for generating interests.</param>
        public BaseInterestsGenerator(InterestsGeneratorConstansts generatorConstansts)
        {
            _generatorConstansts = generatorConstansts;
        }

        ///<inheritdoc />
        public async Task<Interests> GenerateInterestsAsync(Activities activities)
        {
            if(activities == null)
            {
                throw new ArgumentNullException(nameof(activities));
            }

            var typesOfBooksTask = GenerateTypesOfBooksAsync(activities.Books);
            var typesOfFilmsTask = GenerateTypesOfFilmsAsync(activities.Films);
            var typesOfGamesTask = GenerateTypesOfGamesAsync(activities.Games);
            var typesOfMusicTask = GenerateTypesOfMusicAsync(activities.Musics);

            await Task.WhenAll(typesOfBooksTask, typesOfFilmsTask, typesOfGamesTask, typesOfMusicTask);

            var interests = new Interests()
            {
                TypesOfBooks = typesOfBooksTask.Result,
                TypesOfFilms = typesOfFilmsTask.Result,
                TypesOfGames = typesOfGamesTask.Result,
                TypesOfMusic = typesOfMusicTask.Result,
            };

            return interests;
        }

        protected virtual async Task<IEnumerable<string>> GenerateTypesOfBooksAsync(IEnumerable<string> booksTitles)
        {
            if (booksTitles == null)
            {
                throw new ArgumentNullException(nameof(booksTitles));
            }

            return await GenerateGenresAsync(booksTitles, _generatorConstansts.BooksCategory);
        }

        protected virtual async Task<IEnumerable<string>> GenerateTypesOfFilmsAsync(IEnumerable<string> filmsTitles)
        {
            if(filmsTitles == null)
            {
                throw new ArgumentNullException(nameof(filmsTitles));
            }
    
            return await GenerateGenresAsync(filmsTitles, _generatorConstansts.FilmsCategory);
        }

        protected virtual async Task<IEnumerable<string>> GenerateTypesOfGamesAsync(IEnumerable<string> gamesTitles)
        {
            if (gamesTitles == null)
            {
                throw new ArgumentNullException(nameof(gamesTitles));
            }

            return await GenerateGenresAsync(gamesTitles, _generatorConstansts.GamesCategory);
        }

        protected virtual async Task<IEnumerable<string>> GenerateTypesOfMusicAsync(IEnumerable<string> musicTitles)
        {
            if (musicTitles == null)
            {
                throw new ArgumentNullException(nameof(musicTitles));
            }

            return await GenerateGenresAsync(musicTitles, _generatorConstansts.MusicCategory);
        }



        private async Task<IEnumerable<string>> GenerateGenresAsync(IEnumerable<string> itemsTitles, string category)
        {
            var listOfTypes = new List<string>();

            foreach (var itemTitle in itemsTitles)
            {    
                var searchUrl = string.Format(_generatorConstansts.SearchItemsUrlTemplate, category, itemTitle);

                var itemsJson = await HttpReader.ReadAsync(searchUrl);
                var items = JObject.Parse(itemsJson);
                var correctItemTitle = (string)items["query"]["search"][0]["title"];

                var itemUrl = string.Format(_generatorConstansts.SearchItemUrlTemplate, correctItemTitle);
                var itemJson = await HttpReader.ReadAsync(itemUrl);

                var item = JObject.Parse(itemJson);
                var itemInfo = (string)item["query"]["pages"].First.First["revisions"][0]["*"];

                var infoBlocks = itemInfo.Split("| ");
                var genreBlock = infoBlocks.First(p => p.StartsWith("Жанр"));
                var genresPattern = "[[]{2}[А-Яа-я ()|]*[]]{2}";
                var genresMatches = Regex.Matches(genreBlock, genresPattern);

                foreach (var match in genresMatches)
                {
                    var genre = match.ToString();
                    var parsedGenre = genre.Replace("[", string.Empty).Replace("]", string.Empty);
                    var index = parsedGenre.IndexOfAny(new char[] { '|', '(' });

                    if (index >= 0)
                    {
                        parsedGenre = parsedGenre.Remove(index, parsedGenre.Length - index);
                    }

                    listOfTypes.Add(parsedGenre);
                }
            }

            return listOfTypes;
        }
    }
}
