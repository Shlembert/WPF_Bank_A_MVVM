using System;

namespace BankA_MVVM_Library.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; } // Дата создания счета

        public Account(int id, int accountNumber, string accountType, decimal balance, DateTime createdDate)
        {
            Id = id;
            AccountNumber = accountNumber;
            AccountType = accountType;
            Balance = balance;
            CreatedDate = createdDate;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }
}
