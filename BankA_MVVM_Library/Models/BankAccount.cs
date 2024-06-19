using Newtonsoft.Json;
using System;

[JsonObject(MemberSerialization.OptIn)]
public class BankAccount : Account
{
    public BankAccount(int id, string accountNumber, string accountType, decimal balance, DateTime creationDate)
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
