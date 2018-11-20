using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class CsvFileServiceTest
    {
        private DataControl.Services.CsvFileService csvFileService;

        private void SetCsvFileService()
        {
            csvFileService = new DataControl.Services.CsvFileService();
            csvFileService.SetConfiguration(new DataControl.Services.FileConfiguration()
            {
                ClientFile = Configuration.CLIENT_FILE_PATH,
                DriverFile = Configuration.DRIVER_FILE_PATH,
                RouteFile = Configuration.ROUTE_FILE_PATH,
                ScoreFile = Configuration.SCORE_FILE_PATH,
                StreetFile = Configuration.STREET_FILE_PATH
            });

        }

        [TestMethod]
        public void TestSetConfiguration()
        {
            csvFileService = new DataControl.Services.CsvFileService();
            DataControl.Interfaces.IDataAccessService dataAccessService =
                csvFileService.SetConfiguration(new DataControl.Services.FileConfiguration());

            Assert.AreSame(csvFileService, dataAccessService);
        }

        [TestMethod]
        public void TestSignUp()
        {
            System.IO.File.Create(Configuration.DRIVER_FILE_PATH).Close();

            SetCsvFileService();

            Assert.IsTrue(csvFileService.SignUp("Taras", "password"));

            TaxiDriver.Driver driver = new TaxiDriver.Driver("Taras", "password", 0, 0);
            Assert.IsTrue(driver.Name == csvFileService.Driver.Name &&
                driver.Password == csvFileService.Driver.Password &&
                driver.TotalScore == csvFileService.Driver.TotalScore &&
                driver.BestScore == csvFileService.Driver.BestScore &&
                driver.LastScore == csvFileService.Driver.LastScore);
            Assert.AreEqual(null, csvFileService.Message);

            csvFileService.SignUp("Oleg", "1234");

            string message = "User with such name already exists.";
            Assert.IsFalse(csvFileService.SignUp("Taras", "password"));
            Assert.IsTrue(csvFileService.Message == message);
            Assert.AreEqual(null, csvFileService.Driver);

            Assert.IsFalse(csvFileService.SignUp("Taras", "hello"));
            Assert.IsTrue(csvFileService.Message == message);
            Assert.AreEqual(null, csvFileService.Driver);

            csvFileService.SignUp("Oleg", "1234");
            csvFileService.SignUp("Petro", "day");
            csvFileService.SignUp("Oleg", "1234");
        }

        [TestMethod]
        public void TestLogIn()
        {
            System.IO.File.Create(Configuration.SCORE_FILE_PATH).Close();

            SetCsvFileService();

            // Test line in the middle of the file.
            Assert.IsTrue(csvFileService.LogIn("Oleg", "1234"));

            TaxiDriver.Driver driver = new TaxiDriver.Driver("Oleg", "1234", 0, 0);
            Assert.IsTrue(driver.Name == csvFileService.Driver.Name &&
                driver.Password == csvFileService.Driver.Password &&
                driver.TotalScore == csvFileService.Driver.TotalScore &&
                driver.BestScore == csvFileService.Driver.BestScore &&
                driver.LastScore == csvFileService.Driver.LastScore);
            Assert.AreEqual(null, csvFileService.Message);

            string message = "The password is incorrect.";
            Assert.IsFalse(csvFileService.LogIn("Oleg", "world"));
            Assert.IsTrue(csvFileService.Message == message);
            Assert.AreEqual(null, csvFileService.Driver);

            message = "The name is incorrect.";
            Assert.IsFalse(csvFileService.LogIn("Vasyl", "1234"));
            Assert.IsTrue(csvFileService.Message == message);
            Assert.AreEqual(null, csvFileService.Driver);

            Assert.IsFalse(csvFileService.LogIn("Vasyl", "goodday"));
            Assert.IsTrue(csvFileService.Message == message);
            Assert.AreEqual(null, csvFileService.Driver);

            // Test line in the end of the file.
            Assert.IsTrue(csvFileService.LogIn("Petro", "day"));

            driver = new TaxiDriver.Driver("Petro", "day", 0, 0);
            Assert.IsTrue(driver.Name == csvFileService.Driver.Name &&
                driver.Password == csvFileService.Driver.Password &&
                driver.TotalScore == csvFileService.Driver.TotalScore &&
                driver.BestScore == csvFileService.Driver.BestScore &&
                driver.LastScore == csvFileService.Driver.LastScore);
            Assert.AreEqual(null, csvFileService.Message);

            message = "The password is incorrect.";
            Assert.IsFalse(csvFileService.LogIn("Petro", "world"));
            Assert.IsTrue(csvFileService.Message == message);
            Assert.AreEqual(null, csvFileService.Driver);

            message = "The name is incorrect.";
            Assert.IsFalse(csvFileService.LogIn("Vasyl", "day"));
            Assert.IsTrue(csvFileService.Message == message);
            Assert.AreEqual(null, csvFileService.Driver);

            Assert.IsFalse(csvFileService.LogIn("Vasyl", "goodday"));
            Assert.IsTrue(csvFileService.Message == message);
            Assert.AreEqual(null, csvFileService.Driver);
        }

        [TestMethod]
        public void TestSaveResult()
        {
            System.IO.File.Create(Configuration.SCORE_FILE_PATH).Close();

            SetCsvFileService();

            TaxiDriver.Driver driver = new TaxiDriver.Driver("Oleg", "1234", 0, 0)
            {
                LastScore = 70
            };
            csvFileService.SaveResult(driver);

            driver = new TaxiDriver.Driver("Taras", "password", 0, 0)
            {
                LastScore = 80
            };

            csvFileService.SaveResult(driver);

            driver = new TaxiDriver.Driver("Petro", "day", 0, 0)
            {
                LastScore = 120
            };
            csvFileService.SaveResult(driver);

            driver = new TaxiDriver.Driver("Taras", "password", 0, 0)
            {
                LastScore = 110
            };
            csvFileService.SaveResult(driver);

            csvFileService.LogIn("Taras", "password");

            driver = new TaxiDriver.Driver("Taras", "password", 110, 80)
            {
                LastScore = 110
            };


            Assert.IsTrue(driver.Name == csvFileService.Driver.Name &&
                driver.Password == csvFileService.Driver.Password &&
                driver.TotalScore == csvFileService.Driver.TotalScore &&
                driver.BestScore == csvFileService.Driver.BestScore &&
                driver.LastScore == csvFileService.Driver.LastScore);
        }

        [TestMethod]
        public void TestGetBest()
        {
            SetCsvFileService();

            TaxiDriver.Champion[] champions =
            {
                new TaxiDriver.Champion(1, "Petro", 120),
                new TaxiDriver.Champion(2, "Taras", 110),
                new TaxiDriver.Champion(3, "Taras", 80),
                new TaxiDriver.Champion(4, "Oleg", 70)
            };

            int amount = 4;
            TaxiDriver.Champion[] championFromFile = csvFileService.GetBest(amount);
            for (int i = 0; i < championFromFile.Length; ++i)
            {
                Assert.IsTrue(champions[i].Number == championFromFile[i].Number &&
                    champions[i].Name == championFromFile[i].Name &&
                    champions[i].Score == championFromFile[i].Score);
            }

            amount = 10;
            championFromFile = csvFileService.GetBest(amount);
            System.Console.WriteLine(championFromFile.Length);
            for (int i = 0; i < championFromFile.Length; ++i)
            {
                Assert.IsTrue(champions[i].Number == championFromFile[i].Number &&
                    champions[i].Name == championFromFile[i].Name &&
                    champions[i].Score == championFromFile[i].Score);
            }

            amount = 2;
            championFromFile = csvFileService.GetBest(amount);
            for (int i = 0; i < championFromFile.Length; ++i)
            {
                Assert.IsTrue(champions[i].Number == championFromFile[i].Number &&
                    champions[i].Name == championFromFile[i].Name &&
                    champions[i].Score == championFromFile[i].Score);
            }
        }
    }
}
