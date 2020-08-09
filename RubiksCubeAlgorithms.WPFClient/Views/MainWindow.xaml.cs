using System.Windows;
using RubiksCubeAlgorithms.WPF.ViewModels;

namespace RubiksCubeAlgorithms.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
