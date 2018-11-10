namespace DataControl.Interfaces
{
    /// <summary>
    /// Represents some service for data access.
    /// </summary>
    public interface IDataAccessService
    {
        /// <summary>
        /// Some information about current driver.
        /// </summary>
        TaxiDriver.Driver Driver { get; }
        /// <summary>
        /// Some special information about exceptional service state.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Gets the best champions(drivers).
        /// </summary>
        /// <param name="amount">Amount of champions for choosing from beginning of some data structure.</param>
        /// <returns>
        /// Array of champions.
        /// </returns>
        TaxiDriver.Champion[] GetBest(int amount);
        /// <summary>
        /// Gets random order from some data structure.
        /// </summary>
        /// <returns>
        /// Order that can be chosen by current taxi driver.
        /// </returns>
        TaxiDriver.Order GetRandomOrder();
        /// <summary>
        /// Sets some configuration.
        /// </summary>
        /// <param name="configuration">Some configuration for setting up.</param>
        /// <returns>
        /// Some service for data access.
        /// </returns>
        IDataAccessService SetConfiguration(IConfiguration configuration);
        /// <summary>
        /// Saves current driver results.
        /// </summary>
        /// <param name="driver">Current driver.</param>
        void SaveResult(TaxiDriver.Driver driver);
        /// <summary>
        /// Signs up driver by his name and password.
        /// </summary>
        /// <param name="name">Driver name.</param>
        /// <param name="password">Driver password.</param>
        /// <returns>
        /// True if driver was signed up, if such driver exists - false.
        /// </returns>
        bool SignUp(string name, string password);
        /// <summary>
        /// Logs in driver by his name and password.
        /// </summary>
        /// <param name="name">Driver name.</param>
        /// <param name="password">Driver password.</param>
        /// <returns>
        /// True if driver was logged in, if such driver doesn`t exist - false.
        /// </returns>
        bool LogIn(string name, string password);
    }
}
