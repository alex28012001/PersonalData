using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataCollector.Common.Helpers
{
    /// <summary>
    /// The class provides reading urls.
    /// </summary>
    public static class HttpReader
    {
        /// <summary>
        /// Read http response content by urls and returned him.
        /// </summary>
        /// <param name="urls">The web site urls.</param>
        /// <returns>The collection of http content.</returns>
        public static async Task<IEnumerable<string>> ReadAsync(string[] urls)
        {
            if(urls == null)
            {
                throw new ArgumentNullException(nameof(urls));
            }

            var contents = new List<string>();
            var httpClient = new HttpClient();

            foreach (var url in urls)
            {
                var content = await httpClient.GetStringAsync(url);
                contents.Add(content);
            }

            return contents;
        }

        /// <summary>
        /// Read http response content by url and returned him.
        /// </summary>
        /// <param name="urls">The web site url.</param>
        /// <returns>The http content.</returns>
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
