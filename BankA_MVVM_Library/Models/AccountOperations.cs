using System;

namespace BankA_MVVM_Library.Models
{
    public class AccountOperations : IAccountOperations<BankAccount>
    {
        public BankAccount CreateAccount(int id, int accountNumber, string accountType, decimal balance, DateTime createdDate)
        {
            return new BankAccount(id, accountNumber, accountType, balance, createdDate);
        }
    }
}
