using System.Data.Entity;

namespace TaxiDriver.Context
{
    public class DriverContext : DbContext
    {
        // CONSTRUCTORS
        public DriverContext()
            : base("TaxiDtiverDB")  {  }

        // PROPERTIES
        public DbSet<DriverInfo> Drivers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}
