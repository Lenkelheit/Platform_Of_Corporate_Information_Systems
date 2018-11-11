using DataControl.Services;
using DataControl.ViewModel;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ApplicationViewModel(
                new CsvFileService()
                    .SetConfiguration(
                        new FileConfiguration()
                        {
                            ClientFile = @"Resources\files\Client.csv",
                            DriverFile = @"Resources\files\Driver.csv",
                            RouteFile = @"Resources\files\Route.csv",
                            ScoreFile = @"Resources\files\Score.csv",
                            StreetFile = @"Resources\files\Street.csv",
                        }));
        }
    }
}
