using System;

public interface IAccountOperations<T> where T : Account
{
    T CreateAccount(int id, string accountNumber, string accountType, decimal balance, DateTime createdDate);
}
