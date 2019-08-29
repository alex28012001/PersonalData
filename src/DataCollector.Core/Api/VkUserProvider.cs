using DataCollector.Core.Api.Mappers.Abstraction;
using DataCollector.Core.Providers;
using System;
using System.Linq;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

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
            if(userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var correctUserId = Convert.ToInt64(userId);
            var vkUsers = await _vkApi.Users.GetAsync(new long[] { correctUserId }, ProfileFields.All);
            var vkUser = vkUsers.Single();

            var user = _userMapper.MapToUser(vkUser);
            return user;
        }
    }
}
