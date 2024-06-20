using BankA_MVVM_Library.Exceptions;
using System;
using System.Windows;
using System.Windows.Input;

namespace BankA_MVVM.ViewModels
{
    public class NewClientWindowViewModel : ViewModelBase
    {
        private string _clientName;
        public string ClientName
        {
            get => _clientName;
            set
            {
                _clientName = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddClientCommand { get; }

        public event EventHandler<Client> ClientAdded;

        public NewClientWindowViewModel()
        {
            AddClientCommand = new RelayCommand(AddClient);
        }

        private void AddClient(object parameter)
        {
            if (string.IsNullOrWhiteSpace(ClientName))
            {
                MessageBox.Show("Введите имя клиента.");
                return;
            }

            try
            {
                Client newClient = new Client(Guid.NewGuid(), ClientName); // Генерация нового Guid
                ClientAdded?.Invoke(this, newClient);
            }
            catch (EmptyNameException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
