using System;

namespace WPF_Bank_A_MVVM_Library.Models
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(int accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                // Недостаточно средств на счету
                return false;
            }

            Balance -= amount;
            return true;
        }
    }
}
