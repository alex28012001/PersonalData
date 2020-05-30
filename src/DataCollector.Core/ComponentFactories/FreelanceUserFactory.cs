using DataCollector.Core.Parsers;
using DataCollector.Core.SourcesGenerator;
using DataCollector.Core.SourcesValidator;
using DataCollector.Models.Interfaces;

namespace DataCollector.Core.ComponentFactories
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
        public ISourcesValidator CreateSourcesValidator()
        {
            return new FreelanceSourcesValidator();
        }

        ///<inheritdoc />
        public IUserProvider CreateUserProvider()
        {
            return new FreelanceHtmlParser();
        }
    }
}
