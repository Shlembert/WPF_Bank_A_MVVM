using BankA_MVVM_Library.Models;
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
            // Логика для добавления нового счета
            // Например, открытие окна для ввода данных нового счета
        }

        public void DeleteSelectedAccount()
        {
            if (SelectedAccount != null)
            {
                Accounts.Remove(SelectedAccount);
                // Также нужно удалить счет из клиента
                Client.Accounts.Remove(SelectedAccount);
                OnPropertyChanged(nameof(Accounts));
            }
        }

        public void TransferBetweenAccounts()
        {
            // Логика для перевода между счетами
            // Например, открытие окна для выбора счетов и суммы перевода
        }

        public void DepositToSelectedAccount()
        {
            if (SelectedAccount != null)
            {
                // Логика для пополнения выбранного счета
                // Например, открытие окна для ввода суммы пополнения
            }
        }

        public void WithdrawFromSelectedAccount()
        {
            if (SelectedAccount != null)
            {
                // Логика для списания средств с выбранного счета
                // Например, открытие окна для ввода суммы списания
            }
        }
    }
}
