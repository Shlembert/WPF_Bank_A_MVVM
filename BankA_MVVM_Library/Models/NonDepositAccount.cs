namespace BankA_MVVM_Library.Models
{
    public class NonDepositAccount : Account
    {
        public NonDepositAccount(int accountNumber, decimal initialBalance)
            : base(accountNumber, "Non-Deposit", initialBalance) // Указываем тип счета для недепозитного счета
        {
        }

        public NonDepositAccount(int accountNumber, string accountType, decimal initialBalance) : base(accountNumber, accountType, initialBalance)
        {
        }

        public override void Deposit(decimal amount)
        {
            // Для недепозитного счета может быть другая логика для внесения средств
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
