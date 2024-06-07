namespace WPF_Bank_A_MVVM_Library.Models
{
    internal interface IAccount
    {
        int AccountNumber { get; }
        decimal Balance { get; }

        void Deposit(decimal amount);
        bool Withdraw(decimal amount);
    }
}
