namespace BankA_MVVM_Library.Models
{
    public class AccountOperations : IAccountOperations<BankAccount>
    {
        public BankAccount CreateAccount(int accountNumber, decimal initialBalance)
        {
            return new BankAccount(accountNumber, initialBalance);
        }
    }
}
