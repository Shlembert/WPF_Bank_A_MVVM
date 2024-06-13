using BankA_MVVM_Library.Models;
using BankA_MVVM.ViewModels;
using System.Windows;

namespace BankA_MVVM_UI.Views
{
    public partial class NewAccountWindow : Window
    {
        private NewAccountWindowViewModel _viewModel;

        public NewAccountWindow(Client client)
        {
            InitializeComponent();
            _viewModel = new NewAccountWindowViewModel(client);
            _viewModel.AccountAdded += (sender, account) =>
            {
                // Обработка события AccountAdded
            };
            DataContext = _viewModel;
        }
    }
}
