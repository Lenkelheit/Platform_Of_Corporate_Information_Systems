using DataControl.Services;
using DataControl.ViewModel;

namespace Task5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        DataControl.Interfaces.IDataAccessService dataAccessService;

        public MainWindow()
        {
            InitializeComponent();

            /*
            dataAccessService = new CsvFileService()
                .SetConfiguration(
                new FileConfiguration()
                {
                    ClientFile = @"Resources\files\Client.csv",
                    DriverFile = @"Resources\files\Driver.csv",
                    RouteFile = @"Resources\files\Route.csv",
                    ScoreFile = @"Resources\files\Score.csv",
                    StreetFile = @"Resources\files\Street.csv",
                });
            */
            dataAccessService = new DataBaseService().SetConfiguration(new DBConfiguration());

            this.DataContext = new ApplicationViewModel(dataAccessService);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DataContext = null;
            if (dataAccessService is System.IDisposable) ((System.IDisposable)dataAccessService).Dispose();

        }
    }
}
