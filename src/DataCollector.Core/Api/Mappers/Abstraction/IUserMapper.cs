using DataCollector.Models.Entities;

namespace DataCollector.Core.Api.Mappers.Abstraction
{
    public interface IUserMapper<TSource>
    {
        User MapToUser(TSource source);
    }
}
