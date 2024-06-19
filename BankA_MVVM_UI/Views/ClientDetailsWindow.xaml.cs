using BankA_MVVM_Library.Models;
using BankA_MVVM_Library.Services;
using BankA_MVVM.ViewModels;
using System.Windows;

namespace BankA_MVVM_UI.Views
{
    public partial class ClientDetailsWindow : Window
    {
        private ClientDetailsViewModel _viewModel;

        public ClientDetailsWindow(Client client, IClientDataHandler clientDataHandler)
        {
            InitializeComponent();
            _viewModel = new ClientDetailsViewModel(client, clientDataHandler);
            DataContext = _viewModel;
        }

        private void NewAccountButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddNewAccount();
            _viewModel.RefreshAccounts(); // Обновляем список счетов после добавления нового счета
        }

        private void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteSelectedAccount();
        }

        private void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.TransferBetweenAccounts();
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DepositToSelectedAccount();
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.WithdrawFromSelectedAccount();
        }
    }
}
