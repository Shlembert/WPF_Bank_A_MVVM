﻿using WPF_Bank_A_MVVM_Library.Models;

namespace WPF_Bank_A_MVVM_Library.Services
{
    public interface IAccountOperations<out T> where T : BankAccount
    {
        T CreateAccount(int accountNumber, decimal initialBalance);
    }
}
