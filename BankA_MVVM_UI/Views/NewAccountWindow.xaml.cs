using BankA_MVVM_Library.Models;
using BankA_MVVM_Library.Services;
using BankA_MVVM_UI.ViewModels;
using System.Windows;

namespace BankA_MVVM_UI.Views
{
    public partial class NewAccountWindow : Window
    {
        private NewAccountWindowViewModel _viewModel;

        public NewAccountWindow(Client client)
        {
            InitializeComponent();
            var clientDataHandler = new ClientDataHandler();
            var accountOperations = new AccountOperations(); // Создание экземпляра AccountOperations или другой подходящей реализации IAccountOperations<BankAccount>
            _viewModel = new NewAccountWindowViewModel(client, clientDataHandler, accountOperations);
            _viewModel.AccountAdded += (sender, account) =>
            {
                // Обработка события AccountAdded, например, закрытие окна
                Close();
            };
            DataContext = _viewModel;
        }
    }
}
