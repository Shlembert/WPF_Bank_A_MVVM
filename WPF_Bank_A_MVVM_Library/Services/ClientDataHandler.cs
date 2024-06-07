using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WPF_Bank_A_MVVM_Library.Models;

namespace WPF_Bank_A_MVVM_Library.Services
{
    public static class ClientDataHandler
    {
        private static string filePath = "clients.json";

        public static void SaveClients(List<Client> clients)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var json = JsonConvert.SerializeObject(clients, Formatting.Indented, settings);
            File.WriteAllText(filePath, json);
        }

        public static List<Client> LoadClients()
        {
            if (File.Exists(filePath))
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Client>>(json, settings);
            }
            return new List<Client>();
        }
    }
}
