namespace Task5.Forms
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : System.Windows.Window
    {
        System.TimeSpan timeSpan;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        double incrementValue;
        
        public ProgressWindow(System.TimeSpan timeSpan)
        {
            InitializeComponent();

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new System.EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = System.TimeSpan.FromSeconds(1D);

            this.timeSpan = timeSpan;
            incrementValue = 100 / timeSpan.Seconds;
        }

        private void dispatcherTimer_Tick(object sender, System.EventArgs e)
        {
            this.ProgressBar.Value += incrementValue;
        }

        private void MovingWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Exit(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ProgressBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue >= ProgressBar.Maximum)
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dispatcherTimer.Stop();
        }
    }
}
