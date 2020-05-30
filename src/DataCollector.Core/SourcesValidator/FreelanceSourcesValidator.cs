using AngleSharp.Html.Parser;
using DataCollector.Common.Helpers;
using DataCollector.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataCollector.Core.SourcesValidator
{
    /// <summary>
    /// The class contains logic of validate freelance urls.
    /// </summary>
    public class FreelanceSourcesValidator : ISourcesValidator
    {
        ///<inheritdoc />
        public async Task<IEnumerable<string>> ValidateAsync(IEnumerable<string> sources)
        {
            if(sources == null)
            {
                throw new ArgumentNullException(nameof(sources));
            }

            var validatedSources = new List<string>();

            var httpHandler = new HttpClientHandler() { Proxy = null, UseProxy = false };
            var httpClient = new HttpClient(httpHandler);

            foreach (var source in sources)
            {
                var html = await HttpReader.ReadAsync(source, httpClient);

                var parser = new HtmlParser();
                var document = await parser.ParseDocumentAsync(html);
                var userName = document.QuerySelector(".name a");

                if(userName != null)
                {
                    validatedSources.Add(source);
                }
            }

            return validatedSources;
        }
    }
}
