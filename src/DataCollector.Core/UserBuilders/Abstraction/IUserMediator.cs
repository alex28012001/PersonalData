using DataCollector.Models.Entities;

namespace DataCollector.Core.UserBuilders.Abstraction
{
    public interface IUserMediator
    {
        User GenerateUsers();
    }
}
