using System;

public abstract class Account
{
    public int Id { get; }
    public string AccountNumber { get; }
    public string AccountType { get; }
    public decimal Balance { get; private set; }
    public DateTime CreatedDate { get; }

    protected Account(int id, string accountNumber, string accountType, decimal balance, DateTime createdDate)
    {
        Id = id;
        AccountNumber = accountNumber;
        AccountType = accountType;
        Balance = balance;
        CreatedDate = createdDate;
    }

    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        Balance -= amount;
    }
}
