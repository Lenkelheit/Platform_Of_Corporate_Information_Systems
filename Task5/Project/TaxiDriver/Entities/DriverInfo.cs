namespace TaxiDriver
{
    /// <summary>
    /// Represents class that entities DriverInfo
    /// </summary>
    public class DriverInfo
    {
        /// <summary>
        /// Property that defines the identifier
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Property that defines the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property that defines the password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Property that defines the collection of scores
        /// </summary>
        public System.Collections.Generic.ICollection<Score> Scores { get; set; }
    }
}
