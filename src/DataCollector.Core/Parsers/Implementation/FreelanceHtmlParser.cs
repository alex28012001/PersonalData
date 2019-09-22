using AngleSharp.Html.Parser;
using DataCollector.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCollector.Common.Helpers;
using DataCollector.Core.Parsers.Abstraction;
using AngleSharp.Html.Dom;

namespace DataCollector.Core.Parsers.Implementation
{
    /// <summary>
    /// The class contains logic of parsing html to User entity.
    /// For Freelance.ru sources.
    /// </summary>
    public class FreelanceHtmlParser : BaseHtmlParser
    {
        protected override Task<CommonInfo> ParseCommonInfoAsync(IHtmlDocument document)
        {
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

            return Task.FromResult(commonInfo);
        }

        protected override Task<Contacts> ParseContactsAsync(IHtmlDocument document)
        {
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

            return Task.FromResult(contacts);
        }

        protected override Task<Activities> ParseActivitiesAsync(IHtmlDocument document)
        {
            var hobbies = document.QuerySelectorAll(".specli").SelectMany(p => p.TextContent.Split(" / "));

            var activities = new Activities()
            {
                Hoobies = hobbies,
                Books = Enumerable.Empty<string>(),
                Films = Enumerable.Empty<string>(),
                Games = Enumerable.Empty<string>(),
                Musics = Enumerable.Empty<string>()
            };

            return Task.FromResult(activities);
        }

        protected override Task<IEnumerable<Education>> ParseEducationAsync(IHtmlDocument document)
        {
            var educations = Enumerable.Empty<Education>();
            return Task.FromResult(educations);
        }

        protected override Task<IEnumerable<Сareer>> ParseCareerAsync(IHtmlDocument document)
        {
            var careers = Enumerable.Empty<Сareer>();
            return Task.FromResult(careers);
        }

        protected override Task<LifePositions> ParseLifePositionAsync(IHtmlDocument document)
        {
            var lifePosition = new LifePositions();
            return Task.FromResult(lifePosition);
        }
    }
}
