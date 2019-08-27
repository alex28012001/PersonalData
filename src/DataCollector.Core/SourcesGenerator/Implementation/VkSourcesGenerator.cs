using DataCollector.Core.SourcesGenerator.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;
using DataCollector.Common.Helpers;
using AngleSharp.Html.Parser;

namespace DataCollector.Core.SourcesGenerator.Implementation
{
    public class VkSourcesGenerator : ISourcesGenerator
    {
        private readonly VkApi _vkApi;

        public VkSourcesGenerator(string accessToken)
        {
            _vkApi = new VkApi();

            _vkApi.Authorize(new ApiAuthParams
            {
                AccessToken = accessToken
            });
        }

        public async Task<IEnumerable<string>> GenerateAsync(int count, int skip = 0)
        {
            if(count < 0)
            {
                throw new ArgumentException("Count sources cannot be less 0", nameof(count));
            }

            if (skip < 0)
            {
                throw new ArgumentException("Skiped sources cannot be less 0", nameof(skip));
            }

            var userIds = new List<string>();
            var start = skip == 0 ? 1 : skip;

            //Vk api can send maximum 1000 users by one request
            var maxGettingUsers = 1000;
            var countGetUsersByMax = (int)Math.Floor((double)count / maxGettingUsers);
            var countVkUsers = await GetCountVkUsersAsync();

            //First cycle send reuqests for received 1000 users 
            while (countGetUsersByMax > 0)
            {
                for (int i = 0; i < countGetUsersByMax; i++)
                {
                    var ids = Enumerable.Range(start, maxGettingUsers).Select(id => (long)id);
                    var vkUsers = await _vkApi.Users.GetAsync(ids);

                    var validUsers = vkUsers.Where(u => u.IsDeactivated == false);
                    var validIds = validUsers.Select(p => p.Id.ToString());
                    userIds.AddRange(validIds);

                    start += ids.Count();
                }

                var residue = count - userIds.Count;
                countGetUsersByMax = (int)Math.Floor((double)residue / maxGettingUsers);
            }

            //Second cycle send reuqests for received residue after first cycle
            while (userIds.Count < count && start < countVkUsers)
            {
                var residue = count - userIds.Count;
                var ids = Enumerable.Range(start, residue).Select(id => (long)id);
                var vkUsers = await _vkApi.Users.GetAsync(ids);

                var validUsers = vkUsers.Where(u => u.IsDeactivated == false);
                var validIds = validUsers.Select(p => p.Id.ToString());
                userIds.AddRange(validIds);

                start += ids.Count();
            }

            return userIds;
        }

        private async Task<int> GetCountVkUsersAsync()
        {
            var html = await HttpReader.ReadAsync("https://vk.com/catalog.php");
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var interval = document.QuerySelectorAll(".column4 a").Last().TextContent;
            var twoNumbers = interval.Split(" - ");
            var parsedCount = twoNumbers[1].Replace(" ", string.Empty);

            return Convert.ToInt32(parsedCount);
        }
    }
}
