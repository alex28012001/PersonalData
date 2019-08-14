using DataCollector.Models.Entities.Common;
using System;

namespace DataCollector.Models.Entities
{
    /// <summary>
    /// The class contains user common information.
    /// </summary>
    public class CommonInfo
    {
        /// <summary>
        /// Contains the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Contains the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Contains the gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Contains the date of birthday.
        /// </summary>
        public DateTime? DateBirthday { get; set; }

        /// <summary>
        /// Contains the age.
        /// </summary>
        public int? Age => (DateTime.UtcNow - DateBirthday)?.Days / 365;

        /// <summary>
        /// Contains the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Contains the city.
        /// </summary>
        public string City { get; set; }
    }
}
