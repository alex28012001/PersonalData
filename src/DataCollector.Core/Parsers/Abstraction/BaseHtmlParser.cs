using System;
using DataCollector.Models.Entities;
using System.Collections.Generic;
using DataCollector.Common.Helpers;
using System.Threading.Tasks;
using DataCollector.Core.Providers;

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

            var commonInfoTask = ParseCommonInfoAsync(html);
            var contactsTask = ParseContactsAsync(html);
            var careerTask = ParseCareerAsync(html);
            var educationTask = ParseEducationAsync(html);
            var lifePositionTask = ParseLifePositionAsync(html);
            var activitiesTask = ParseActivitiesAsync(html);

            await Task.WhenAll(commonInfoTask, contactsTask, careerTask, educationTask, lifePositionTask, activitiesTask);

            var user = new User()
            {
                CommonInfo = commonInfoTask.Result,
                Contacts = contactsTask.Result,
                Сareer = careerTask.Result,
                Education = educationTask.Result,
                LifePositions = lifePositionTask.Result,
                Activities = activitiesTask.Result
            };

            return user;
        }

        protected abstract Task<CommonInfo> ParseCommonInfoAsync(string html);

        protected abstract Task<Contacts> ParseContactsAsync(string html);

        protected abstract Task<IEnumerable<Сareer>> ParseCareerAsync(string html);

        protected abstract Task<IEnumerable<Education>> ParseEducationAsync(string html);
   
        protected abstract Task<LifePositions> ParseLifePositionAsync(string html);

        protected abstract Task<Activities> ParseActivitiesAsync(string html);
    }
}
