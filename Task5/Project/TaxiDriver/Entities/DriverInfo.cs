namespace TaxiDriver
{
    public class DriverInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public System.Collections.Generic.ICollection<Score> Scores { get; set; }
    }
}
