using System;

namespace WPF_Bank_A_MVVM_Library.Models
{
    internal class DepositAccount : BankAccount
    {
        public DepositAccount(int accountNumber, decimal initialBalance) : base(accountNumber, initialBalance)
        {
        }

        // Метод для зачисления средств на счет
        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма для зачисления должна быть положительной.", nameof(amount));
            }

            Balance += amount;
        }

        // Метод для списания средств со счета
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма для списания должна быть положительной.", nameof(amount));
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Недостаточно средств на счете.");
            }

            Balance -= amount;
        }
    }
}
