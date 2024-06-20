using BankA_MVVM_UI.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BankA_MVVM.ViewModels
{
    public class ClientDetailsViewModel : ViewModelBase
    {
        public Client Client { get; private set; }
        public ObservableCollection<Account> Accounts { get; private set; }
        private readonly IClientDataHandler _clientDataHandler;
        private Account _selectedAccount;
        private string _selectedAccountDetails;

        public Account SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                OnPropertyChanged();
                UpdateSelectedAccountDetails();
            }
        }

        public string SelectedAccountDetails
        {
            get => _selectedAccountDetails;
            set
            {
                _selectedAccountDetails = value;
                OnPropertyChanged();
            }
        }

        public ClientDetailsViewModel(Client client, IClientDataHandler clientDataHandler)
        {
            Client = client;
            _clientDataHandler = clientDataHandler;
            Accounts = new ObservableCollection<Account>(client.Accounts);
            UpdateSelectedAccountDetails(); // Обновляем детали выбранного счета при инициализации
        }

        public ICommand NewAccountCommand => new RelayCommand(AddNewAccount);
        public ICommand DeleteAccountCommand => new RelayCommand(DeleteSelectedAccount);

        public void AddNewAccount()
        {
            var newAccountWindow = new NewAccountWindow(Client);
            newAccountWindow.AccountAdded += (s, e) =>
            {
                Accounts.Add(e);
                SaveClientsToJson(); // Сохраняем клиентов после добавления нового счета

                // Обновляем выбранный счет и его детали
                SelectedAccount = e;
                UpdateSelectedAccountDetails();
            };
            newAccountWindow.ShowDialog();
        }

        public void DeleteSelectedAccount()
        {
            if (SelectedAccount != null)
            {
                if (SelectedAccount.Balance > 0)
                {
                    MessageBox.Show("Невозможно удалить счет с ненулевым балансом.", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этот счет?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Accounts.Remove(SelectedAccount);
                    Client.Accounts.Remove(SelectedAccount);
                    SaveClientsToJson();
                    OnPropertyChanged(nameof(Accounts));
                    MessageBox.Show("Счет успешно удален.", "Удаление завершено", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите счет для удаления.", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void TransferBetweenAccounts()
        {
            // Логика для перевода между счетами
        }

        public void DepositToSelectedAccount()
        {
            // Логика для пополнения счета
        }

        public void WithdrawFromSelectedAccount()
        {
            // Логика для списания средств со счета
        }

        public void RefreshAccounts()
        {
            Accounts.Clear();
            foreach (var account in Client.Accounts)
            {
                Accounts.Add(account);
            }
            OnPropertyChanged(nameof(Accounts));
        }

        private void UpdateSelectedAccountDetails()
        {
            if (SelectedAccount != null)
            {
                SelectedAccountDetails = $"Номер счета: {SelectedAccount.AccountNumber}\n" +
                                         $"Баланс: {SelectedAccount.Balance}\n" +
                                         $"Тип счета: {SelectedAccount.AccountType}\n" +
                                         $"Дата создания: {SelectedAccount.CreationDate}";
            }
            else
            {
                SelectedAccountDetails = string.Empty;
            }
        }

        private void SaveClientsToJson()
        {
            var clients = _clientDataHandler.LoadClients();
            var existingClient = clients.Find(c => c.Id == Client.Id);
            if (existingClient != null)
            {
                clients.Remove(existingClient);
            }

            // Добавляем текущего клиента с обновленными данными
            clients.Add(Client);
            _clientDataHandler.SaveClients(clients);
        }
    }
}
