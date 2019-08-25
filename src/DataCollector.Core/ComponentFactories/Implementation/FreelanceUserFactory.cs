using DataCollector.Core.ComponentFactories.Abstraction;
using DataCollector.Core.Parsers.Implementation;
using DataCollector.Core.Providers;
using DataCollector.Core.SourcesGenerator.Abstraction;
using DataCollector.Core.SourcesGenerator.Implementation;

namespace DataCollector.Core.ComponentFactories.Implementation
{
    /// <summary>
    /// The class provides creating Freelance components for creating user entity. 
    /// </summary>
    public class FreelanceUserFactory : IUserFactory
    {
        ///<inheritdoc />
        public ISourcesGenerator CreateSourcesGenerator()
        {
            return new FreelanceSourcesGenerator();
        }

        ///<inheritdoc />
        public IUserProvider CreateUserProvider()
        {
            return new FreelanceHtmlParser();
        }
    }
}
