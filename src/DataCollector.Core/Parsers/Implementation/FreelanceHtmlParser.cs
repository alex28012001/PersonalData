using AngleSharp.Html.Parser;
using DataCollector.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCollector.Common.Helpers;
using DataCollector.Core.Parsers.Abstraction;

namespace DataCollector.Core.Parsers.Implementation
{
    /// <summary>
    /// The class contains logic of parsing html to User entity.
    /// For Freelance.ru sources.
    /// </summary>
    public class FreelanceHtmlParser : BaseHtmlParser
    {
        protected override async Task<CommonInfo> ParseCommonInfoAsync(string html)
        {
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(html);

            var fullName = document.QuerySelector(".name a").TextContent;
            var parsedName = fullName.Split(" ");
            string lastName;
            parsedName.TryGet(1, out lastName);

            var city = document.QuerySelector(".bage_city")?.TextContent;

            var commonInfo = new CommonInfo()
            {
                FirstName = parsedName[0],
                LastName = lastName,
                City = city,
                Gender = Models.Entities.Common.Gender.Unknown
            };

            return commonInfo;
        }

        protected override async Task<Contacts> ParseContactsAsync(string html)
        {
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(html);

            var mobilePhone = document.QuerySelector(".phone")?.TextContent;
            var email = document.QuerySelector(".email")?.TextContent;
            var skype = document.QuerySelector(".skype")?.TextContent;
            var vk = document.QuerySelector(".vkontakte")?.TextContent;
            var instagram = document.QuerySelector(".instagram")?.TextContent;

            var contacts = new Contacts()
            {
                MobilePhone = mobilePhone,
                Email = email,
                Skype = skype,
                Vk = vk,
                Instagram = instagram
            };

            return contacts;
        }

        protected override async Task<Activities> ParseActivitiesAsync(string html)
        {
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(html);

            var hobbies = document.QuerySelectorAll(".specli").SelectMany(p => p.TextContent.Split(" / "));

            var activities = new Activities()
            {
                Hoobies = hobbies,
                Books = Enumerable.Empty<string>(),
                Films = Enumerable.Empty<string>(),
                Games = Enumerable.Empty<string>(),
                Musics = Enumerable.Empty<string>()
            };

            return activities;
        }

        protected override Task<IEnumerable<Education>> ParseEducationAsync(string html)
        {
            var educations = Enumerable.Empty<Education>();
            return Task.FromResult(educations);
        }

        protected override Task<IEnumerable<Сareer>> ParseCareerAsync(string html)
        {
            var careers = Enumerable.Empty<Сareer>();
            return Task.FromResult(careers);
        }

        protected override Task<LifePositions> ParseLifePositionAsync(string html)
        {
            var lifePosition = new LifePositions();
            return Task.FromResult(lifePosition);
        }
    }
}
