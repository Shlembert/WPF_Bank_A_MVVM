using System;
using System.Windows.Input;

namespace BankA_MVVM.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
