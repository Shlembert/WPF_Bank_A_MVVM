using BankA_MVVM_Library.Models;

namespace WPF_Bank_A_MVVM_Library.Services
{
    public interface ITransferOperations<in T> where T : Account
    {
        void Transfer(T fromAccount, T toAccount, decimal amount);
    }
}
