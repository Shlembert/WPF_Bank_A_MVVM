using BankA_MVVM_Library.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BankA_MVVM_UI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public static List<Client> Clients { get; internal set; }

        private void ClientsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Заглушка для обработчика события изменения выбора в списке клиентов
        }

        private void NewClient_Click(object sender, RoutedEventArgs e)
        {
            // Заглушка для обработчика события клика на кнопке "Новый клиент"
        }

        private void OpenLogWindow_Click(object sender, RoutedEventArgs e)
        {
            // Заглушка для обработчика события клика на кнопке "Лог операций"
        }
    }
}
