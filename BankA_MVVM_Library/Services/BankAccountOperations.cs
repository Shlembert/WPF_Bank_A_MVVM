using BankA_MVVM_Library.Models;
using System;

namespace BankA_MVVM_Library.Services
{
    public class BankAccountOperations : IAccountOperations<BankAccount>
    {
        public BankAccount CreateAccount(int id, string accountNumber, string accountType, decimal balance, DateTime createdDate)
        {
            return new BankAccount(id, accountNumber, accountType, balance, createdDate);
        }
    }
}
