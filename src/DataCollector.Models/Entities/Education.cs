namespace DataCollector.Models.Entities
{
    /// <summary>
    /// The class contains information about user education.
    /// </summary>
    public class Education
    {
        /// <summary>
        /// Contains the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Contains the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Contains the title of educational institution.
        /// </summary>
        public string EducationalInstitution { get; set; }

        /// <summary>
        /// Contains the title of speciality.
        /// </summary>
        public string Speciality { get; set; }
    }
}
