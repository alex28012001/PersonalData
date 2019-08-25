using MongoDB.Bson;

namespace DataCollector.Models.Entities
{
    /// <summary>
    /// The class contains city information.
    /// </summary>
    public class City : IMongoEntity
    {
        /// <summary>
        /// Contains record identificator for mongoDb.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Contains coutry title on english language.
        /// </summary>
        public string CountryEN { get; set; }

        /// <summary>
        /// Contains region title on english language.
        /// </summary>
        public string RegionEN { get; set; }

        /// <summary>
        /// Contains city title on english language.
        /// </summary>
        public string CityEN { get; set; }

        /// <summary>
        /// Contains coutry title on russian language.
        /// </summary>
        public string CountryRU { get; set; }

        /// <summary>
        /// Contains region title on russian language.
        /// </summary>
        public string RegionRU { get; set; }

        /// <summary>
        /// Contains city title on russian language.
        /// </summary>
        public string CityRU { get; set; }
    }
}
