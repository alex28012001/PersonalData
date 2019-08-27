using DataCollector.Core.ComponentFactories.Abstraction;
using DataCollector.Core.ComponentFactories.Implementation;
using DataCollector.Core.Settings;

namespace DataCollector.Core.UserBuilders.Implementation
{
    /// <summary>
    /// The class contain logic of choosing and creating implementation of IUserFactory.
    /// </summary>
    public static class UserComponentsFactory
    {
        /// <summary>
        /// Choose implementation of IUserFactory by title and creating her.
        /// </summary>
        /// <param name="source">The source where from getting data.</param>
        /// <returns>The implementation of IUserFactory</returns>
        public static IUserFactory CreateUserFactory(SourceInfo source)
        {
            IUserFactory userFactory = null;

            switch (source.Title)
            {
                case "freelance.ru": userFactory = new FreelanceUserFactory(); break;
                case "vk.com": userFactory = new VkUserFactory((string)source.Data); break;
            }

            return userFactory;
        }
    }
}
