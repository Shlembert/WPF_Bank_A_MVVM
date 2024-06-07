namespace WPF_Bank_A_MVVM_Library.Models
{
    public class NonDepositAccount : Account
    {
        public NonDepositAccount(int accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance)
        {
        }

        // Добавим здесь специфические методы для недепозитного счета
    }
}
