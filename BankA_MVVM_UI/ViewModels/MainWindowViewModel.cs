using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BankA_MVVM_Library.Models;
using BankA_MVVM_Library.Services;
using BankA_MVVM_UI.Views;
using System.Diagnostics; // Добавь это для использования Debug.WriteLine

namespace BankA_MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IClientDataHandler _clientDataHandler;
        private Client _selectedClient;

        public ObservableCollection<Client> Clients { get; private set; }

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
                OpenClientDetailsWindow();
            }
        }

        public ICommand NewClientCommand { get; }
        public ICommand OpenLogCommand { get; }

        public MainWindowViewModel(IClientDataHandler clientDataHandler)
        {
            Debug.WriteLine("MainWindowViewModel constructor called");
            _clientDataHandler = clientDataHandler ?? throw new ArgumentNullException(nameof(clientDataHandler));
            LoadClients();

            NewClientCommand = new RelayCommand(param => OpenNewClientWindow());
            OpenLogCommand = new RelayCommand(param => OpenLogWindow());
        }

        // Пустой конструктор для XAML-дизайнера
        public MainWindowViewModel() : this(new ClientDataHandler()) { }

        private void LoadClients()
        {
            var clientsList = _clientDataHandler.LoadClients();
            Clients = new ObservableCollection<Client>(clientsList);
        }

        private void SaveClients()
        {
            _clientDataHandler.SaveClients(Clients.ToList());
        }

        private void OpenNewClientWindow()
        {
            var newClientWindow = new NewClientWindow();
            newClientWindow.ClientAdded += (sender, newClient) =>
            {
                Clients.Add(newClient);
                SaveClients();
            };
            newClientWindow.Show();
        }

        private void OpenLogWindow()
        {
            var logWindow = new OperationLogWindow();
            logWindow.Show();
        }

        private void OpenClientDetailsWindow()
        {
            if (SelectedClient != null)
            {
                var clientDetailsWindow = new ClientDetailsWindow(SelectedClient);
                clientDetailsWindow.Show();
            }
        }
    }
}