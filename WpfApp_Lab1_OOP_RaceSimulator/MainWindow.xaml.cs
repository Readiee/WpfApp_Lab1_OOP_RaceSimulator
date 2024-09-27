using System.Windows;

namespace WpfApp_Lab1_OOP_RaceSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.ViewModel();
        }

    }
}
