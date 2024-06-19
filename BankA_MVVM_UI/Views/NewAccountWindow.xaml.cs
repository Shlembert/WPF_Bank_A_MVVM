using BankA_MVVM_Library.Models;
using BankA_MVVM_Library.Services;
using System;
using System.Windows;

namespace BankA_MVVM_UI.Views
{
    public partial class NewAccountWindow : Window
    {
        public event EventHandler<Account> AccountAdded;

        public NewAccountWindow(Client client)
        {
            InitializeComponent();
            var viewModel = new NewAccountWindowViewModel(client, new ClientDataHandler(), new BankAccountOperations());
            viewModel.AccountAdded += (s, e) => AccountAdded?.Invoke(this, e);
            DataContext = viewModel;
        }
    }
}
