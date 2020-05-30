using AngleSharp.Html.Dom;
using DataCollector.Common.Helpers;
using DataCollector.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataCollector.Core.Parsers
{
    /// <summary>
    /// The class contains logic of parsing html to User entity.
    /// For Freelance.ru sources.
    /// </summary>
    public class FreelanceHtmlParser : BaseHtmlParser
    {
        protected override CommonInfo ParseCommonInfo(IHtmlDocument document)
        {
            var fullName = document.QuerySelector(".name a").TextContent;
            var parsedName = fullName.Split(" ");
            var lastName = string.Empty;
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

        protected override Contacts ParseContacts(IHtmlDocument document)
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

            return contacts;
        }

        protected override Activities ParseActivities(IHtmlDocument document)
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

            return activities;
        }

        protected override IEnumerable<Education> ParseEducation(IHtmlDocument document)
        {
            return Enumerable.Empty<Education>();
        }

        protected override IEnumerable<Сareer> ParseCareer(IHtmlDocument document)
        {
            return Enumerable.Empty<Сareer>();
        }

        protected override LifePositions ParseLifePosition(IHtmlDocument document)
        {
            return new LifePositions();
        }
    }
}
