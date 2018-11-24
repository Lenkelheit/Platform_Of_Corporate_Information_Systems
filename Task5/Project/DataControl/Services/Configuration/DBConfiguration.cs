namespace DataControl.Services
{
    /// <summary>
    /// Represents database configuration.
    /// </summary>
    public class DBConfiguration : Interfaces.IConfiguration
    {
        /// <summary>
        /// It enables to work with different entities from database.
        /// </summary>
        public TaxiDriver.Services.UnitOfWork UnitOfWork { get; set; }
    }
}
