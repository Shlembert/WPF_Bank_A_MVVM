using BankA_MVVM_Library.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BankA_MVVM_Library.Converters
{
    public class AccountTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DepositAccount)
                return "Депозитный";
            else if (value is NonDepositAccount)
                return "Недепозитный";
            else
                return "Неизвестный тип";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
