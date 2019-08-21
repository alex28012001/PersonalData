using DataCollector.Core.InterestsGenerator.Abstraction;
using DataCollector.Core.Settings;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCollector.Core.InterestsGenerator.Implementation
{
    /// <summary>
    /// The class provides default logic of genereating interests.
    /// </summary>
    public class DefaultInterestsGenerator : BaseInterestsGenerator
    {
        /// <summary>
        /// Initialize <see cref="DefaultInterestsGenerator"/>
        /// </summary>
        /// <param name="interestsGeneratorConstansts">Contains constants for generating interests.</param>
        public DefaultInterestsGenerator(IOptions<InterestsGeneratorConstansts> interestsGeneratorConstansts)
            : base(interestsGeneratorConstansts.Value)
        {

        }

        protected override Task<IEnumerable<string>> GenerateHobbiesAsync(IEnumerable<string> groupsTitles)
        {
            var emptyCollection = Enumerable.Empty<string>();
            return Task.FromResult(emptyCollection);
        }
    }
}
