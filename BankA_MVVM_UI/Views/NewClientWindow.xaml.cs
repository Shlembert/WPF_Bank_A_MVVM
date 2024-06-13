using BankA_MVVM.ViewModels;
using BankA_MVVM_Library.Models;
using System;
using System.Windows;

namespace BankA_MVVM_UI.Views
{
    public partial class NewClientWindow : Window
    {
        public event EventHandler<Client> ClientAdded;

        public NewClientWindow()
        {
            InitializeComponent();

            var viewModel = DataContext as NewClientWindowViewModel;
            viewModel.ClientAdded += (sender, client) =>
            {
                ClientAdded?.Invoke(this, client);
                this.Close();
            };
        }
    }
}
