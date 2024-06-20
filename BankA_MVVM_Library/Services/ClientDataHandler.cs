using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class ClientDataHandler : IClientDataHandler
{
    private const string FilePath = "clients.json";

    private JsonSerializerSettings GetJsonSerializerSettings()
    {
        return new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Converters = new List<JsonConverter> { new AccountConverter() }
        };
    }

    public List<Client> LoadClients()
    {
        if (!System.IO.File.Exists(FilePath))
        {
            return new List<Client>();
        }

        var json = System.IO.File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<Client>>(json, GetJsonSerializerSettings());
    }

    public void SaveClients(List<Client> clients)
    {
        var json = JsonConvert.SerializeObject(clients, Formatting.Indented, GetJsonSerializerSettings());
        System.IO.File.WriteAllText(FilePath, json);
    }
}
