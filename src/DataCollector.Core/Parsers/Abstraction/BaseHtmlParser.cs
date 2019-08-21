using System;
using DataCollector.Core.Providers;
using DataCollector.Models.Entities;
using System.Collections.Generic;
using DataCollector.Common.Helpers;
using System.Threading.Tasks;

namespace DataCollector.Core.Parsers.Abstraction
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

            var commonInfo = ParseCommonInfo(html);
            var contacts = ParseContacts(html);
            var career = ParseCareer(html);
            var education = ParseEducation(html);
            var lifePositions = ParseLifePositions(html);
            var activities = ParseActivities(html);

            var user = new User()
            {
                CommonInfo = commonInfo,
                Contacts = contacts,
                Сareer = career,
                Education = education,
                LifePositions = lifePositions,
                Activities = activities
            };

            return user;
        }

        protected abstract CommonInfo ParseCommonInfo(string html);

        protected abstract Contacts ParseContacts(string html);

        protected abstract IEnumerable<Сareer> ParseCareer(string html);

        protected abstract IEnumerable<Education> ParseEducation(string html);
   
        protected abstract LifePositions ParseLifePositions(string html);

        protected abstract Activities ParseActivities(string html);
    }
}
