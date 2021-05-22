using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using DataCollector.Common.Helpers;
using DataCollector.Models.Interfaces;
using DataCollector.Models.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.Core.SourcesGenerator
{
    /// <summary>
    /// The class provides generating urls.
    /// </summary>
    public class FreelanceSourcesGenerator : ISourcesGenerator
    {
        /// <summary>
        /// Generate urls.
        /// </summary>
        /// <param name="count">The count needed sources.</param>
        /// <param name="skip">The count skiped sources.</param>
        /// <returns>The collection of urls.</returns>
        public async Task<IEnumerable<string>> GenerateAsync(int count, int skip = 0)
        {
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

            var page = skipedPages + 1;
            IHtmlCollection<IElement> htmlElements = null;

            do
            {
                var pageUrl = string.Format(UrlConstants.FreelancePageUrlTemplate, page);
                var pageHtml = await HttpReader.ReadAsync(pageUrl);
                var document = parser.ParseDocument(pageHtml);
                htmlElements = document.QuerySelectorAll(".user-info > a");

                for (int i = skipedItems; i < htmlElements.Length; i++)
                {
                    if (urls.Count < count)
                    {
                        var userUrl = htmlElements[i].GetAttribute("href");
                        urls.Add(userUrl);
                    }
                }

                skipedItems = 0;
                page++;
            }
            while (htmlElements.Length > 0 && urls.Count < count);

            return urls;
        } 
    }
}
