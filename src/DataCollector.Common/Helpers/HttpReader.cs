using System;
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
        /// Read http response content by url and returned him.
        /// </summary>
        /// <param name="url">The web site url.</param>
        /// <returns>The http content.</returns>
        public static async Task<string> ReadAsync(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            HttpClientHandler hch = new HttpClientHandler();
            hch.Proxy = null;
            hch.UseProxy = false;
            var client = new HttpClient(hch);

            return await client.GetStringAsync(url);
        }


        /// <summary>
        /// Read http response content by url and returned him.
        /// </summary>
        /// <param name="url">The web site url.</param>
        /// <param name="client">The http client.</param>
        /// <returns>The http content.</returns>
        public static async Task<string> ReadAsync(string url, HttpClient client)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return await client.GetStringAsync(url);
        }
    }
}
