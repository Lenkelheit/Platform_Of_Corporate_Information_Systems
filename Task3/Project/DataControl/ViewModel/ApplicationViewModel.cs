using System.Timers;

using DataControl.Interfaces;
using DataControl.Services;
using DataControl.Commands;

using TaxiDriver;
using Task3.Forms;

using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DataControl.ViewModel
{
    /// <summary>
    /// A class that bond view and models.
    /// </summary>
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        // CONSTANTS
        const int SESION_TIME = 30;
        const double PENALTY_SCORE = 50;

        // FIELDS
        private IDataAccessService dataAccessService;

        Driver currentDriver;
        Order selectedOrder;
        ObservableCollection<Order> orders;
        Timer sessionTimer;
        double currentScore;
        bool isSessionContinuing;
        string login;
        string password;
        ObservableCollection<Champion> champions;
        System.Random randomizer;

        #region Windows
        CabinetWindow cabinetWindow;
        LogInWindow loginWindow;
        ProgressWindow progressWindow;
        ScoreWindow scoreWindow;
        MessageBoxWindow messageWindow; 
        #endregion

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

        // EVENTS
        /// <summary>
        /// Event that invokes when some propery changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        // CONSTRUCTORS
        /// <summary>
        /// Basic constructor with 1 parametr
        /// </summary>
        /// <param name="dataAccessService">Programs dataAccessService</param>
        public ApplicationViewModel(IDataAccessService dataAccessService)
        {
            this.dataAccessService = dataAccessService;
            orders = new ObservableCollection<Order>();
            sessionTimer = new Timer();
            randomizer = new System.Random();
            messageWindow = new MessageBoxWindow()
            {
                DataContext = this
            };
            cabinetWindow = new CabinetWindow()
            {
                DataContext = this
            };
            loginWindow = new LogInWindow()
            {
                DataContext = this
            };
            scoreWindow = new ScoreWindow()
            {
                DataContext = this
            };

            #region Commands Initialize
            logIn = new RelayCommand(LogInMethod, IsNotAuthorized);
            logOut = new RelayCommand(LogInMethod, IsAuthorized);
            signUp = new RelayCommand(SignUpMethod);
            startGame = new RelayCommand(StartGameMethod, IsNotSessiontContinuing);
            executeOrder = new RelayCommand(ExecuteOrderMethod, IsSessionContinuing);
            searchOrder = new RelayCommand(SearchOrderMethod, IsSessionContinuing);
            removeOrder = new RelayCommand(RemoveOrderMethod, IsSessionContinuing);
            showCabinetOrRegistrate = new RelayCommand(ShowCabinetOrRegistrateMethod);
            showScores = new RelayCommand(ShowScoresMethod);
            #endregion

        }



        // PROPERTIES
        /// <summary>
        /// Propetry that enable to interract with current driver
        /// </summary>
        /// <returns>Current driver</returns>
        public Driver CurrentDriver
        {
            get
            {
                return currentDriver;
            }
        }
        /// <summary>
        /// Propetry that enable to interract with selected order
        /// </summary>
        /// <returns>Selected order</returns>
        public Order SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
        }
        /// <summary>
        /// Propetry that enable to interract with orders collection
        /// </summary>
        /// <returns>Orders</returns>
        public ObservableCollection<Order> Orders
        {
            get
            {
                return orders;
            }
        }
        /// <summary>
        /// Propetry that enable to interract with time
        /// </summary>
        /// <returns>Time</returns>
        public System.TimeSpan Time
        {
            get
            {
                return System.TimeSpan.FromMilliseconds(SESION_TIME);
            }
        }
        /// <summary>
        /// Propetry that enable to interract with current score
        /// </summary>
        /// <returns>Current score</returns>
        public double CurrentScore
        {
            get
            {
                return currentScore;
            }
        }
        /// <summary>
        /// Propetry that enable to interract with championes
        /// </summary>
        /// <returns>Championes</returns>
        public ObservableCollection<Champion> Champions
        {
            get
            {
                return champions;
            }
        }
        /// <summary>
        /// Property that enable to interruct with user password
        /// </summary>
        /// <returns>User password</returns>
        public string Password
        {
            set
            {
                password = value;
            }
        }
        /// <summary>
        /// Property that enable to interruct with user login
        /// </summary>
        /// <returns>User login</returns>
        public string Login
        {
            set
            {
                login = value;
            }
        }

        #region Commands
        /// <summary>
        /// Property that enable to interruct with Log In command
        /// </summary>
        /// <returns>Log In command</returns>
        public RelayCommand LogIn => logIn;
        /// <summary>
        /// Property that enable to interruct with Log Out command
        /// </summary>
        /// <returns>Log Out command</returns>
        public RelayCommand LogOut => logOut;
        /// <summary>
        /// Property that enable to interruct with Sign Up command
        /// </summary>
        /// <returns>Sign Up command</returns>
        public RelayCommand SignUp => signUp;
        /// <summary>
        /// Property that enable to interruct with Start Game command
        /// </summary>
        /// <returns>Start Game command</returns>
        public RelayCommand StartGame => startGame;
        /// <summary>
        /// Property that enable to interruct with Execute Order command
        /// </summary>
        /// <returns>ExecuteOrder command</returns>
        public RelayCommand ExecuteOrder => executeOrder;
        /// <summary>
        /// Property that enable to interruct with Search Order command
        /// </summary>
        /// <returns>Search Order command</returns>
        public RelayCommand SearchOrder => searchOrder;
        /// <summary>
        /// Property that enable to interruct with Remove Order command
        /// </summary>
        /// <returns>Remove Order command</returns>
        public RelayCommand RemoveOrder => removeOrder;
        /// <summary>
        /// Property that enable to interruct with Show Cabinet Or Registrate command
        /// </summary>
        /// <returns>Show Cabinet Or Registrate command</returns>
        public RelayCommand ShowCabinetOrRegistrate => showCabinetOrRegistrate;
        /// <summary>
        /// Property that enable to interruct with Show Scores command
        /// </summary>
        /// <returns>Show Scores command</returns>
        public RelayCommand ShowScores => showScores;
        #endregion

        // METHODS
        #region Commands
        private void LogInMethod(object obj)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                messageWindow.HeaderText = "Empty Login";
                messageWindow.ContentText = "Login can't be empty!";
                messageWindow.ShowDialog();
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                messageWindow.HeaderText = "Empty Password";
                messageWindow.ContentText = "Password can't be empty!";
                messageWindow.ShowDialog();
            }
            if (dataAccessService.LogIn(login, password))
            {
                currentDriver = dataAccessService.Driver;
            }
            else
            {
                messageWindow.HeaderText = "Account problem";
                messageWindow.ContentText  = dataAccessService.Message;
                messageWindow.ShowDialog();
            }
        }
        private void LogOutMethod(object obj)
        {
            currentDriver = null;
            password = null;
            login = null;
            orders.Clear();
            selectedOrder = null;
        }
        private void SignUpMethod(object obj)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                messageWindow.HeaderText = "Empty Login";
                messageWindow.ContentText = "Login can't be empty!";
                messageWindow.ShowDialog();
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                messageWindow.HeaderText = "Empty Password";
                messageWindow.ContentText = "Password can't be empty!";
                messageWindow.ShowDialog();
            }
            if (dataAccessService.SignUp(login, password))
            {
                currentDriver = dataAccessService.Driver;
            }
            else
            {
                messageWindow.HeaderText = "Account problem";
                messageWindow.ContentText = dataAccessService.Message;
                messageWindow.ShowDialog();
            }
        }
        private void StartGameMethod(object obj)
        {
            if (!isSessionContinuing && currentDriver != null)
            {
                sessionTimer = new Timer(SESION_TIME);
                sessionTimer.Elapsed += GameEnded;
                sessionTimer.Start();
                isSessionContinuing = true; 
            }
        }
        private void ExecuteOrderMethod(object obj)
        {
            progressWindow = new ProgressWindow(selectedOrder.Route.Time)
            {
                DataContext = this
            };
                progressWindow.ShowDialog();
                if (progressWindow.DialogResult == true)
                {
                    currentScore += selectedOrder.Route.Price;
                }
                else
                {
                    currentScore -= PENALTY_SCORE;
                }
                orders.Remove(selectedOrder); 
        }
        private void SearchOrderMethod(object obj)
        {
            orders.Add(dataAccessService.GetRandomOrder());
        }
        private void RemoveOrderMethod(object obj)
        {
            orders.Remove(selectedOrder);
        }
        private void ShowCabinetOrRegistrateMethod(object obj)
        {
            cabinetWindow.ShowDialog();
        }
        private void ShowScoresMethod(object obj)
        {
            scoreWindow.ShowDialog();
        }
        #endregion

        /// <summary>
        /// Method that invokes Property Change event
        /// </summary>
        /// <param name="e">Property Changed Event Args</param>
        protected void OnPropertyChange(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }

        private void GameEnded(object sender, ElapsedEventArgs e)
        {
            isSessionContinuing = false;
            dataAccessService.SaveResult(currentDriver);
            selectedOrder = null;
            orders = null;
        }

        private bool IsSessionContinuing(object o)
        {
            return isSessionContinuing;
        }

        private bool IsNotSessiontContinuing(object o)
        {
            return !isSessionContinuing;
        }

        private bool IsAuthorized(object o)
        {
            return currentDriver != null;
        }

        private bool IsNotAuthorized(object o)
        {
            return currentDriver == null;
        }
    }
}
