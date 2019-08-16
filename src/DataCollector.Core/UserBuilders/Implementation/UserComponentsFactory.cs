using DataCollector.Core.UserBuilders.Abstraction;
using System;

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
            //todo: after added concrete implementations IUserFactory, make logic of choosing implementation by title

            throw new NotImplementedException();
        }
    }
}
