using BankA_MVVM_Library.Services;
using System;

namespace BankA_MVVM_Library.Models
{
    public class AccountOperations : IAccountOperations<BankAccount>
    {
        public BankAccount CreateAccount(int id, string accountNumber, string accountType, decimal balance, DateTime createdDate)
        {
            return new BankAccount(id, accountNumber, accountType, balance, createdDate);
        }

        public BankAccount CreateAccount(string accountNumber, string accountType, decimal balance, DateTime createdDate)
        {
            // Implement this method to create an account without using 'id'.
            throw new NotImplementedException();
        }
    }
}
