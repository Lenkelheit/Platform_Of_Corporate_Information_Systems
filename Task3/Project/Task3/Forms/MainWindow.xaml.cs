using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Forms.CabinetWindow cabinet = new Forms.CabinetWindow();
            cabinet.ShowDialog();

            Forms.LogInWindow logIn = new Forms.LogInWindow();
            logIn.ShowDialog();

            Forms.MessageBoxWindow messageBox = new Forms.MessageBoxWindow();
            messageBox.ShowDialog();

            Forms.ProgressWindow progress = new Forms.ProgressWindow();
            progress.ShowDialog();

            Forms.ScoreWindow score = new Forms.ScoreWindow();
            score.ShowDialog();
        }
    }
}
