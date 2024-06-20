using System;
using System.Collections.Generic;

public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Account> Accounts { get; set; }

    public Client(Guid id, string name)
    {
        Id = id;
        Name = name;
        Accounts = new List<Account>();
    }
}
