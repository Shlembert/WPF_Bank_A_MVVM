using System;
using System.ComponentModel;
using System.Windows.Input;
using BankA_MVVM.ViewModels;
using BankA_MVVM_Library.Models;
using BankA_MVVM_Library.Services;

namespace BankA_MVVM_UI.ViewModels
{
    public class NewAccountWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
                if (_isDepositAccount != value)
                {
                    _isDepositAccount = !value;
                    OnPropertyChanged(nameof(IsDepositAccount));
                    OnPropertyChanged(nameof(IsNonDepositAccount));
                }
            }
        }

        public event EventHandler<Account> AccountAdded;
        private readonly Client _client;
        private readonly IClientDataHandler _clientDataHandler;
        private readonly BankA_MVVM_Library.Models.IAccountOperations<BankAccount> _accountOperations;

        public NewAccountWindowViewModel(Client client, IClientDataHandler clientDataHandler, BankA_MVVM_Library.Models.IAccountOperations<BankAccount> accountOperations)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _clientDataHandler = clientDataHandler ?? throw new ArgumentNullException(nameof(clientDataHandler));
            _accountOperations = accountOperations ?? throw new ArgumentNullException(nameof(accountOperations));

            DoneCommand = new RelayCommand(AddAccount);
            CancelCommand = new RelayCommand(Cancel);
            GenerateAccountNumberCommand = new RelayCommand(GenerateAccountNumber);
        }

        public ICommand DoneCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand GenerateAccountNumberCommand { get; private set; }

        private void AddAccount(object parameter)
        {
            string accountType = IsDepositAccount ? "Депозитный" : "Не депозитный";
            BankAccount newAccount = CreateAccount(accountType);
            if (newAccount != null)
            {
                AccountAdded?.Invoke(this, newAccount);
                SaveAccount(newAccount);
            }
        }

        private BankAccount CreateAccount(string accountType)
        {
            int accountId = GenerateAccountId();
            int accountNumber = GenerateAccountNumber();
            decimal initialBalance = 0;
            DateTime createdDate = DateTime.Now;

            return _accountOperations.CreateAccount(accountId, accountNumber, accountType, initialBalance, createdDate);
        }

        private void SaveAccount(Account account)
        {
            var clients = _clientDataHandler.LoadClients();
            var existingClient = clients.Find(c => c.Id == _client.Id);
            if (existingClient != null)
            {
                existingClient.Accounts.Add(account);
            }
            else
            {
                _client.Accounts.Add(account);
                clients.Add(_client);
            }
            _clientDataHandler.SaveClients(clients);
        }

        private int GenerateAccountId()
        {
            // Логика генерации ID счета
            return 0; // Замените на вашу реализацию
        }

        private int GenerateAccountNumber()
        {
            // Логика генерации номера счета
            return 0; // Замените на вашу реализацию
        }

        private void GenerateAccountNumber(object parameter)
        {
            // Логика генерации номера счета
            int accountNumber = GenerateNumber();
            // Вызов метода или логика, связанная с сгенерированным номером счета
        }

        private void Cancel(object parameter)
        {
            // Логика отмены операции (закрытие окна или что-то еще)
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int GenerateNumber()
        {
            // Ваша реализация генерации номера счета
            return new Random().Next(100000, 999999);
        }
    }
}
