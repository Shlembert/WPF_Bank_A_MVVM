using BankA_MVVM_Library.Models;
using System;

namespace BankA_MVVM_Library.Services
{
    public class BankAccountOperations : IAccountOperations<BankAccount>
    {
        private int _nextId = 1; // Пример логики для генерации уникального ID

        public BankAccount CreateAccount(string accountNumber, string accountType, decimal balance, DateTime createdDate)
        {
            var newAccount = new BankAccount(_nextId++, accountNumber, accountType, balance, createdDate);
            return newAccount;
        }
    }
}
