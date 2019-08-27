using DataCollector.Core.Api;
using DataCollector.Core.Api.Mappers.Implementation;
using DataCollector.Core.ComponentFactories.Abstraction;
using DataCollector.Core.Providers;
using DataCollector.Core.SourcesGenerator.Abstraction;
using DataCollector.Core.SourcesGenerator.Implementation;

namespace DataCollector.Core.ComponentFactories.Implementation
{
    public class VkUserFactory : IUserFactory
    {
        private readonly string _accessToken;
        public VkUserFactory(string accessToken)
        {
            _accessToken = accessToken;
        }

        public ISourcesGenerator CreateSourcesGenerator()
        {
            return new VkSourcesGenerator(_accessToken);
        }

        public IUserProvider CreateUserProvider()
        {
            return new VkUserProvider(_accessToken, new VkUserMapper());
        }
    }
}
