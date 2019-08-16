using MongoDB.Bson;
using System.Collections.Generic;

namespace DataCollector.Models.Entities
{
    /// <summary>
    /// The class contains user information.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Contains record identificator for mongoDb.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Contains common information.
        /// </summary>
        public CommonInfo CommonInfo { get; set; }

        /// <summary>
        /// Contains contacts.
        /// </summary>
        public Contacts Contacts { get; set; }

        /// <summary>
        /// Contains info about education.
        /// </summary>
        public IEnumerable<Education> Education { get; set; }

        /// <summary>
        /// Contains info about career.
        /// </summary>
        public IEnumerable<Сareer> Сareer { get; set; }

        /// <summary>
        /// Contains info about life positions.
        /// </summary>
        public LifePositions LifePositions { get; set; }

        /// <summary>
        /// Contains user activities.
        /// </summary>
        public Activities Activities { get; set; }

        /// <summary>
        /// Contains info about interests.
        /// </summary>
        public Interests Interests { get; set; }
    }
}
