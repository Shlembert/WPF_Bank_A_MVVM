using System;

namespace BankA_MVVM_Library.Models
{
    public interface IAccountOperations<T> where T : Account
    {
        T CreateAccount(int id, int accountNumber, string accountType, decimal balance, DateTime createdDate);
    }
}
