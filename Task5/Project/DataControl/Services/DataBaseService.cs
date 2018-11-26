using TaxiDriver;
using System.Linq;

namespace DataControl.Services
{
    /// <summary>
    /// Represents service for work with databases.
    /// </summary>
    public class DataBaseService : Interfaces.IDataAccessService, System.IDisposable
    {
        // FIELDS
        private Driver driver;
        private string message;
        private DBConfiguration dbConfiguration;
        private System.Random rand;
        private bool disposedValue;

        // PROPERTIES
        /// <summary>
        /// Current driver.
        /// </summary>
        public Driver Driver
        {
            get
            {
                return driver;
            }
        }
        /// <summary>
        /// Some special information about exceptional service state.
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
        }

        // CONSTRUCTORS DESTRUCTOR
        /// <summary>
        /// Basic constructor without parameters.
        /// </summary>
        public DataBaseService()
        {
            driver = null;
            message = null;
            dbConfiguration = null;
            rand = new System.Random();
            disposedValue = false;
        }
        /// <summary>
        /// Default finaliser
        /// </summary>
        ~DataBaseService()
        {
            Dispose(false);
        }

        // METHODS
        private void SetNullToDriverAndMessage()
        {
            driver = null;
            message = null;
        }

        private void CheckDatabaseConfiguration()
        {
            if (dbConfiguration == null)
            {
                throw new System.ArgumentNullException("The configuration isn`t setted up.");
            }
        }

        private Client CreateClient()
        {
            return dbConfiguration.UnitOfWork.ClientRepository
                .GetByID(rand.Next(1, dbConfiguration.UnitOfWork.ClientRepository.Count + 1));
        }

        private Route CreateRoute()
        {
            return dbConfiguration.UnitOfWork.RouteRepository
                .GetByID(rand.Next(1, dbConfiguration.UnitOfWork.RouteRepository.Count + 1));
        }

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
                    dbConfiguration.Dispose();
                    dbConfiguration = null;
                    SetNullToDriverAndMessage();
                    rand = null;
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Gets the best champions(drivers) from some database.
        /// </summary>
        /// <param name="amount">Amount of champions for choosing from beginning of some database.</param>
        /// <returns>
        /// Array of champions.
        /// </returns>
        /// <exception cref="System.Data.DataException">
        /// Thrown when database wasn`t found.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when database configuration is null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <see cref="DBConfiguration.UnitOfWork"/> is null.
        /// </exception>
        public Champion[] GetBest(int amount)
        {
            CheckDatabaseConfiguration();

            // get Amount best score
            Score[] bestScores = dbConfiguration.UnitOfWork.ScoreRepository
                .Get(orderBy: query => query.OrderByDescending(scoreElem => scoreElem.Scores))
                .Take(amount).ToArray();  

            // get all needed driver ID
            int[] driverIDs = bestScores.Select(s => s.DriverInfoID).Distinct().ToArray();

            // get all needed driver info
            System.Collections.Generic.Dictionary<int, string> driverInfoes =
                dbConfiguration.UnitOfWork.DriverInfoRepository
                    .Get(filter: dInfo => driverIDs.Contains(dInfo.ID))
                        .ToDictionary(d => d.ID, d => d.Name);
    
            // allocate memory, full fill result array
            Champion[] champions = new Champion[bestScores.Length];
            for (int i = 0; i < bestScores.Length; ++i)
            {
                champions[i] = new Champion(i + 1, driverInfoes[bestScores[i].DriverInfoID], bestScores[i].Scores);
            }
            return champions;
        }

        /// <summary>
        /// Gets the random order from some database.
        /// </summary>
        /// <returns>
        /// The random order.
        /// </returns>
        /// <exception cref="System.Data.DataException">
        /// Thrown when database wasn`t found.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when database configuration is null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <see cref="DBConfiguration.UnitOfWork"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when the clients table of the database is empty.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when the routes table of the database is empty.
        /// </exception>
        public Order GetRandomOrder()
        {
            CheckDatabaseConfiguration();

            return new Order(rand.Next(1000), CreateClient(), CreateRoute());
        }

        /// <summary>
        /// Sets database configuration.
        /// </summary>
        /// <param name="configuration">Some configuration for setting up.</param>
        /// <returns>
        /// Current service for data access.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the configuration is inappropriate.
        /// </exception>
        public Interfaces.IDataAccessService SetConfiguration(Interfaces.IConfiguration configuration)
        {
            if (!(configuration is DBConfiguration)) 
            {
                throw new System.ArgumentException("The configuration is inappropriate.");
            }
            dbConfiguration = (DBConfiguration)configuration;
            return this;
        }

        /// <summary>
        /// Saves driver result to some database.
        /// </summary>
        /// <param name="currentDriver">Current driver.</param>
        /// <exception cref="System.Data.DataException">
        /// Thrown when database with <see cref="DriverInfo"/> wasn`t found.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when database configuration is null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <see cref="DBConfiguration.UnitOfWork"/> is null.
        /// </exception>
        public void SaveResult(Driver currentDriver)
        {
            CheckDatabaseConfiguration();

            DriverInfo driverInformation =
                dbConfiguration.UnitOfWork.DriverInfoRepository
                .Get(filter: driverInfo => driverInfo.Name == currentDriver.Name).First();

            driverInformation.Scores.Add(new Score { Scores = currentDriver.LastScore });

            dbConfiguration.UnitOfWork.DriverInfoRepository.Update(driverInformation);
            dbConfiguration.UnitOfWork.Save();
        }

        /// <summary>
        /// Signs up driver by his name and password.
        /// </summary>
        /// <param name="name">Driver name.</param>
        /// <param name="password">Driver password.</param>
        /// <returns>
        /// True if driver was signed up, else - false.
        /// </returns>
        /// <exception cref="System.Data.DataException">
        /// Thrown when database with <see cref="DriverInfo"/> wasn`t found.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when database configuration is null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <see cref="DBConfiguration.UnitOfWork"/> is null.
        /// </exception>
        public bool SignUp(string name, string password)
        {
            CheckDatabaseConfiguration();

            SetNullToDriverAndMessage();

            name = name.Trim();
            password = password.Trim();

            int driversAmount = dbConfiguration.UnitOfWork.DriverInfoRepository
                .Get(filter: driverInfo => driverInfo.Name == name).Count();

            if (driversAmount != 0)
            {
                message = "User with such name already exists.";
                return false;
            }
            driver = new Driver(name, password, 0, 0);

            dbConfiguration.UnitOfWork.DriverInfoRepository.Insert(new DriverInfo
            {
                Name = name,
                Password = password,
                Scores = new System.Collections.Generic.List<Score>()
            });
            dbConfiguration.UnitOfWork.Save();
            return true;
        }

        /// <summary>
        /// Logs in driver by his name and password.
        /// </summary>
        /// <param name="name">Driver name.</param>
        /// <param name="password">Driver password.</param>
        /// <returns>
        /// True if driver was logged in, else - false.
        /// </returns>
        /// <exception cref="System.Data.DataException">
        /// Thrown when database with <see cref="DriverInfo"/> wasn`t found.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when database configuration is null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <see cref="DBConfiguration.UnitOfWork"/> is null.
        /// </exception>
        public bool LogIn(string name, string password)
        {
            CheckDatabaseConfiguration();

            SetNullToDriverAndMessage();

            name = name.Trim();
            password = password.Trim();

            var drivers = dbConfiguration.UnitOfWork.DriverInfoRepository
                .Get(filter: driverInfo => driverInfo.Name == name);

            if (drivers.Count() == 0)  
            {
                message = "The name is incorrect.";
                return false;
            }

            DriverInfo currentDriver = drivers.First();
            if (currentDriver.Password != password) 
            {
                message = "The password is incorrect.";
                return false;
            }
            driver = new Driver(currentDriver);

            return true;
        }
    }
}
