namespace WPF_Bank_A_MVVM_Library.Models
{
    public abstract class Account : ModelBase
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public Account(int accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        // Добавим здесь методы для работы со счетом
    }
}
