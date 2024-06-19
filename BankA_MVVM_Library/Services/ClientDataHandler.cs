using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

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
        if (!File.Exists(FilePath))
        {
            return new List<Client>();
        }

        var json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<Client>>(json, GetJsonSerializerSettings());
    }

    public void SaveClients(List<Client> clients)
    {
        var json = JsonConvert.SerializeObject(clients, Formatting.Indented, GetJsonSerializerSettings());
        File.WriteAllText(FilePath, json);
    }
}
