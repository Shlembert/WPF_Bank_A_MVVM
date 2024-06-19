using System.Collections.Generic;

public interface IClientDataHandler
{
    List<Client> LoadClients();
    void SaveClients(List<Client> clients);
}
