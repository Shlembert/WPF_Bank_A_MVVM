using BankA_MVVM_Library.Models;
using BankA_MVVM_Library.Services;
using BankA_MVVM_UI.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BankA_MVVM_UI.ViewModels
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
                OpenClientDetailsWindow(); // Открываем окно с данными клиента при выборе клиента
            }
        }

        public ICommand NewClientCommand { get; }
        public ICommand OpenLogCommand { get; }

        public MainWindowViewModel(IClientDataHandler clientDataHandler)
        {
            _clientDataHandler = clientDataHandler;
            LoadClients();

            NewClientCommand = new RelayCommand(OpenNewClientWindow);
            OpenLogCommand = new RelayCommand(OpenLogWindow);
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
