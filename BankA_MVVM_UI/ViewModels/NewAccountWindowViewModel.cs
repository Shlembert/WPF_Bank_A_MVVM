using BankA_MVVM_Library.Models;
using BankA_MVVM_Library.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;

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

    private string _generatedAccountNumber = string.Empty;
    public string GeneratedAccountNumber
    {
        get { return _generatedAccountNumber; }
        set
        {
            _generatedAccountNumber = value;
            OnPropertyChanged(nameof(GeneratedAccountNumber));
        }
    }

    public event EventHandler<Account> AccountAdded;
    private readonly Client _client;
    private readonly IClientDataHandler _clientDataHandler;
    private readonly IAccountOperations<BankAccount> _accountOperations;

    public NewAccountWindowViewModel(Client client, IClientDataHandler clientDataHandler, IAccountOperations<BankAccount> accountOperations)
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
            CloseWindow();
        }
    }

    private BankAccount CreateAccount(string accountType)
    {
        string accountNumber = GeneratedAccountNumber;
        decimal initialBalance = 0;
        DateTime createdDate = DateTime.Now;
        int id = 0; // или другая логика генерации id

        return _accountOperations.CreateAccount(id, accountNumber, accountType, initialBalance, createdDate);
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

    private void GenerateAccountNumber(object parameter)
    {
        GeneratedAccountNumber = GenerateNumber();
    }

    private string GenerateNumber()
    {
        var random = new Random();
        var accountNumber = new char[20];
        for (int i = 0; i < accountNumber.Length; i++)
        {
            accountNumber[i] = (char)('0' + random.Next(10));
        }
        return string.Join(" ", Enumerable.Range(0, 5).Select(i => new string(accountNumber, i * 4, 4)));
    }

    private void Cancel()
    {
        var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
        window?.Close();
    }

    private void CloseWindow()
    {
        var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
        window?.Close();
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
