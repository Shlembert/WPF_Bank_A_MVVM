using BankA_MVVM_Library.Models;
using BankA_MVVM_UI.Views;
using System.Collections.ObjectModel;

namespace BankA_MVVM.ViewModels
{
    public class ClientDetailsViewModel : ViewModelBase
    {
        public Client Client { get; private set; }
        public ObservableCollection<Account> Accounts { get; private set; }
        private Account _selectedAccount;

        public Account SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                OnPropertyChanged();
            }
        }

        public ClientDetailsViewModel(Client client)
        {
            Client = client;
            Accounts = new ObservableCollection<Account>(client.Accounts);
        }

        public void AddNewAccount()
        {
            NewAccountWindow newAccountWindow = new NewAccountWindow(Client);
            newAccountWindow.ShowDialog(); // Используем ShowDialog для модального окна
        }

        public void DeleteSelectedAccount()
        {
            if (SelectedAccount != null)
            {
                Accounts.Remove(SelectedAccount);
                Client.Accounts.Remove(SelectedAccount);
                OnPropertyChanged(nameof(Accounts));
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
    }
}
