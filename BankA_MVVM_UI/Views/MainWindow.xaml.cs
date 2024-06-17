using System.Windows;
using BankA_MVVM.ViewModels;

namespace BankA_MVVM_UI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
