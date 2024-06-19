using BankA_MVVM_Library.Models;
using Newtonsoft.Json;
using System;

[JsonObject(MemberSerialization.OptIn)]
public class BankAccount : Account
{
    [JsonConstructor]
    public BankAccount(int id, string accountNumber, string accountType, decimal balance, DateTime createdDate)
        : base(id, accountNumber, accountType, balance, createdDate)
    {
    }

    public override void Deposit(decimal amount)
    {
        base.Deposit(amount);
        // Дополнительная логика для банковского счета, если необходимо
    }

    public override void Withdraw(decimal amount)
    {
        base.Withdraw(amount);
        // Дополнительная логика для банковского счета, если необходимо
    }
}
