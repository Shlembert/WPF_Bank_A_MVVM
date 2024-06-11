using System;

namespace BankA_MVVM_Library.Models
{
    public class DepositAccount : BankAccount
    {
        public DepositAccount(int accountNumber, decimal balance) : base(accountNumber, balance)
        {
        }

        public DateTime CreationDate { get; set; }

        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть больше нуля.", nameof(amount));

            base.Deposit(amount);
        }

        public override bool Withdraw(decimal amount)
        {
            throw new InvalidOperationException("Снятие средств недоступно для депозитного счета.");
        }
    }
}
