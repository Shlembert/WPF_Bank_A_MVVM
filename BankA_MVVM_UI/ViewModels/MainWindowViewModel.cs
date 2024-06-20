using BankA_MVVM_UI.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

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
                LoadClientDetails(); // Загрузить данные клиента перед открытием окна с деталями
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

        private void LoadClientDetails()
        {
            if (_selectedClient != null)
            {
                // Перезагружаем всех клиентов из JSON
                var clientsList = _clientDataHandler.LoadClients();
                var client = clientsList.FirstOrDefault(c => c.Id == _selectedClient.Id);
                if (client != null)
                {
                    _selectedClient.Accounts = client.Accounts;
                    OnPropertyChanged(nameof(SelectedClient));
                }
            }
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
                var clientDetailsWindow = new ClientDetailsWindow(SelectedClient, _clientDataHandler);
                clientDetailsWindow.Show();
            }
        }
    }
}
