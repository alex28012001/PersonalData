using DataCollector.Models.Entities;
using DataCollector.Models.Entities.Common;
using DataCollector.Models.Interfaces;
using System;
using System.Linq;

namespace DataCollector.Core.Api.Mappers
{
    /// <summary>
    /// The classs contains logic of mapping Vk user entity to DataCollector User entity.
    /// </summary>
    public class VkUserMapper : IUserMapper<VkNet.Model.User>
    {
        ///<inheritdoc />
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
                    Age = ParseAge(vkUser.BirthDate)
                },

                Contacts = new Contacts()
                {
                    MobilePhone = vkUser.MobilePhone,
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
                        Speciality = s.Speciality,
                        Country = s.Country?.ToString(),
                        City = s.City?.ToString()   
                    };

                    return education;
                }),

                Сareer = vkUser.Career.Select(c =>
                {
                    var career = new Career()
                    {
                        City = c.CityId?.ToString(),
                        Country = c.CountryId?.ToString(),
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

            var highEdication = new Education()
            {
                EducationalInstitution = vkUser.Education?.UniversityName,
                Speciality = vkUser.Education?.FacultyName
            };
            user.Education = user.Education.Concat(new Education[] { highEdication });


            return user;
        }

        private int? ParseAge(string birthDate)
        {
            DateTime? result = null;
            DateTime tryBirthDate;

            var isParsed = DateTime.TryParseExact(birthDate, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out tryBirthDate);
            if (isParsed)
            {
                result = tryBirthDate;
            }

            return result.HasValue ? (int?)((DateTime.UtcNow - result.Value).Days / 365) : null;
        }
    }
}
