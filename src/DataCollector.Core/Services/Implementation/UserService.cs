using DataCollector.Core.Settings;
using DataCollector.Core.Services.Abstraction;
using DataCollector.Core.UserBuilders.Implementation;
using DataCollector.DataProviders.Repositories.Abstraction;
using DataCollector.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Linq;
using DataCollector.Core.InterestsGenerator.Abstraction;

namespace DataCollector.Core.Services.Implementation
{
    /// <summary>
    /// The class contains logic of generating users by sources info.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IInterestsGenerator _interestsGenerator;
        private readonly SourcesConfig _sourcesConfig;

        /// <summary>
        /// Initializing <see cref="UserService"/>.
        /// </summary>
        /// <param name="userRepository">The repository, which provides work with user entity.</param>
        /// <param name="interestsGenerator">The interests generator, he generate interests by user activities.</param>
        /// <param name="sourcesConfig">The sources configuration.</param>
        /// <exception cref="OutOfMemoryException">
        /// If memory occupied by users will be bigger than your computer memory.
        /// Check property <see cref="SourcesConfig.MaxGeneratedUsers"/>.
        /// </exception>
        public UserService(
            IUserRepository userRepository, 
            IInterestsGenerator interestsGenerator,
            IOptions<SourcesConfig> sourcesConfig)
        {
            _userRepository = userRepository;
            _interestsGenerator = interestsGenerator;
            _sourcesConfig = sourcesConfig.Value;
        }

        ///<inheritdoc />
        public event Action<User> GeneratedUser;

        ///<inheritdoc />
        public async Task GeneratingUsersAsync()
        {
            var users = new List<User>();

            foreach (var sourceInfo in _sourcesConfig.Sources)
            {
                var componentsFactory = UserComponentsFactory.CreateUserFactory(sourceInfo);

                var sourcesGenerator = componentsFactory.CreateSourcesGenerator();
                var sourcesValidator = componentsFactory.CreateSourcesValidator();
                var userProvider = componentsFactory.CreateUserProvider();


                IEnumerable<string> sources = null;
                var skip = 0;

                do
                {
                    sources = await sourcesGenerator.GenerateAsync(_sourcesConfig.MaxGeneratedUsers, skip);
                    var validatedSources = await sourcesValidator.ValidateAsync(sources);

                    foreach (var source in validatedSources)
                    {
                        var user = await userProvider.CreateUserAsync(source);
                        user.Interests = await _interestsGenerator.GenerateInterestsAsync(user.Activities);

                        GeneratedUser?.Invoke(user);
                        users.Add(user);
                    }

                    await _userRepository.BulkInsertAsync(users);

                    skip += sources.Count();
                    users.Clear();
                }
                while (sources.Count() % _sourcesConfig.MaxGeneratedUsers == 0);
            }
        }
    }
}
