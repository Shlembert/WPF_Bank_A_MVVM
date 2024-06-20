using System;

namespace BankA_MVVM_Library.Services
{
    public interface IAccountOperations<T> where T : Account
    {
        T CreateAccount(string accountNumber, string accountType, decimal balance, DateTime createdDate);
    }
}
