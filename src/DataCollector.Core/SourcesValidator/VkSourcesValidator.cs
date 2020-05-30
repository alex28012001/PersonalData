using DataCollector.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;

namespace DataCollector.Core.SourcesValidator.Implementation
{
    /// <summary>
    /// The class contains logic of validate vk user ids.
    /// </summary>
    public class VkSourcesValidator : ISourcesValidator
    {
        private readonly VkApi _vkApi;

        public VkSourcesValidator(string accessToken)
        {
            if(accessToken == null)
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            _vkApi = new VkApi();

            _vkApi.Authorize(new ApiAuthParams
            {
                AccessToken = accessToken
            });
        }

        ///<inheritdoc />
        public async Task<IEnumerable<string>> ValidateAsync(IEnumerable<string> sources)
        {
            if(sources == null)
            {
                throw new ArgumentNullException(nameof(sources));
            }

            if(sources.Count() == 0)
            {
                return Enumerable.Empty<string>();
            }

            var correctSources = new List<string>();
            var count = sources.Count();
            var skip = 0;

            var maxGettingUsers = 1000;
            var countGetUsersByMax = (int)Math.Floor((double)count / maxGettingUsers);
            

            var resudie = count - countGetUsersByMax * maxGettingUsers;
            var ids = sources.Skip(skip).Take(resudie).Select(id => Convert.ToInt64(id));
            var vkUsers = await _vkApi.Users.GetAsync(ids);

            var validatedUsers = vkUsers.Where(u => u.IsDeactivated == false && u.IsClosed == false);
            var validatedIds = validatedUsers.Select(p => p.Id.ToString());
            correctSources.AddRange(validatedIds);

            for (int i = 0; i < countGetUsersByMax; i++)
            {
                ids = sources.Skip(skip).Take(maxGettingUsers).Select(id => Convert.ToInt64(id));
                vkUsers = await _vkApi.Users.GetAsync(ids);

                validatedUsers = vkUsers.Where(u => u.IsDeactivated == false && u.IsClosed == false);
                validatedIds = validatedUsers.Select(p => p.Id.ToString());
                correctSources.AddRange(validatedIds);

                skip += maxGettingUsers;
            }

            return correctSources;
        }
    }
}
