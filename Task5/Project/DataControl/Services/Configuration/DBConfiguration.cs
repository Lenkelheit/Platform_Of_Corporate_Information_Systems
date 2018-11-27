namespace DataControl.Services
{
    /// <summary>
    /// Represents database configuration.
    /// </summary>
    public class DBConfiguration : Interfaces.IConfiguration, System.IDisposable
    {
        // FIELDS
        private bool disposedValue;

        // PROPERTIES
        /// <summary>
        /// It enables to work with different entities from database.
        /// </summary>
        public TaxiDriver.Services.UnitOfWork UnitOfWork { get; set; }

        // CONSTRUCTOR DESTRUCTOR
        /// <summary>
        /// Basic constructor with parameter.
        /// </summary>
        /// <param name="connectionStringName">The name of connection string.</param>
        public DBConfiguration(string connectionStringName)
        {
            UnitOfWork = new TaxiDriver.Services.UnitOfWork(connectionStringName);
            disposedValue = false;
        }
        /// <summary>
        /// Default finaliser
        /// </summary>
        ~DBConfiguration()
        {
            Dispose(false);
        }

        // METHODS
        /// <summary>
        /// Disposes unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            System.GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Special disposer.
        /// </summary>
        /// <param name="disposing">Says what resources must be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    UnitOfWork.Dispose();
                    UnitOfWork = null;
                }
                disposedValue = true;
            }
        }
    }
}
