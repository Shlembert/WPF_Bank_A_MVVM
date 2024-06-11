using BankA_MVVM_Library.Models;
using System.Collections.Generic;

namespace BankA_MVVM_Library.Services
{
    public interface IClientDataHandler
    {
        void SaveClients(List<Client> clients);
        List<Client> LoadClients();
    }
}
