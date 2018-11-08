namespace DataControl.Services
{
    /// <summary>
    /// Represents file configuration.
    /// </summary>
    public class FileConfiguration : Interfaces.IConfiguration
    {
        /// <summary>
        /// Path to file with information about clients.
        /// </summary>
        public string ClientFile { get; set; }
        /// <summary>
        /// Path to file with information about streets.
        /// </summary>
        public string StreetFile { get; set; }
        /// <summary>
        /// Path to file with information about routes.
        /// </summary>
        public string RouteFile { get; set; }
        /// <summary>
        /// Path to file with information about drivers.
        /// </summary>
        public string DriverFile { get; set; }
        /// <summary>
        /// Path to file with information about scores.
        /// </summary>
        public string ScoreFile { get; set; }
    }
}
