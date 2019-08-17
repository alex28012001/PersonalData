using DataCollector.Core.Models;
using DataCollector.Core.Services.Abstraction;
using DataCollector.Core.UserBuilders.Implementation;
using DataCollector.DataProviders.Repositories.Abstraction;
using DataCollector.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.Core.Services.Implementation
{
    /// <summary>
    /// The class contains logic of generating users by sources info.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializing <see cref="UserService"/>
        /// </summary>
        /// <param name="userRepository">The repository, which provides work with user entity.</param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        ///<inheritdoc />
        public event Action<User> GeneratedUser;

        ///<inheritdoc />
        public async Task GeneratingUsersAsync(IEnumerable<SourceData> sourcesInfo)
        {
            if (sourcesInfo == null)
            {
                throw new ArgumentNullException(nameof(sourcesInfo));
            }

            var users = new List<User>();

            foreach (var sourceInfo in sourcesInfo)
            {
                var componentsFactory = UserComponentsFactory.CreateUserFactory(sourceInfo.Title);

                var sourcesGenerator = componentsFactory.CreateSourcesGenerator();
                var userProvider = componentsFactory.CreateUserProvider();

                var sources = await sourcesGenerator.GenerateAsync(sourceInfo.Template);

                foreach (var source in sources)
                {
                    var user = userProvider.CreateUser(source);

                    GeneratedUser?.Invoke(user);
                    users.Add(user);
                }
            }
            await _userRepository.BulkInsertAsync(users);
        }
    }
}
