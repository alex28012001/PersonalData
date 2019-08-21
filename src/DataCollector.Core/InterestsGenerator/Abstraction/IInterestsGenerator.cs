using DataCollector.Models.Entities;
using System.Threading.Tasks;

namespace DataCollector.Core.InterestsGenerator.Abstraction
{
    /// <summary>
    /// The inteface contains logic of generating user interests.
    /// </summary>
    public interface IInterestsGenerator
    {
        /// <summary>
        /// Generate interests by user activities.
        /// </summary>
        /// <param name="activities">The favorite user activities.</param>
        /// <returns>The interests.</returns>
        Task<Interests> GenerateInterestsAsync(Activities activities);       
    }
}