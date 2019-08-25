using MongoDB.Bson;

namespace DataCollector.Models.Entities
{
    /// <summary>
    /// The inteface contains base information about mongodb entity.
    /// </summary>
    public interface IMongoEntity
    {
        /// <summary>
        /// Contains record identificator for mongoDb.
        /// </summary>
        ObjectId Id { get; set; }
    }
}
