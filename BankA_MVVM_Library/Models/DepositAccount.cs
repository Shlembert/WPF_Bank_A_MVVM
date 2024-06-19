﻿using BankA_MVVM_Library.Models;
using Newtonsoft.Json;
using System;

[JsonObject(MemberSerialization.OptIn)]
public class DepositAccount : Account
{
    private string accountType1;

    [JsonConstructor]
    public DepositAccount(int id, string accountNumber, string accountType,
        decimal balance, DateTime createdDate)
        : base(id, accountNumber, accountType, balance, createdDate)
    {
    }

    public DepositAccount(int id, string accountNumber, string accountType,
        decimal balance, string accountType1, DateTime createdDate) 
        : this(id, accountNumber, accountType, balance, createdDate)
    {
        this.accountType1 = accountType1;
    }

    public override void Deposit(decimal amount)
    {
        base.Deposit(amount);
        // Дополнительная логика для депозитного счета
    }

    public override void Withdraw(decimal amount)
    {
        base.Withdraw(amount);
        // Дополнительная логика для депозитного счета
    }
}
