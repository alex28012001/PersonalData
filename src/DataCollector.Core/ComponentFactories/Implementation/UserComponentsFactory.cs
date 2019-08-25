using DataCollector.Core.ComponentFactories.Abstraction;
using DataCollector.Core.ComponentFactories.Implementation;

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
        /// <param name="title">The title of resource where from getting data.</param>
        /// <returns>The implementation of IUserFactory</returns>
        public static IUserFactory CreateUserFactory(string title)
        {
            IUserFactory userFactory = null;

            switch (title)
            {
                case "freelance.ru": userFactory = new FreelanceUserFactory(); break;
            }

            return userFactory;
        }
    }
}
