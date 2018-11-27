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

        private bool disposedValue;
        // CONSTRUCTOR DESTRUCTOR
        /// <summary>
        /// Basic constructor with parameter.
        /// </summary>
        /// <param name="connectionStringName">The name of connection string.</param>
        public UnitOfWork(string connectionStringName)
        {
            db = new Context.DriverContext(connectionStringName);
            clientRepository = new GenericRepository<Client>(db);
            driverInfoRepository = new GenericRepository<DriverInfo>(db);
            routeRepository = new GenericRepository<Route>(db);
            scoreRepository = new GenericRepository<Score>(db);
            streetRepository = new GenericRepository<Street>(db);
            disposedValue = false;
        }
        /// <summary>
        /// Default finaliser
        /// </summary>
        ~UnitOfWork()
        {
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
        /// <summary>
        /// Save changes in data base
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }
        /// <summary>
        /// Dispose resourses
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
                    db.Dispose();
                    db = null;
                }
                disposedValue = true;
            }
        }
    }
}
