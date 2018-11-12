namespace Task3.Forms
{
    /// <summary>
    /// Interaction logic for MessageBoxWindow.xaml
    /// </summary>
    public partial class MessageBoxWindow : System.Windows.Window
    {
        public MessageBoxWindow()
        {
            InitializeComponent();
        }
        public string HeaderText
        {
            get
            {
                return Header.Content.ToString();
            }
            set
            {
                Header.Content = value;
            }
        }
        public string ContentText
        {
            get
            {
                return Text.Text.ToString();
            }
            set
            {
                Text.Text = value;
            }
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
            this.Close();
        }
    }
}
