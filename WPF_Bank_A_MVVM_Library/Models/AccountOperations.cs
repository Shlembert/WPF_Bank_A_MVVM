using WPF_Bank_A_MVVM_Library.Services;

namespace WPF_Bank_A_MVVM_Library.Models
{
    public class AccountOperations : IAccountOperations<BankAccount>
    {
        public BankAccount CreateAccount(int accountNumber, decimal initialBalance)
        {
            return new BankAccount(accountNumber, initialBalance);
        }
    }
}
