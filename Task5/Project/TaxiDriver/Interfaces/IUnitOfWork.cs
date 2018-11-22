namespace TaxiDriver.Interfaces
{
    /// <summary>
    /// Represents interface for classes which will work with entities repository and gives away context for it
    /// </summary>
    public interface IUnitOfWork : System.IDisposable
    {
        /// <summary>
        /// Property that enable to interact with client repository
        /// </summary>
        /// <returns>Client Repository</returns>
        IGenericRepository<Client> ClientRepository { get; }
        /// <summary>
        /// Property that enable to interact with driver info repository
        /// </summary>
        /// <returns>Driver info Repository</returns>
        IGenericRepository<DriverInfo> DriverInfoRepository { get; }
        /// <summary>
        /// Property that enable to interact with route repository
        /// </summary>
        /// <returns>Route Repository</returns>
        IGenericRepository<Route> RouteRepository { get; }
        /// <summary>
        /// Property that enable to interact with score repository
        /// </summary>
        /// <returns>Score Repository</returns>
        IGenericRepository<Score> ScoreRepository { get; }
        /// <summary>
        /// Property that enable to interact with street repository
        /// </summary>
        /// <returns>Street Repository</returns>
        IGenericRepository<Street> StreetRepository { get; }
        /// <summary>
        /// Save changes in data base
        /// </summary>
        void Save();
    }
}
