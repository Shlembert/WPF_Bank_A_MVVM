using System.Collections.Generic;

namespace BankA_MVVM_Library.Models
{
    public class Client : ModelBase
    {
        public Client(string clientName)
        {
            ClientName = clientName;
        }

        public string Name { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
        public string ClientName { get; }
    }
}
