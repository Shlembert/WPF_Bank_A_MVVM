using Newtonsoft.Json;
using System.Collections.Generic;

namespace BankA_MVVM_Library.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Client
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public List<Account> Accounts { get; set; }

        [JsonConstructor]
        public Client(int id, string name, List<Account> accounts = null)
        {
            Id = id;
            Name = name;
            Accounts = accounts ?? new List<Account>();
        }
    }
}
