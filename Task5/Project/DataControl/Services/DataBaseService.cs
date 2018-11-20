using System;
using DataControl.Interfaces;
using TaxiDriver;

namespace DataControl.Services
{
    public class DataBaseService : Interfaces.IDataAccessService
    {
        DBConfiguration dbConfiguration;

        public Driver Driver
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Message
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Champion[] GetBest(int amount)
        {
            throw new NotImplementedException();
        }

        public Order GetRandomOrder()
        {
            throw new NotImplementedException();
        }

        public bool LogIn(string name, string password)
        {
            throw new NotImplementedException();
        }

        public void SaveResult(Driver driver)
        {
            throw new NotImplementedException();
        }

        public IDataAccessService SetConfiguration(IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public bool SignUp(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
