using BankA_MVVM_Library.Exceptions;

namespace BankA_MVVM_Library.Models
{
    public abstract class Account
    {
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }

        protected Account(int accountNumber, string accountType, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            Balance = initialBalance;
        }

        public abstract void Deposit(decimal amount);

        public virtual bool Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientFundsException("Недостаточно средств на счете для выполнения операции.");
            }
            Balance -= amount;
            return true;
        }
    }
}
