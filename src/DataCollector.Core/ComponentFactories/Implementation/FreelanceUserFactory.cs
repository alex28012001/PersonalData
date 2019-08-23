using DataCollector.Core.ComponentFactories.Abstraction;
using DataCollector.Core.Parsers.Implementation;
using DataCollector.Core.Providers;
using DataCollector.Core.SourcesGenerator.Abstraction;
using DataCollector.Core.SourcesGenerator.Implementation;

namespace DataCollector.Core.ComponentFactories.Implementation
{
    public class FreelanceUserFactory : IUserFactory
    {
        public ISourcesGenerator CreateSourcesGenerator()
        {
            return new FreelanceSourcesGenerator();
        }

        public IUserProvider CreateUserProvider()
        {
            return new FreelanceHtmlParser();
        }
    }
}
