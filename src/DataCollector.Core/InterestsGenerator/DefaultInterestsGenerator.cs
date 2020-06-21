using DataCollector.Models.Settings;
using Microsoft.Extensions.Options;

namespace DataCollector.Core.InterestsGenerator
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
    }
}
