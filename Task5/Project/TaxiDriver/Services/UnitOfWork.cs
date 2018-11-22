using System;
using TaxiDriver.Interfaces;

namespace TaxiDriver.Services
{
    /// <summary>
    /// Repsresents class that enable to work with entities repository and gives away context for it
    /// </summary>
    public class UnitOfWork : Interfaces.IUnitOfWork
    {
        // FIELDS
        GenericRepository<Client> clientRepository;
        GenericRepository<DriverInfo> driverInfoRepository;
        GenericRepository<Route> routeRepository;
        GenericRepository<Score> scoreRepository;
        GenericRepository<Street> streetRepository;
        Context.DriverContext db;

        private bool disposedValue; // To detect redundant calls
        // CONSTRUCTORS
        /// <summary>
        /// Basic costructor without parameters
        /// </summary>
        public UnitOfWork()
        {
            db = new Context.DriverContext();
            clientRepository = new GenericRepository<Client>(db);
            driverInfoRepository = new GenericRepository<DriverInfo>(db);
            routeRepository = new GenericRepository<Route>(db);
            scoreRepository = new GenericRepository<Score>(db);
            streetRepository = new GenericRepository<Street>(db);
            disposedValue = false;
        }
        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        /// <summary>
        /// Default finaliser
        /// </summary>
        ~UnitOfWork()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }
        // PROPERTIES
        /// <summary>
        /// Property that enable to interact with client repository
        /// </summary>
        /// <returns>Client Repository</returns>
        public IGenericRepository<Client> ClientRepository
        {
            get
            {
                return clientRepository;
            }
        }
        /// <summary>
        /// Property that enable to interact with driver info repository
        /// </summary>
        /// <returns>Driver info Repository</returns>
        public IGenericRepository<DriverInfo> DriverInfoRepository
        {
            get
            {
                return driverInfoRepository;
            }
        }
        /// <summary>
        /// Property that enable to interact with route repository
        /// </summary>
        /// <returns>Route Repository</returns>
        public IGenericRepository<Route> RouteRepository
        {
            get
            {
                return routeRepository;
            }
        }
        /// <summary>
        /// Property that enable to interact with score repository
        /// </summary>
        /// <returns>Score Repository</returns>
        public IGenericRepository<Score> ScoreRepository
        {
            get
            {
                return scoreRepository;
            }
        }
        /// <summary>
        /// Property that enable to interact with street repository
        /// </summary>
        /// <returns>Street Repository</returns>
        public IGenericRepository<Street> StreetRepository
        {
            get
            {
                return streetRepository;
            }
        }

        // METHODS
        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// Dispose resourses
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Save changes in data base
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }
        /// <summary>
        /// Special disposer
        /// </summary>
        /// <param name="disposing">Dispose managed resourses</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                db.Dispose();
                db = null;
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
    }
}
