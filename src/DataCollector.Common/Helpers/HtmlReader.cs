using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataCollector.Common.Helpers
{
    /// <summary>
    /// The class provides reading urls.
    /// </summary>
    public static class HtmlReader 
    {
        /// <summary>
        /// Read html by urls and returned him.
        /// </summary>
        /// <param name="urls">The web site urls.</param>
        /// <returns>The collection of html.</returns>
        public static async Task<IEnumerable<string>> ReadAsync(string[] urls)
        {
            if(urls == null)
            {
                throw new ArgumentNullException(nameof(urls));
            }

            var htmlPages = new List<string>();
            var httpClient = new HttpClient();

            foreach (var url in urls)
            {
                var htmlPage = await httpClient.GetStringAsync(url);
                htmlPages.Add(htmlPage);
            }

            return htmlPages;
        }

        /// <summary>
        /// Read html by urls and returned him.
        /// </summary>
        /// <param name="urls">The web site url.</param>
        /// <returns>The html.</returns>
        public static async Task<string> ReadAsync(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            var httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }
    }
}
