using WPF_Bank_A_MVVM_Library.Models;
using WPF_Bank_A_MVVM_Library.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WPF_Bank_A_MVVM.ViewModels
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

        private void OpenNewClientWindow()
        {
            // Логика для открытия окна нового клиента
        }

        private void OpenLogWindow()
        {
            // Логика для открытия окна логов
        }
    }
}
