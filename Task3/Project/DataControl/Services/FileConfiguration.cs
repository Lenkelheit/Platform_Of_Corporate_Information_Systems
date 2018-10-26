namespace DataControl.Services
{
    public class FileConfiguration : Interfaces.IConfiguration
    {
        public string ClientFile { get; set; }
        public string StreetFile { get; set; }
        public string RouteFile { get; set; }
        public string DriverFile { get; set; }
        public string ScoreFile { get; set; }
    }
}
