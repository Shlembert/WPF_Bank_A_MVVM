namespace BankA_MVVM_Library.Models
{
    public class BankAccount : Account
    {
        public BankAccount(int accountNumber, string accountType, decimal initialBalance)
            : base(accountNumber, accountType, initialBalance)
        {
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                return false; // Недостаточно средств
            }
            Balance -= amount;
            return true;
        }
    }
}
