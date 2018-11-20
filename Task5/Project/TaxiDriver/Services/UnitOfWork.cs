using System;
using TaxiDriver.Interfaces;

namespace TaxiDriver.Services
{
    public class UnitOfWork : Interfaces.IUnitOfWork
    {
        // FIELDS
        private bool disposedValue = false; // To detect redundant calls
        // CONSTRUCTORS
         // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }
        // PROPERTIES
        public IGenericRepository<Client> ClientRepository
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<DriverInfo> DriverInfoRepository
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<Route> RouteRepository
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<Score> ScoreRepository
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<Street> StreetRepository
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // METHODS
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }    
    }
}
