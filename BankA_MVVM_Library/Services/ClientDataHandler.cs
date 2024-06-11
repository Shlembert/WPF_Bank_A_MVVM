using BankA_MVVM_Library.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using BankA_MVVM_Library.Models;
using System;

namespace BankA_MVVM_Library.Services
{
    public class ClientDataHandler : IClientDataHandler
    {
        private static string filePath = "clients.json";

        public void SaveClients(List<Client> clients)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var json = JsonConvert.SerializeObject(clients, Formatting.Indented, settings);
            File.WriteAllText(filePath, json);
        }

        public List<Client> LoadClients()
        {
            if (File.Exists(filePath))
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Client>>(json, settings);
            }
            return new List<Client>();
        }

        public static void SaveClients(object clients)
        {
            throw new NotImplementedException();
        }
    }
}
