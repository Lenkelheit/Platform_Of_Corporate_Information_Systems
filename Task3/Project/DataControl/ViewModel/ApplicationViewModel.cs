using DataControl.Interfaces;
using DataControl.Services;
using DataControl.Commands;

using TaxiDriver;

using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DataControl.ViewModel
{
    /// <summary>
    /// A class that bond view and models.
    /// </summary>
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        // FIELDS
        private IDataAccessService dataAccessService;

        #region Commands
        private RelayCommand logIn;
        private RelayCommand logOut;
        private RelayCommand signUp;

        private RelayCommand startGame;
        private RelayCommand executeOrder;
        private RelayCommand searchOrder;
        private RelayCommand removeOrder;
        
        private RelayCommand showCabinetOrRegistrate;
        private RelayCommand showScores;
        #endregion
        // EVENT
        public event PropertyChangedEventHandler PropertyChanged;
        // CONSTRUCTORS
        public ApplicationViewModel(IDataAccessService dataAccessService)
        {

        }
        // PROPERTIES
        public Driver CurrentDriver
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public Order SelectedOrder
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public ObservableCollection<Order> Orders
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public System.TimeSpan Time
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public double CurrentScore
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        public ObservableCollection<Сhampion> Champions
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        #region Commands
        public RelayCommand LogIn => logIn;
        public RelayCommand LogOut => logOut;
        public RelayCommand SignUp => signUp;

        public RelayCommand StartGame => startGame;
        public RelayCommand ExecuteOrder => executeOrder;
        public RelayCommand SearchOrder => searchOrder;
        public RelayCommand RemoveOrder => removeOrder;

        public RelayCommand ShowCabinetOrRegistrate => showCabinetOrRegistrate;
        public RelayCommand ShowScores => showScores;
        #endregion

        // METHODS
        #region Commands
        private void LogInMethod(object obj)
        {
            throw new System.NotImplementedException();
        }
        private void LogOutMethod(object obj)
        {
            throw new System.NotImplementedException();
        }
        private void SignUpMethod(object obj)
        {
            throw new System.NotImplementedException();
        }

        private void StartGameMethod(object obj)
        {
            throw new System.NotImplementedException();
        }
        private void ExecuteOrderMethod(object obj)
        {
            throw new System.NotImplementedException();
        }
        private void SearchOrderMethod(object obj)
        {
            throw new System.NotImplementedException();
        }
        private void RemoveOrderMethod(object obj)
        {
            throw new System.NotImplementedException();
        }

        private void ShowCabinetOrRegistrateMethod(object obj)
        {
            throw new System.NotImplementedException();
        }
        private void ShowScoresMethod(object obj)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        protected void OnPropertyChange(PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
