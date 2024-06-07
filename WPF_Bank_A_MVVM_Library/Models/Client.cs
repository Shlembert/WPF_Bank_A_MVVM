using System.Collections.Generic;
using System.Security.Principal;

namespace WPF_Bank_A_MVVM_Library.Models
{
    public class Client : ModelBase
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
