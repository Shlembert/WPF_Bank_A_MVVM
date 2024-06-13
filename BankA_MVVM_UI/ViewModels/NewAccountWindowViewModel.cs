using BankA_MVVM_Library.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BankA_MVVM.ViewModels
{
    public class NewAccountWindowViewModel : ViewModelBase
    {
        private string _accountNumber;
        public string AccountNumber
        {
            get => _accountNumber;
            set
            {
                _accountNumber = value;
                OnPropertyChanged();
            }
        }

        private bool _isDepositAccount;
        public bool IsDepositAccount
        {
            get => _isDepositAccount;
            set
            {
                _isDepositAccount = value;
                OnPropertyChanged();
            }
        }

        public ICommand GenerateAccountNumberCommand { get; }
        public ICommand DoneCommand { get; }
        public ICommand CancelCommand { get; }

        public event EventHandler<Account> AccountAdded;

        private readonly Client _client;

        public NewAccountWindowViewModel(Client client)
        {
            _client = client;
            GenerateAccountNumberCommand = new RelayCommand(GenerateAccountNumber);
            DoneCommand = new RelayCommand(Done);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void GenerateAccountNumber()
        {
            Random random = new Random();
            AccountNumber = random.Next(100000000, 999999999).ToString();
        }

        private void Done()
        {
            if (string.IsNullOrEmpty(AccountNumber))
            {
                MessageBox.Show("Сначала сгенерируйте номер счета.");
                return;
            }

            string accountNumber = AccountNumber.Replace(" ", "");
            decimal initialBalance = 0;

            Account newAccount = null;
            if (IsDepositAccount)
            {
                newAccount = new DepositAccount(int.Parse(accountNumber), "Депозитный", initialBalance);
            }
            else
            {
                newAccount = new NonDepositAccount(int.Parse(accountNumber), "Недепозитный", initialBalance);
            }

            if (newAccount != null)
            {
                _client.Accounts.Add(newAccount);
                AccountAdded?.Invoke(this, newAccount);
                LogOperation("Создан новый счет", newAccount);
            }
            Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive)?.Close();
        }

        private void Cancel()
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive)?.Close();
        }

        private void LogOperation(string operation, Account account)
        {
            string logMessage = $"{DateTime.Now}: {operation} - Счет №{account.AccountNumber}, Баланс: {account.Balance}";
            // Реализуйте ваш механизм логирования здесь
        }
    }
}
