using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataControl.Services;

namespace Test
{
    [TestClass]
    public class DataBaseServiceTest
    {
        private static readonly string connectionStringName = "TestTaxiDriverDbConnection";

        private DBConfiguration SetDBConfigurationAndClearDriverInfoTable()
        {
            DBConfiguration dbConfiguration = new DBConfiguration(connectionStringName);

            var allDriverInfo = dbConfiguration.UnitOfWork.DriverInfoRepository.Get(filter: q => true);
            foreach (var driverInfo in allDriverInfo)
            {
                dbConfiguration.UnitOfWork.DriverInfoRepository.Delete(driverInfo);
            }
            dbConfiguration.UnitOfWork.Save();
            return dbConfiguration;
        }

        private DBConfiguration SetDBConfigurationAndClearScoreAndDriverInfoTable()
        {
            DBConfiguration dbConfiguration = SetDBConfigurationAndClearDriverInfoTable();

            var allScores = dbConfiguration.UnitOfWork.ScoreRepository.Get(filter: q => true);
            foreach (var score in allScores)
            {
                dbConfiguration.UnitOfWork.ScoreRepository.Delete(score);
            }
            dbConfiguration.UnitOfWork.Save();
            return dbConfiguration;
        }

        private void SaveSomeDriverInfoToDB(DataBaseService dbService)
        {
            dbService.SignUp("Taras", "password");
            dbService.SignUp("Oleg", "1234");
            dbService.SignUp("Petro", "day");


            TaxiDriver.Driver driver = new TaxiDriver.Driver("Oleg", "1234", 0, 0)
            {
                LastScore = 70
            };
            dbService.SaveResult(driver);

            driver = new TaxiDriver.Driver("Taras", "password", 0, 0)
            {
                LastScore = 80
            };

            dbService.SaveResult(driver);

            driver = new TaxiDriver.Driver("Petro", "day", 0, 0)
            {
                LastScore = 120
            };
            dbService.SaveResult(driver);

            driver = new TaxiDriver.Driver("Taras", "password", 0, 0)
            {
                LastScore = 110
            };
            dbService.SaveResult(driver);
        }

        [TestMethod]
        public void TestSetConfiguration()
        {
            using (DataBaseService dbService = new DataBaseService()) 
            {
                DBConfiguration dbConfiguration = new DBConfiguration(connectionStringName);

                DataControl.Interfaces.IDataAccessService dataAccessService =
                    dbService.SetConfiguration(dbConfiguration);

                Assert.AreSame(dbService, dataAccessService);
            }
        }

        [TestMethod]
        public void TestSignUp()
        {
            using (DataBaseService dbService = new DataBaseService())
            {
                dbService.SetConfiguration(SetDBConfigurationAndClearDriverInfoTable());

                Assert.IsTrue(dbService.SignUp("Taras", "password"));

                TaxiDriver.Driver driver = new TaxiDriver.Driver("Taras", "password", 0, 0);
                Assert.AreEqual(driver.Name, dbService.Driver.Name);
                Assert.AreEqual(driver.Password, dbService.Driver.Password);
                Assert.AreEqual(driver.TotalScore, dbService.Driver.TotalScore);
                Assert.AreEqual(driver.BestScore, dbService.Driver.BestScore);
                Assert.AreEqual(driver.LastScore, dbService.Driver.LastScore);

                Assert.AreEqual(null, dbService.Message);

                dbService.SignUp("Oleg", "1234");

                string message = "User with such name already exists.";
                Assert.IsFalse(dbService.SignUp("Taras", "password"));
                Assert.AreEqual(dbService.Message, message);
                Assert.AreEqual(null, dbService.Driver);

                Assert.IsFalse(dbService.SignUp("Taras", "hello"));
                Assert.AreEqual(dbService.Message, message);
                Assert.AreEqual(null, dbService.Driver);
            }
        }

        [TestMethod]
        public void TestLogIn()
        {
            using (DataBaseService dbService = new DataBaseService())
            {
                dbService.SetConfiguration(SetDBConfigurationAndClearDriverInfoTable());

                dbService.SignUp("Taras", "password");
                dbService.SignUp("Oleg", "1234");
                dbService.SignUp("Petro", "day");


                // Test note in the middle of the database.
                Assert.IsTrue(dbService.LogIn("Oleg", "1234"));
                TaxiDriver.Driver driver = new TaxiDriver.Driver("Oleg", "1234", 0, 0);
                Assert.AreEqual(driver.Name, dbService.Driver.Name);
                Assert.AreEqual(driver.Password, dbService.Driver.Password);
                Assert.AreEqual(driver.TotalScore, dbService.Driver.TotalScore);
                Assert.AreEqual(driver.BestScore, dbService.Driver.BestScore);
                Assert.AreEqual(driver.LastScore, dbService.Driver.LastScore);
                Assert.AreEqual(null, dbService.Message);

                string message = "The password is incorrect.";
                Assert.IsFalse(dbService.LogIn("Oleg", "world"));
                Assert.AreEqual(dbService.Message, message);
                Assert.AreEqual(null, dbService.Driver);

                message = "The name is incorrect.";
                Assert.IsFalse(dbService.LogIn("Vasyl", "1234"));
                Assert.AreEqual(dbService.Message, message);
                Assert.AreEqual(null, dbService.Driver);

                Assert.IsFalse(dbService.LogIn("Vasyl", "goodday"));
                Assert.AreEqual(dbService.Message, message);
                Assert.AreEqual(null, dbService.Driver);

                // Test note in the end of the database.
                Assert.IsTrue(dbService.LogIn("Petro", "day"));

                driver = new TaxiDriver.Driver("Petro", "day", 0, 0);
                Assert.AreEqual(driver.Name, dbService.Driver.Name);
                Assert.AreEqual(driver.Password, dbService.Driver.Password);
                Assert.AreEqual(driver.TotalScore, dbService.Driver.TotalScore);
                Assert.AreEqual(driver.BestScore, dbService.Driver.BestScore);
                Assert.AreEqual(driver.LastScore, dbService.Driver.LastScore);
                Assert.AreEqual(null, dbService.Message);
                Assert.AreEqual(null, dbService.Message);

                message = "The password is incorrect.";
                Assert.IsFalse(dbService.LogIn("Petro", "world"));
                Assert.AreEqual(dbService.Message, message);
                Assert.AreEqual(null, dbService.Driver);

                message = "The name is incorrect.";
                Assert.IsFalse(dbService.LogIn("Vasyl", "day"));
                Assert.AreEqual(dbService.Message, message);
                Assert.AreEqual(null, dbService.Driver);

                Assert.IsFalse(dbService.LogIn("Vasyl", "goodday"));
                Assert.AreEqual(dbService.Message, message);
                Assert.AreEqual(null, dbService.Driver);
            }
        }

        [TestMethod]
        public void TestSaveResult()
        {
            using (DataBaseService dbService = new DataBaseService())
            {
                dbService.SetConfiguration(SetDBConfigurationAndClearScoreAndDriverInfoTable());

                SaveSomeDriverInfoToDB(dbService);

                // Logs in for checking the current driver scores.
                dbService.LogIn("Taras", "password");

                TaxiDriver.Driver driver = new TaxiDriver.Driver("Taras", "password", 110, 80)
                {
                    LastScore = 110
                };

                Assert.AreEqual(driver.Name, dbService.Driver.Name);
                Assert.AreEqual(driver.Password, dbService.Driver.Password);
                Assert.AreEqual(driver.TotalScore, dbService.Driver.TotalScore);
                Assert.AreEqual(driver.BestScore, dbService.Driver.BestScore);
                Assert.AreEqual(driver.LastScore, dbService.Driver.LastScore);
            }
        }

        [TestMethod]
        public void TestGetBest()
        {
            using (DataBaseService dbService = new DataBaseService())
            {
                dbService.SetConfiguration(SetDBConfigurationAndClearScoreAndDriverInfoTable());

                TaxiDriver.Champion[] champions =
                {
                    new TaxiDriver.Champion(1, "Petro", 120),
                    new TaxiDriver.Champion(2, "Taras", 110),
                    new TaxiDriver.Champion(3, "Taras", 80),
                    new TaxiDriver.Champion(4, "Oleg", 70)
                };

                SaveSomeDriverInfoToDB(dbService);

                int amount = 4;
                TaxiDriver.Champion[] championFromDB = dbService.GetBest(amount);
                for (int i = 0; i < championFromDB.Length; ++i)
                {
                    Assert.AreEqual(champions[i].Number, championFromDB[i].Number);
                    Assert.AreEqual(champions[i].Name, championFromDB[i].Name);
                    Assert.AreEqual(champions[i].Score, championFromDB[i].Score);
                }

                amount = 10;
                championFromDB = dbService.GetBest(amount);
                for (int i = 0; i < championFromDB.Length; ++i)
                {
                    Assert.AreEqual(champions[i].Number, championFromDB[i].Number);
                    Assert.AreEqual(champions[i].Name, championFromDB[i].Name);
                    Assert.AreEqual(champions[i].Score, championFromDB[i].Score);
                }

                amount = 2;
                championFromDB = dbService.GetBest(amount);
                for (int i = 0; i < championFromDB.Length; ++i)
                {
                    Assert.AreEqual(champions[i].Number, championFromDB[i].Number);
                    Assert.AreEqual(champions[i].Name, championFromDB[i].Name);
                    Assert.AreEqual(champions[i].Score, championFromDB[i].Score);
                }
            }
        }
    }
}
