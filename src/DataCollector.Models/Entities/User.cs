using System.Collections.Generic;

namespace DataCollector.Models.Entities
{
    /// <summary>
    /// The class contains user information.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The contains common information.
        /// </summary>
        public CommonInfo CommonInfo { get; set; }

        /// <summary>
        /// The contains contacts.
        /// </summary>
        public Contacts Contacts { get; set; }

        /// <summary>
        /// The contains info about education.
        /// </summary>
        public IEnumerable<Education> Education { get; set; }

        /// <summary>
        /// The contains info about career.
        /// </summary>
        public IEnumerable<Сareer> Сareer { get; set; }

        /// <summary>
        /// The contains info about life positions.
        /// </summary>
        public LifePositions LifePositions { get; set; }

        /// <summary>
        /// The contains info about interests.
        /// </summary>
        public Interests Interests { get; set; }
    }
}
