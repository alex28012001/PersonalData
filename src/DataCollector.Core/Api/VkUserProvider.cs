using DataCollector.Core.Api.Mappers.Abstraction;
using DataCollector.Core.Providers;
using System;
using System.Linq;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace DataCollector.Core.Api
{
    /// <summary>
    /// The class provides creating user entity from vk.
    /// </summary>
    public class VkUserProvider : IUserProvider
    {
        private readonly VkApi _vkApi;
        private readonly IUserMapper<VkNet.Model.User> _userMapper;

        /// <summary>
        /// Initialize <see cref="VkUserProvider"/>.
        /// </summary>
        /// <param name="accessToken">Vk Acceess token for work with vk api.</param>
        /// <param name="userMapper">The mapper who mapping vk user to DataCollector user.</param>
        public VkUserProvider(string accessToken, IUserMapper<VkNet.Model.User> userMapper)
        {
            if(accessToken == null)
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            if (userMapper == null)
            {
                throw new ArgumentNullException(nameof(userMapper));
            }

            _vkApi = new VkApi();

            _vkApi.Authorize(new ApiAuthParams
            {
                AccessToken = accessToken
            });

            _userMapper = userMapper;
        }

        /// <summary>
        /// Create user by vk user id.
        /// </summary>
        /// <param name="userId">
        /// The user identificator in vk system.
        /// Example: 666
        /// </param>
        /// <returns>The user entity.</returns>
        public async Task<Models.Entities.User> CreateUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var correctUserId = Convert.ToInt64(userId);

            var userFields = ProfileFields.Domain | ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Sex | ProfileFields.Country | ProfileFields.City |
                             ProfileFields.BirthDate | ProfileFields.Contacts | ProfileFields.Connections | ProfileFields.Schools | ProfileFields.Career | ProfileFields.Education |
                             ProfileFields.StandInLife | ProfileFields.Books | ProfileFields.Movies | ProfileFields.Games | ProfileFields.Music | ProfileFields.Interests;

            var vkUsers = await _vkApi.Users.GetAsync(new long[] { correctUserId }, userFields);
            var vkUser = vkUsers.Single();
            var user = _userMapper.MapToUser(vkUser);

            await AddAdditionalUserInfoAsync(user, correctUserId);
            return user;
        }

        private async Task AddAdditionalUserInfoAsync(Models.Entities.User user, long vkUserId)
        {
            try
            {
                var userGroups = await _vkApi.Groups.GetAsync(new GroupsGetParams()
                {
                    UserId = vkUserId,
                    Extended = true,
                    Filter = GroupsFilters.Groups | GroupsFilters.Publics,
                    Fields = GroupsFields.Activity | GroupsFields.BanInfo
                });

                var validGroups = userGroups.Where(g => g.Deactivated == null && g.IsClosed.Value == VkNet.Enums.GroupPublicity.Public);
                var activities = validGroups.Select(g => g.Activity).Distinct();

                user.Activities.Hoobies = activities;
            }
            catch (GroupsListAccessDeniedException)
            {

            }
         
         
            var educations = user.Education.ToList();

            foreach (var education in educations)
            {
                if (education.Country != null)
                {
                    var countries = await _vkApi.Database.GetCountriesByIdAsync(Convert.ToInt32(education.Country));
                    education.Country = countries.Single().Title;
                }

                if (education.City != null)
                {
                    var cities = await _vkApi.Database.GetCitiesByIdAsync(Convert.ToInt32(education.City));
                    education.City = cities.Single().Title;
                }
            }

            var jobs = user.Сareer.ToList();

            foreach (var job in jobs)
            {
                if (job.Country != null)
                {
                    var countries = await _vkApi.Database.GetCountriesByIdAsync(Convert.ToInt32(job.Country));
                    job.Country = countries.Single().Title;
                }

                if (job.City != null)
                {
                    var cities = await _vkApi.Database.GetCitiesByIdAsync(Convert.ToInt32(job.City));
                    job.City = cities.Single().Title;
                }
            }

            user.Сareer = jobs;
        }
    }
}
