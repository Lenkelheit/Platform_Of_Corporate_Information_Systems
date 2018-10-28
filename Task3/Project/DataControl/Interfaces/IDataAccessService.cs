namespace DataControl.Interfaces
{
    public interface IDataAccessService
    {
        TaxiDriver.Driver Driver { get; }
        string Message { get; }

        TaxiDriver.Сhampion[] GetBest(int amount);
        TaxiDriver.Order GetRandomOrder();
        IDataAccessService SetConfiguration(IConfiguration configuration);
        void SaveResult(TaxiDriver.Driver driver);
        bool SignUp(string name, string password);
        bool LogIn(string name, string password);
    }
}
