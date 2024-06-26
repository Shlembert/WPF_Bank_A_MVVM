﻿using BankA_MVVM_Library.Models;
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
            if (DataContext is ClientDetailsViewModel viewModel)
            {
                viewModel.AddNewAccount();
            }
        }

        private void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ClientDetailsViewModel viewModel)
            {
                viewModel.DeleteSelectedAccount();
            }
        }

        private void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ClientDetailsViewModel viewModel)
            {
                viewModel.TransferBetweenAccounts();
            }
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ClientDetailsViewModel viewModel)
            {
                viewModel.DepositToSelectedAccount();
            }
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ClientDetailsViewModel viewModel)
            {
                viewModel.WithdrawFromSelectedAccount();
            }
        }
    }
}
