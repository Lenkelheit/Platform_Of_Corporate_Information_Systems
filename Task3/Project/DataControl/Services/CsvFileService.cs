using System.IO;
using System.Collections.Generic;

namespace DataControl.Services
{
    /// <summary>
    /// Represents service for work with csv files.
    /// </summary>
    public class CsvFileService : Interfaces.IDataAccessService
    {
        // FIELDS
        private TaxiDriver.Driver driver;
        private string message;
        private FileConfiguration fileConfiguration;
        private System.Random rand;

        // PROPERTIES
        /// <summary>
        /// Current driver.
        /// </summary>
        public TaxiDriver.Driver Driver
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

        // CONSTRUCTORS
        /// <summary>
        /// Basic constructors without parameters.
        /// </summary>
        public CsvFileService()
        {
            rand = new System.Random();
        }

        // METHODS
        private void CheckFileConfiguration()
        {
            if (fileConfiguration == null)
            {
                throw new System.ArgumentNullException("The configuration isn`t setted up.");
            }
        }

        private string[] GetRandomSplittedLine(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int index = rand.Next(0, lines.Length);

            return lines[index].Split(';');
        }

        private TaxiDriver.Client CreateClient()
        {
            string[] clientParameters = GetRandomSplittedLine(fileConfiguration.ClientFile);
            return new TaxiDriver.Client(clientParameters[1], clientParameters[clientParameters.Length - 1]);
        }

        private TaxiDriver.Route CreateRoute()
        {
            string[] routeParameters = GetRandomSplittedLine(fileConfiguration.RouteFile);

            int startStreetId = int.Parse(routeParameters[1]);
            int endStreetId = int.Parse(routeParameters[2]);

            System.Tuple<string, string> startAndEndStreets = GetStartAndEndStreets(startStreetId, endStreetId);

            return new TaxiDriver.Route(startAndEndStreets.Item1,
                startAndEndStreets.Item2,
                System.TimeSpan.FromSeconds(int.Parse(routeParameters[3])),
                double.Parse(routeParameters[routeParameters.Length - 1]));
        }

        private System.Tuple<string, string> GetStartAndEndStreets(int startStreetId, int endStreetId)
        {
            string line, startStreet = null, endStreet = null;
            using (StreamReader streamReader = new StreamReader(fileConfiguration.StreetFile))
            {
                int maxIndex = startStreetId > endStreetId ? startStreetId : endStreetId;
                int i = 0;
                while (i < maxIndex)
                {
                    line = streamReader.ReadLine();
                    if (i == startStreetId - 1)
                    {
                        startStreet = line.Split(';')[1];
                    }
                    else if (i == endStreetId - 1)
                    {
                        endStreet = line.Split(';')[1];
                    }
                    ++i;
                }
            }
            return new System.Tuple<string, string>(startStreet, endStreet);
        }

        private void SetDriverTotalAndBestScore()
        {
            string[] scoreLines = File.ReadAllLines(fileConfiguration.ScoreFile);

            for (int i = 0; i < scoreLines.Length; ++i) 
            {
                if (scoreLines[i].Contains(driver.Name))
                {
                    driver.LastScore = double.Parse(scoreLines[i].Split(';')[1]);
                }
            }
        }

        /// <summary>
        /// Gets the best champions(drivers) from some file.
        /// </summary>
        /// <param name="amount">Amount of champions for choosing from beginning of some csv file.</param>
        /// <returns>
        /// Array of champions.
        /// </returns>
        /// <exception cref="FileNotFoundException">
        /// Thrown when file with scores wasn`t found.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when file configuration is null.
        /// </exception>
        public TaxiDriver.Champion[] GetBest(int amount)
        {
            CheckFileConfiguration();

            string[] scoreLines = File.ReadAllLines(fileConfiguration.ScoreFile);

            List<KeyValuePair<string, double>> allChampionsList =
                new List<KeyValuePair<string, double>>(scoreLines.Length);
            string[] scoreParameters;
            for (int i = 0; i < scoreLines.Length; ++i) 
            {
                scoreParameters = scoreLines[i].Split(';');
                allChampionsList.Add(new KeyValuePair<string, double>
                    (scoreParameters[0], double.Parse(scoreParameters[scoreParameters.Length - 1])));
            }
            allChampionsList.Sort((first, second) => second.Value.CompareTo(first.Value));

            TaxiDriver.Champion[] champions = 
                new TaxiDriver.Champion[amount < allChampionsList.Count ? amount : allChampionsList.Count];
            for (int i = 0; i < amount && i < allChampionsList.Count; ++i) 
            {
                champions[i] = new TaxiDriver.Champion(i + 1, allChampionsList[i].Key, allChampionsList[i].Value);
            }
            return champions;
        }

        /// <summary>
        /// Gets the random order from some files.
        /// </summary>
        /// <returns>
        /// The random order.
        /// </returns>
        /// <exception cref="FileNotFoundException">
        /// Thrown when some files for creating order weren`t found.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when file configuration is null.
        /// </exception>
        public TaxiDriver.Order GetRandomOrder()
        {
            CheckFileConfiguration();

            TaxiDriver.Client client = CreateClient();
            TaxiDriver.Route route = CreateRoute();

            return new TaxiDriver.Order(rand.Next(), client, route);
        }

        /// <summary>
        /// Sets file configuration.
        /// </summary>
        /// <param name="configuration">Some configuration for setting up.</param>
        /// <returns>
        /// Current service for data access.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the configuration is null.
        /// </exception>
        public Interfaces.IDataAccessService SetConfiguration(Interfaces.IConfiguration configuration)
        {
            if (configuration != null)
            {
                fileConfiguration = configuration as FileConfiguration;
                return this;
            }
            throw new System.ArgumentNullException("The configuration is null.");
        }

        /// <summary>
        /// Saves driver result to some file.
        /// </summary>
        /// <param name="driver">Current driver.</param>
        /// <exception cref="FileNotFoundException">
        /// Thrown when file with scores wasn`t found.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when file configuration is null.
        /// </exception>
        public void SaveResult(TaxiDriver.Driver driver)
        {
            CheckFileConfiguration();

            File.AppendAllText(fileConfiguration.ScoreFile, $"{driver.Name};{driver.LastScore}\n");
        }

        /// <summary>
        /// Signs up driver by his name and password.
        /// </summary>
        /// <param name="name">Driver name.</param>
        /// <param name="password">Driver password.</param>
        /// <returns>
        /// True if driver was signed up, else - false.
        /// </returns>
        /// <exception cref="FileNotFoundException">
        /// Thrown when file with drivers wasn`t found.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when file configuration is null.
        /// </exception>
        public bool SignUp(string name, string password)
        {
            CheckFileConfiguration();

            using (StreamReader streamReader = new StreamReader(fileConfiguration.DriverFile))
            {
                string line;
                while (!streamReader.EndOfStream)
                {
                    line = streamReader.ReadLine();
                    if (line.StartsWith(name))
                    {
                        message = "User with such name already exists.";
                        return false;
                    }
                }
            }

            driver = new TaxiDriver.Driver(name, password, 0, 0);
            File.AppendAllText(fileConfiguration.DriverFile, $"{name};{password}\n");
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
        /// <exception cref="FileNotFoundException">
        /// Thrown when file with drivers wasn`t found.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when file configuration is null.
        /// </exception>
        public bool LogIn(string name, string password)
        {
            CheckFileConfiguration();

            string line;
            StreamReader streamReader;
            for (streamReader = new StreamReader(fileConfiguration.DriverFile); !streamReader.EndOfStream;) 
            {
                line = streamReader.ReadLine();
                if (line.StartsWith(name))
                {
                    if (line.EndsWith(password))
                    {
                        driver = new TaxiDriver.Driver(name, password, 0, 0);
                        SetDriverTotalAndBestScore();
                        return true;
                    }
                    else
                    {
                        message = "The password is incorrect.";
                        return false;
                    }
                }
            }
            streamReader.Dispose();
            message = "The name is incorrect.";
            return false;
        }
    }
}
