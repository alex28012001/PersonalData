using DataCollector.Core.Api.Mappers.Abstraction;
using DataCollector.Models.Entities;
using DataCollector.Models.Entities.Common;
using System;
using System.Linq;

namespace DataCollector.Core.Api.Mappers.Implementation
{
    public class VkUserMapper : IUserMapper<VkNet.Model.User>
    {
        public User MapToUser(VkNet.Model.User vkUser)
        {
            if (vkUser == null)
            {
                throw new ArgumentNullException(nameof(vkUser));
            }

            var user = new User()
            {
                CommonInfo = new CommonInfo()
                {
                    FirstName = vkUser.FirstName,
                    LastName = vkUser.LastName,
                    Gender = (Gender)Enum.ToObject(typeof(Gender), (int)vkUser.Sex),
                    Country = vkUser.Country?.Title,
                    City = vkUser.City?.Title,
                    DateBirthday = ParseVkBirthDay(vkUser.BirthDate)
                },

                Contacts = new Contacts()
                {
                    MobilePhone = vkUser.Contacts?.MobilePhone,
                    Skype = vkUser.Connections.Skype,
                    Facebook = vkUser.Connections.Facebook,
                    Instagram = vkUser.Connections.Instagram,
                    Twitter = vkUser.Connections.Twitter,
                    Vk = vkUser.Domain
                },

                Education = vkUser.Schools.Select(s =>
                {
                    var education = new Education()
                    {
                        EducationalInstitution = s.Name,
                        Speciality = s.Speciality
                    };

                    return education;
                }),

                Сareer = vkUser.Career.Select(c =>
                {
                    var career = new Сareer()
                    {
                        City = c.CityName,
                        PlaceOfWork = c.Company,
                        Position = c.Position
                    };

                    return career;
                }),

                LifePositions = new LifePositions()
                {
                    WorldView = vkUser.StandInLife?.Religion,
                    MainInLife = vkUser.StandInLife?.LifeMain.ToString(),
                    MainInPeople = vkUser.StandInLife?.PeopleMain.ToString(),
                    PositionToAlhocol = vkUser.StandInLife?.Alcohol.ToString(),
                    PositionToSigarets = vkUser.StandInLife?.Smoking.ToString()
                },

                Activities = new Activities()
                {
                    Books = vkUser.Books != null ? vkUser.Books.Split(',', StringSplitOptions.RemoveEmptyEntries) : Enumerable.Empty<string>(),
                    Films = vkUser.Movies != null ? vkUser.Movies.Split(',', StringSplitOptions.RemoveEmptyEntries) : Enumerable.Empty<string>(),
                    Games = vkUser.Games != null ? vkUser.Games.Split(',', StringSplitOptions.RemoveEmptyEntries) : Enumerable.Empty<string>(),
                    Musics = vkUser.Music != null ? vkUser.Music.Split(',', StringSplitOptions.RemoveEmptyEntries) : Enumerable.Empty<string>(),
                    Hoobies = vkUser.Interests != null ? vkUser.Interests.Split(',', StringSplitOptions.RemoveEmptyEntries) : Enumerable.Empty<string>()
                }
            };

            return user;
        }

        private DateTime? ParseVkBirthDay(string birthDate)
        {
            DateTime? result = null;
            DateTime tryBirthDate;

            var isParsed = DateTime.TryParseExact(birthDate, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out tryBirthDate);
            if (isParsed)
            {
                result = tryBirthDate;
            }

            return result;
        }
    }
}
