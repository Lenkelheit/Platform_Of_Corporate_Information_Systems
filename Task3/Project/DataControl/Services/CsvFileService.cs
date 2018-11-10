using System.IO;

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

        // METHODS
        private TaxiDriver.Client CreateClient()
        {
            string[] clientLines;
            using (StreamReader streamReader = new StreamReader(fileConfiguration.ClientFile))
            {
                clientLines = streamReader.ReadToEnd().Trim().Split('\n');
            }
            System.Random rand = new System.Random();
            int clientIndex = rand.Next(0, clientLines.Length);

            string[] clientParameters = clientLines[clientIndex].Split(';');
            return new TaxiDriver.Client(clientParameters[1], clientParameters[clientParameters.Length - 1]);
        }

        private TaxiDriver.Route CreateRoute()
        {
            string[] routeLines;
            using (StreamReader streamReader = new StreamReader(fileConfiguration.RouteFile))
            {
                routeLines = streamReader.ReadToEnd().Trim().Split('\n');
            }
            System.Random rand = new System.Random();
            int routeIndex = rand.Next(0, routeLines.Length);

            string[] routeParameters = routeLines[routeIndex].Split(';');

            int startStreetId = int.Parse(routeParameters[1]);
            int endStreetId = int.Parse(routeParameters[2]);

            System.Tuple<string, string> startAndEndStreets = GetStartAndEndStreets(startStreetId, endStreetId);

            return new TaxiDriver.Route(startAndEndStreets.Item1,
                startAndEndStreets.Item2,
                new System.TimeSpan(0, 0, int.Parse(routeParameters[3])),
                double.Parse(routeParameters[routeParameters.Length - 1]));
        }

        private System.Tuple<string, string> GetStartAndEndStreets(int startStreetId, int endStreetId)
        {
            string line = "", startStreet = "", endStreet = "";
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
            if (!File.Exists(fileConfiguration.ScoreFile)) 
            {
                throw new FileNotFoundException($"File with path {fileConfiguration.ScoreFile} wasn`t found.");
            }

            string[] scoreLines;
            using (StreamReader streamReader = new StreamReader(fileConfiguration.ScoreFile))
            {
                scoreLines = streamReader.ReadToEnd().Trim().Split('\n');
            }

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
            if (fileConfiguration != null)
            {
                if (!File.Exists(fileConfiguration.ScoreFile))
                {
                    throw new FileNotFoundException($"File with path {fileConfiguration.ScoreFile} wasn`t found.");
                }

                System.Collections.Generic.List<TaxiDriver.Champion> champions =
                    new System.Collections.Generic.List<TaxiDriver.Champion>();
                using (StreamReader streamReader = new StreamReader(fileConfiguration.ScoreFile))
                {
                    string[] championLine;
                    int i = 0;
                    while (i < amount && !streamReader.EndOfStream)
                    {
                        championLine = streamReader.ReadLine().Split(';');
                        champions.Add(new TaxiDriver.Champion(i + 1, championLine[0],
                            double.Parse(championLine[championLine.Length - 1])));
                        ++i;
                    }
                }
                return champions.ToArray();
            }
            else
            {
                throw new System.ArgumentNullException("The configuration isn`t setted up.");
            }
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
            if (fileConfiguration != null)
            {
                if (!File.Exists(fileConfiguration.ClientFile) && 
                    !File.Exists(fileConfiguration.RouteFile) && 
                    !File.Exists(fileConfiguration.StreetFile)) 
                {
                    throw new FileNotFoundException("Some files for creating order weren`t found.");
                }

                TaxiDriver.Client client = CreateClient();
                TaxiDriver.Route route = CreateRoute();

                System.Random rand = new System.Random();
                return new TaxiDriver.Order(rand.Next(), client, route);
            }
            else
            {
                throw new System.ArgumentNullException("The configuration isn`t setted up.");
            }
        }

        /// <summary>
        /// Sets file configuration.
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
            fileConfiguration = configuration as FileConfiguration;
            if (fileConfiguration != null)
            {
                return this;
            } 
            throw new System.ArgumentException("The configuration is inappropriate.");
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
            if (fileConfiguration != null)
            {
                if (!File.Exists(fileConfiguration.ScoreFile)) 
                {
                    throw new FileNotFoundException($"File with path {fileConfiguration.ScoreFile} wasn`t found.");
                }

                using (StreamWriter streamWriter = new StreamWriter(fileConfiguration.ScoreFile, true))   
                {
                    streamWriter.WriteLine($"{driver.Name};{driver.LastScore}");
                }
            }
            else
            {
                throw new System.ArgumentNullException("The configuration isn`t setted up.");
            }
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
            if (fileConfiguration != null)
            {
                if (!File.Exists(fileConfiguration.DriverFile))
                {
                    throw new FileNotFoundException($"File with path {fileConfiguration.DriverFile} wasn`t found.");
                }

                using (StreamReader streamReader = new StreamReader(fileConfiguration.DriverFile)) 
                {
                    string line = "";
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
                using (StreamWriter streamWriter = new StreamWriter(fileConfiguration.DriverFile, true)) 
                {
                    streamWriter.WriteLine($"{name};{password}");
                }
                return true;
            }
            else
            {
                throw new System.ArgumentNullException("The configuration isn`t setted up.");
            }
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
            if (fileConfiguration != null) 
            {
                if (!File.Exists(fileConfiguration.DriverFile))
                {
                    throw new FileNotFoundException($"File with path {fileConfiguration.DriverFile} wasn`t found.");
                }

                using (StreamReader streamReader = new StreamReader(fileConfiguration.DriverFile))
                {
                    string line = "";
                    while (!streamReader.EndOfStream)
                    {
                        line = streamReader.ReadLine();
                        if (line.StartsWith(name) && line.EndsWith(password))
                        {
                            driver = new TaxiDriver.Driver(name, password, 0, 0);
                            SetDriverTotalAndBestScore();
                            return true;
                        }
                    }
                }
                message = "The name or password is incorrect.";
                return false;
            }
            else
            {
                throw new System.ArgumentNullException("The configuration isn`t setted up.");
            }
        }
    }
}
