using DataControl.Interfaces;
using DataControl.Commands;

using TaxiDriver;
using Task5.Forms;

using System.Windows.Threading;
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
        const int START_ORDER_AMOUNT = 5;
        const int SESION_TIME = 30;
        const double PENALTY_SCORE = 50;
        const double PENALTY_TIME = 2;
        const double ORDER_CHANCE_TO_APPEAR = 0.05;// 5%

        // FIELDS
        IDataAccessService dataAccessService;
        DispatcherTimer sessionTimer;
        System.Random randomizer;

        bool isDataRequireUpdate;
        bool gameRunning;
        System.TimeSpan gameTime;

        string login;
        string password;
        double currentScore;
        Driver currentDriver;
        Order selectedOrder;
        ObservableCollection<Order> orders;
        Champion[] champions;

        #region Windows
        LogInWindow logInWindow;
        CabinetWindow cabinetWindow;
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
            this.sessionTimer = new DispatcherTimer()
            {
                Interval = System.TimeSpan.FromSeconds(1)
            };
            this.randomizer = new System.Random();

            this.isDataRequireUpdate = true;
            this.gameRunning = false;
            this.gameTime = System.TimeSpan.FromSeconds(0);
            this.orders = new ObservableCollection<Order>();
            this.champions = null;

            #region Window Initialize
            logInWindow = null;
            cabinetWindow = null;
            #endregion

            #region Commands Initialize
            logIn = new RelayCommand(LogInMethod, IsNotAuthorized);
            logOut = new RelayCommand(LogOutMethod, IsAuthorized);
            signUp = new RelayCommand(SignUpMethod, IsNotAuthorized);

            startGame = new RelayCommand(StartGameMethod, AuthorizedAndGameIsNotRunning);
            executeOrder = new RelayCommand(ExecuteOrderMethod, GameRunningAndOrderSelected);
            searchOrder = new RelayCommand(SearchOrderMethod, GameRunning);
            removeOrder = new RelayCommand(RemoveOrderMethod, GameRunningAndOrderSelected);

            showCabinetOrRegistrate = new RelayCommand(ShowCabinetOrRegistrateMethod, GameIsNotRunning);
            showScores = new RelayCommand(ShowScoresMethod);
            #endregion

            sessionTimer.Tick += SessionTimer_Tick;
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
            set
            {
                currentDriver = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentDriver)));
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
            set
            {
                selectedOrder = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedOrder)));
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
                return gameTime;
            }
            set
            {
                gameTime = gameTime.Subtract(value);
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Time)));

                if (TimeEnded())
                {
                    sessionTimer.Stop();
                    // game ended logic
                    currentDriver.LastScore = CurrentScore;                 
                    ExecuteMessageWindow("End of watch", $"Congratulation, your score is {CurrentScore}");
                    gameRunning = false;
                    isDataRequireUpdate = true;
                    try
                    {
                        dataAccessService.SaveResult(currentDriver);
                    }
                    catch (System.IO.IOException ex)
                        when (ex is System.IO.FileNotFoundException || ex is System.IO.DirectoryNotFoundException)
                    {
                        ExecuteMessageWindow("Error", "Result has not been saved. Data file is missing.");
                    }
                    Clear();
                }
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
            set
            {
                if (value != currentScore)
                {
                    currentScore = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("CurrentScore"));
                }
            }
        }
        /// <summary>
        /// Propetry that enable to interract with championes
        /// </summary>
        /// <returns>Championes</returns>
        public Champion[] Champions
        {
            get
            {
                return champions;
            }
            set
            {
                if (isDataRequireUpdate)
                {
                    champions = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Champions)));
                    isDataRequireUpdate = false;
                }
            }
        }
        /// <summary>
        /// Property that enable to interruct with user password
        /// </summary>
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
        private void ShowCabinetOrRegistrateMethod(object obj)
        {
            if (IsAuthorized(obj))
            {
                cabinetWindow = new CabinetWindow() { DataContext = this };
                cabinetWindow.ShowDialog();
            }
            else
            {
                logInWindow = new LogInWindow() { DataContext = this };
                logInWindow.ShowDialog();
            }
        }
        private void LogInMethod(object obj)
        {
            // checking
            if (CheckRegistrateFields())
            {
                // logic
                bool logInRes;
                try
                {
                    logInRes = dataAccessService.LogIn(login, password);
                }
                catch (System.IO.IOException ex)
                    when (ex is System.IO.FileNotFoundException || ex is System.IO.DirectoryNotFoundException)
                {
                    ExecuteMessageWindow("Error", "Log in operation is unavailable. Data file is missing");
                    return;
                }

                if (logInRes)
                {
                    CurrentDriver = dataAccessService.Driver;
                    logInWindow.Close();
                }
                else
                {
                    ExecuteMessageWindow("Account problem", dataAccessService.Message);
                }
            }
        }
        private void SignUpMethod(object obj)
        {
            // checking
            if (CheckRegistrateFields())
            {
                // logic
                bool signUpRes;
                try
                {
                    signUpRes = dataAccessService.SignUp(login, password);
                }
                catch (System.IO.IOException ex)
                    when (ex is System.IO.FileNotFoundException || ex is System.IO.DirectoryNotFoundException)
                {
                    ExecuteMessageWindow("Error", "Sign up operation is unavailable. Data file is missing");
                    return;
                }

                if (signUpRes)
                {
                    CurrentDriver = dataAccessService.Driver;
                    logInWindow.Close();
                }
                else
                {
                    ExecuteMessageWindow("Account problem", dataAccessService.Message);
                }
            }
        }
        private void LogOutMethod(object obj)
        {
            CurrentDriver = null;
            Clear();
            cabinetWindow.Close();
        }
        
        private void StartGameMethod(object obj)
        {
            if (GameIsNotRunning(obj) && IsAuthorized(obj))
            {
                gameTime = System.TimeSpan.FromSeconds(SESION_TIME);
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Time)));
                for (int i = 0; i < START_ORDER_AMOUNT; ++i)
                {
                    orders.Add(dataAccessService.GetRandomOrder());
                }

                sessionTimer.Start();
                gameRunning = true;               
            }
        }
        private void ExecuteOrderMethod(object obj)
        {
            ProgressWindow progressWindow = new ProgressWindow(selectedOrder.Route.Time);
            progressWindow.ShowDialog();

            if (selectedOrder != null)
            {
                if (progressWindow.DialogResult == true)
                {
                    CurrentScore += selectedOrder.Route.Price;
                    orders.Remove(selectedOrder);
                }
                else
                {
                    CurrentScore -= PENALTY_SCORE;
                }
            }
        }
        private void SearchOrderMethod(object obj)
        {
            try
            {
                orders.Add(dataAccessService.GetRandomOrder());
            }
            catch (System.IO.IOException ex)
                    when (ex is System.IO.FileNotFoundException || ex is System.IO.DirectoryNotFoundException)
            {
                ExecuteMessageWindow("Error", "There is no spoon");
            }
            Time = System.TimeSpan.FromSeconds(PENALTY_TIME);  
        }
        private void RemoveOrderMethod(object obj)
        {
            orders.Remove(selectedOrder);
            SelectedOrder = orders.Count > 0 ? System.Linq.Enumerable.Last(orders) : null;
        }
        private void ShowScoresMethod(object obj)
        {
            try
            {
                Champions = dataAccessService.GetBest(10);
            }
            catch (System.IO.IOException ex)
                    when (ex is System.IO.FileNotFoundException || ex is System.IO.DirectoryNotFoundException)
            {
                ExecuteMessageWindow("Error", "Operation is unavailable. Data file is missing");
                return;
            }
            new ScoreWindow() { DataContext = this }.ShowDialog();
        }
        #endregion

        #region Restriction
        private bool GameRunning(object o)
        {
            return gameRunning;
        }
        private bool GameRunningAndOrderSelected(object o)
        {
            return gameRunning && selectedOrder != null;
        }
        private bool GameIsNotRunning(object o)
        {
            return !gameRunning;
        }
        private bool AuthorizedAndGameIsNotRunning(object o)
        {
            return CurrentDriver != null && !gameRunning;
        }
        private bool IsAuthorized(object o)
        {
            return CurrentDriver != null;
        }

        private bool IsNotAuthorized(object o)
        {
            return CurrentDriver == null;
        }
        private bool TimeEnded()
        {
            return gameTime.TotalSeconds <= 0;
        }
        #endregion
        #region Additional Methods
        private void SessionTimer_Tick(object sender, System.EventArgs e)
        {
            // slowly loosing time
            Time = System.TimeSpan.FromSeconds(1);

            // sometimes add order
            if (randomizer.NextDouble() < ORDER_CHANCE_TO_APPEAR)
            {
                try
                {
                    orders.Add(dataAccessService.GetRandomOrder());
                }
                catch (System.IO.IOException ex)
                    when (ex is System.IO.FileNotFoundException || ex is System.IO.DirectoryNotFoundException)
                {
                    // ignore
                }
            }
        }
        private bool CheckRegistrateFields()
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                ExecuteMessageWindow("Empty Login", "Login can not be empty!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                ExecuteMessageWindow("Empty Password", "Password can not be empty!");
                return false;
            }
            return true;
        }
        private void ExecuteMessageWindow(string headerText, string contentText)
        {
            new MessageBoxWindow()
            {
                HeaderText = headerText,
                ContentText = contentText
            }.ShowDialog();
        }
        private void Clear()
        {
            Password = null;
            Login = null;
            SelectedOrder = null;
            CurrentScore = 0;
            gameTime = System.TimeSpan.FromSeconds(0);
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Time)));
            orders.Clear();
        }
        #endregion
        #region Event Raising
        /// <summary>
        /// Method that invokes Property Change event
        /// </summary>
        /// <param name="e">Property Changed Event Args</param>
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        #endregion
    }
}
