namespace TaxiDriver.Interfaces
{
    public interface IUnitOfWork : System.IDisposable
    {
        IGenericRepository<Client> ClientRepository { get; }
        IGenericRepository<DriverInfo> DriverInfoRepository { get; }
        IGenericRepository<Route> RouteRepository { get; }
        IGenericRepository<Score> ScoreRepository { get; }
        IGenericRepository<Street> StreetRepository { get; }

        void Save();
    }
}
