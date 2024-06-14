using System;
using System.ComponentModel;
using BankA_MVVM_Library.Models;

namespace BankA_MVVM_UI.ViewModels
{
    public class NewAccountWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<Account> AccountAdded; // Добавляем событие AccountAdded

        private bool _isDepositAccount;
        public bool IsDepositAccount
        {
            get { return _isDepositAccount; }
            set
            {
                if (_isDepositAccount != value)
                {
                    _isDepositAccount = value;
                    OnPropertyChanged(nameof(IsDepositAccount));
                    OnPropertyChanged(nameof(IsNonDepositAccount));
                }
            }
        }

        public bool IsNonDepositAccount
        {
            get { return !_isDepositAccount; }
            set
            {
                if (_isDepositAccount == value)
                {
                    _isDepositAccount = !value;
                    OnPropertyChanged(nameof(IsDepositAccount));
                    OnPropertyChanged(nameof(IsNonDepositAccount));
                }
            }
        }

        public NewAccountWindowViewModel(Client client)
        {
            // Your existing initialization code for client
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Метод для вызова события AccountAdded
        private void OnAccountAdded(Account account)
        {
            AccountAdded?.Invoke(this, account);
        }
    }
}
