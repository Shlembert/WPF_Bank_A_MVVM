using BankA_MVVM_Library.Models;
using BankA_MVVM_Library.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class ClientDataHandler : IClientDataHandler
{
    private const string FilePath = "clients.json";

    public List<Client> LoadClients()
    {
        if (!File.Exists(FilePath))
        {
            return new List<Client>();
        }

        var json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<Client>>(json);
    }

    public void SaveClients(List<Client> clients)
    {
        var json = JsonConvert.SerializeObject(clients, Formatting.Indented);
        File.WriteAllText(FilePath, json);
    }
}
