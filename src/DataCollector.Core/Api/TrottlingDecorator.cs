using DataCollector.Models.Entities;
using DataCollector.Models.Interfaces;
using System;
using System.Threading.Tasks;

namespace DataCollector.Core.Api
{
    /// <summary>
    /// The class provides trootling logic for user proviers.
    /// </summary>
    public class TrottlingDecorator : IUserProvider
    {
        private readonly IUserProvider _userProvider;
        private readonly int _trottlingTime;

        /// <summary>
        /// Initialize <see cref="TrottlingDecorator"/>.
        /// </summary>
        /// <param name="userProvider">The user provider.</param>
        /// <param name="trottlingTime">The time which delays invoked CreateUserAsync method.</param>
        public TrottlingDecorator(IUserProvider userProvider, int trottlingTime)
        {
            if(userProvider == null)
            {
                throw new ArgumentNullException(nameof(userProvider));
            }

            if (trottlingTime < 0)
            {
                throw new ArgumentException("Trottling time cannot be less 0", nameof(trottlingTime));
            }

            _userProvider = userProvider;
            _trottlingTime = trottlingTime;
        }

        ///<inheritdoc>
        public async Task<User> CreateUserAsync(string data)
        {
            await Task.Delay(_trottlingTime);
            return await _userProvider.CreateUserAsync(data);
        }
    }
}
