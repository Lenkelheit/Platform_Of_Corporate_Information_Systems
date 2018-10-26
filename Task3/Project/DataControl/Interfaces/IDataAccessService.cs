namespace DataControl.Interfaces
{
    public interface IDataAccessService
    {
        TaxiDriver.Driver Driver { get; }
        string Message { get; }

        string[] GetBest(int amount);
        TaxiDriver.Order GetRandomOrder();
        void SaveResult(TaxiDriver.Driver driver);
        bool SignUp(string name, string password);
        bool LogIn(string name, string password);
    }
}
