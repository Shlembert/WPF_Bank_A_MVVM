namespace BankA_MVVM_Library.Models
{
    public class AccountOperations : IAccountOperations<BankAccount>
    {
        public BankAccount CreateAccount(int accountNumber,string accountType, decimal initialBalance)
        {
            return new BankAccount(accountNumber,accountType, initialBalance);
        }

        public BankAccount CreateAccount(int accountNumber, decimal initialBalance)
        {
            throw new System.NotImplementedException();
        }
    }
}
