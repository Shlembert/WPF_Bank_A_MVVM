namespace BankA_MVVM_Library.Models
{
    public abstract class Account : ModelBase, IAccount
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        protected Account(int accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
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
