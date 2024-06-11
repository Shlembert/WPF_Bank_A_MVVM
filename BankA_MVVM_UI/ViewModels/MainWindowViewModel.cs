using BankA_MVVM_Library.Models;
using BankA_MVVM_Library.Services;
using BankA_MVVM_UI.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BankA_MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IClientDataHandler _clientDataHandler;

        public ObservableCollection<Client> Clients { get; }

        public ICommand NewClientCommand { get; }
        public ICommand OpenLogCommand { get; }

        public MainWindowViewModel(IClientDataHandler clientDataHandler)
        {
            _clientDataHandler = clientDataHandler;
            Clients = new ObservableCollection<Client>(_clientDataHandler.LoadClients());

            NewClientCommand = new RelayCommand(OpenNewClientWindow);
            OpenLogCommand = new RelayCommand(OpenLogWindow);
        }

        // Пустой конструктор для XAML-дизайнера
        public MainWindowViewModel() : this(new ClientDataHandler()) { }

        private void OpenNewClientWindow()
        {
            var newClientWindow = new NewClientWindow();
            newClientWindow.ClientAdded += (sender, newClient) =>
            {
                Clients.Add(newClient);
                _clientDataHandler.SaveClients(Clients.ToList());
            };
            newClientWindow.Show();
        }

        private void OpenLogWindow()
        {
            var logWindow = new OperationLogWindow();
            logWindow.Show();
        }
    }
}
