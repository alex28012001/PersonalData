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
    public class VkUserProvider : IUserProvider
    {
        private readonly VkApi _vkApi;
        private readonly IUserMapper<VkNet.Model.User> _userMapper;

        public VkUserProvider(string accessToken, IUserMapper<VkNet.Model.User> userMapper)
        {
            _vkApi = new VkApi();

            _vkApi.Authorize(new ApiAuthParams
            {
                AccessToken = accessToken
            });

            _userMapper = userMapper;
        }

        public async Task<Models.Entities.User> CreateUserAsync(string userId)
        {
            var correctUserId = Convert.ToInt64(userId);
            var vkUsers = await _vkApi.Users.GetAsync(new long[] { correctUserId }, ProfileFields.All);
            var vkUser = vkUsers.Single();

            var user = _userMapper.MapToUser(vkUser);
            return user;
        }
    }
}
