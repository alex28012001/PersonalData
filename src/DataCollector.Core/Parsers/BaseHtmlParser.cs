using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using DataCollector.Common.Helpers;
using DataCollector.Models.Entities;
using DataCollector.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.Core.Parsers
{
    /// <summary>
    /// The class provides structure creating user entity through parsing html.
    /// </summary>
    public abstract class BaseHtmlParser : IUserProvider
    {
        /// <summary>
        /// Create user entity by html.
        /// </summary>
        /// <param name="url">The web site url.</param>
        /// <returns>The user entity.</returns>
        public async Task<User> CreateUserAsync(string url)
        {
            if(url == null)
            {
                 throw new ArgumentNullException(nameof(url));
            }

            var html = await HttpReader.ReadAsync(url);
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(html);

            var commonInfo = ParseCommonInfo(document);
            var contacts = ParseContacts(document);
            var career = ParseCareer(document);
            var education = ParseEducation(document);
            var lifePosition = ParseLifePosition(document);
            var activities = ParseActivities(document);

            var user = new User()
            {
                CommonInfo = commonInfo,
                Contacts = contacts,
                Сareer = career,
                Education = education,
                LifePositions = lifePosition,
                Activities = activities
            };

            return user;
        }

        protected abstract CommonInfo ParseCommonInfo(IHtmlDocument document);

        protected abstract Contacts ParseContacts(IHtmlDocument document);

        protected abstract IEnumerable<Сareer> ParseCareer(IHtmlDocument document);

        protected abstract IEnumerable<Education> ParseEducation(IHtmlDocument document);
   
        protected abstract LifePositions ParseLifePosition(IHtmlDocument document);

        protected abstract Activities ParseActivities(IHtmlDocument document);
    }
}
