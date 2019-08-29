using AngleSharp.Html.Parser;
using DataCollector.Common.Helpers;
using DataCollector.Core.SourcesGenerator.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCollector.Core.SourcesGenerator.Implementation
{
    /// <summary>
    /// The class provides generating user ids vk system.
    /// </summary>
    public class VkSourcesGenerator : ISourcesGenerator
    {
        /// <summary>
        /// Generating user ids.
        /// </summary>
        /// <param name="count">The count needed sources.</param>
        /// <param name="skip">The count skiped sources.</param>
        /// <returns>The collection of user ids.</returns>
        public async Task<IEnumerable<string>> GenerateAsync(int count, int skip = 0)
        {
            if(count < 0)
            {
                throw new ArgumentException("Count sources cannot be less 0", nameof(count));
            }

            if (skip < 0)
            {
                throw new ArgumentException("Skiped sources cannot be less 0", nameof(skip));
            }

            var start = skip == 0 ? 1 : skip + 1;
            var countVkUsers = await GetCountVkUsersAsync();

            if(start + count > countVkUsers)
            {
                return Enumerable.Empty<string>();
            }

            var userIds = Enumerable.Range(start, count).Select(id => id.ToString());
            return userIds;
        }

        private async Task<int> GetCountVkUsersAsync()
        {
            var html = await HttpReader.ReadAsync("https://vk.com/catalog.php");
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var interval = document.QuerySelectorAll(".column4 a").Last().TextContent;
            var twoNumbers = interval.Split(" - ");
            var parsedCount = twoNumbers[1].Replace(" ", string.Empty);

            return Convert.ToInt32(parsedCount);
        }
    }
}
