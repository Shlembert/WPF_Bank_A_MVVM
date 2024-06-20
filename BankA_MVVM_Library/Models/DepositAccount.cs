using System;

public class DepositAccount : Account
{
    public DepositAccount(int id, string accountNumber, string accountType, decimal balance, DateTime creationDate)
       : base(id, accountNumber, accountType, balance, creationDate)
    {
    }

    public override void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public override void Withdraw(decimal amount)
    {
        Balance -= amount;
    }
}
