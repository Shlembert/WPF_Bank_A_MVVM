using System.Collections.Generic;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Account> Accounts { get; set; }

    public Client(int id, string name)
    {
        Id = id;
        Name = name;
        Accounts = new List<Account>();
    }
}
