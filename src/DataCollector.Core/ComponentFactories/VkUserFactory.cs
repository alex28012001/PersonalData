using DataCollector.Core.Api;
using DataCollector.Core.Api.Mappers;
using DataCollector.Core.SourcesGenerator;
using DataCollector.Core.SourcesValidator.Implementation;
using DataCollector.Models.Interfaces;

namespace DataCollector.Core.ComponentFactories
{
    /// <summary>
    /// The class provides creating vk components for creating user entity. 
    /// </summary>
    public class VkUserFactory : IUserFactory
    {
        private readonly string _accessToken;
        public VkUserFactory(string accessToken)
        {
            _accessToken = accessToken;
        }

        ///<inheritdoc />
        public ISourcesGenerator CreateSourcesGenerator()
        {
            return new VkSourcesGenerator();
        }

        ///<inheritdoc />
        public ISourcesValidator CreateSourcesValidator()
        {
            return new VkSourcesValidator(_accessToken);
        }

        ///<inheritdoc />
        public IUserProvider CreateUserProvider()
        {
            var vkUserProvider = new VkUserProvider(_accessToken, new VkUserMapper());
            var trottlingDecorator = new TrottlingDecorator(vkUserProvider, 1500);

            return trottlingDecorator;
        }
    }
}
