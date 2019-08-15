using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using DataCollector.Common.Helpers;
using DataCollector.Core.UrlGenerator.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.Core.UrlGenerator.Implementation
{
    /// <summary>
    /// The class provides generating urls.
    /// </summary>
    public class FreelanceUrlReader : IUrlGenerator
    {
        ///<inheritdoc />
        public async Task<IEnumerable<string>> GenerateAsync(string urlTemplate)
        {
            if(urlTemplate == null)
            {
                throw new ArgumentNullException();
            }

            var urls = new List<string>();
            var parser = new HtmlParser();

            IHtmlCollection<IElement> htmlElements = null;
            var page = 1;

            do
            {
                var url = string.Format(urlTemplate, page);
                var pageHtml = await HtmlReader.ReadAsync(url);
                var document = parser.ParseDocument(pageHtml);

                htmlElements = document.QuerySelectorAll(".userinfo_small .avatar a");

                foreach (var tag in htmlElements)
                {
                    urls.Add(tag.GetAttribute("href"));
                }

                page++;
            }
            while (htmlElements.Length > 0);

            return urls;
        }
    }
}
