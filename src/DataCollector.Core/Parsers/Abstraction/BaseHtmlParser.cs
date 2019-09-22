using System;
using DataCollector.Models.Entities;
using System.Collections.Generic;
using DataCollector.Common.Helpers;
using System.Threading.Tasks;
using DataCollector.Core.Providers;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;

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
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(html);

            var commonInfoTask = ParseCommonInfoAsync(document);
            var contactsTask = ParseContactsAsync(document);
            var careerTask = ParseCareerAsync(document);
            var educationTask = ParseEducationAsync(document);
            var lifePositionTask = ParseLifePositionAsync(document);
            var activitiesTask = ParseActivitiesAsync(document);

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

        protected abstract Task<CommonInfo> ParseCommonInfoAsync(IHtmlDocument document);

        protected abstract Task<Contacts> ParseContactsAsync(IHtmlDocument document);

        protected abstract Task<IEnumerable<Сareer>> ParseCareerAsync(IHtmlDocument document);

        protected abstract Task<IEnumerable<Education>> ParseEducationAsync(IHtmlDocument document);
   
        protected abstract Task<LifePositions> ParseLifePositionAsync(IHtmlDocument document);

        protected abstract Task<Activities> ParseActivitiesAsync(IHtmlDocument document);
    }
}
