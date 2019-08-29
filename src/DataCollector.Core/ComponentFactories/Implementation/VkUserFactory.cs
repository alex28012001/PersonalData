using DataCollector.Core.Api;
using DataCollector.Core.Api.Mappers.Implementation;
using DataCollector.Core.ComponentFactories.Abstraction;
using DataCollector.Core.Providers;
using DataCollector.Core.SourcesGenerator.Abstraction;
using DataCollector.Core.SourcesGenerator.Implementation;
using DataCollector.Core.SourcesValidator.Abstraction;
using DataCollector.Core.SourcesValidator.Implementation;

namespace DataCollector.Core.ComponentFactories.Implementation
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
            var trottlingDecorator = new TrottlingDecorator(vkUserProvider, 333);

            return trottlingDecorator;
        }
    }
}
