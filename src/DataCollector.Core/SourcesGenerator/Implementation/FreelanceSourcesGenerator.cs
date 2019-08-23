using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using DataCollector.Common.Helpers;
using DataCollector.Core.SourcesGenerator.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.Core.SourcesGenerator.Implementation
{
    /// <summary>
    /// The class provides generating urls.
    /// </summary>
    public class FreelanceSourcesGenerator : ISourcesGenerator
    {
        /// <summary>
        /// Generate urls by template.
        /// </summary>
        /// <param name="urlTemplate">The web site url template.</param>
        /// <returns>The collection of urls.</returns>
        public async Task<IEnumerable<string>> GenerateAsync(string urlTemplate, int count, int skip = 0)
        {
            if (urlTemplate == null) 
            {
                throw new ArgumentNullException(nameof(urlTemplate));
            }

            if (count < 0) 
            {
                throw new ArgumentException("Count sources cannot be less 0", nameof(count));
            }

            if (skip < 0)
            {
                throw new ArgumentException("Skiped sources cannot be less 0", nameof(skip));
            }

            var urls = new List<string>();
            var parser = new HtmlParser();

            //32 - count items with user data on 1 page web site freelance.ru
            var countItemsOnPage = 32;
            var skipedPages = (int)Math.Floor((double)skip / countItemsOnPage);
            var skipedItems = skip - skipedPages * countItemsOnPage;

            var page = ++skipedPages;
            IHtmlCollection<IElement> htmlElements = null;

            do
            {
                var pageUrl = string.Format(urlTemplate, page);
                var pageHtml = await HttpReader.ReadAsync(pageUrl);
                var document = parser.ParseDocument(pageHtml);

                htmlElements = document.QuerySelectorAll(".user_info .name a");

                for (int i = skipedItems; i < htmlElements.Length; i++)
                {
                    var href = htmlElements[i].GetAttribute("href");
                    var userUrl = $"https://freelance.ru/{href}";

                    if (urls.Count < count)
                    {
                        urls.Add(userUrl);
                    }
                }

                page++;
            }
            while (htmlElements.Length > 0 && urls.Count < count);

            return urls;
        }
    }
}
