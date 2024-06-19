using System;

public abstract class Account
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreationDate { get; set; }

    protected Account(int id, string accountNumber, string accountType, decimal balance, DateTime creationDate)
    {
        Id = id;
        AccountNumber = accountNumber;
        AccountType = accountType;
        Balance = balance;
        CreationDate = creationDate;
    }

    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}
