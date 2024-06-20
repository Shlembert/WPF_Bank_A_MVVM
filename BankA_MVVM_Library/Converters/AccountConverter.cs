using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class AccountConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(Account).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        var accountType = (string)jsonObject["AccountType"];

        if (accountType == null)
        {
            throw new ArgumentNullException(nameof(accountType), "AccountType cannot be null.");
        }

        Account account = null;
        int id = jsonObject["Id"]?.ToObject<int>() ?? throw new ArgumentNullException("Id", "Id cannot be null.");
        string accountNumber = (string)jsonObject["AccountNumber"] ?? throw new ArgumentNullException("AccountNumber", "AccountNumber cannot be null.");
        decimal balance = jsonObject["Balance"]?.ToObject<decimal>() ?? throw new ArgumentNullException("Balance", "Balance cannot be null.");
        DateTime creationDate = jsonObject["CreationDate"]?.ToObject<DateTime>() ?? throw new ArgumentNullException("CreationDate", "CreationDate cannot be null.");

        switch (accountType)
        {
            case "Депозитный":
                account = new DepositAccount(id, accountNumber, accountType, balance, creationDate);
                break;

            case "Не депозитный":
                account = new NonDepositAccount(id, accountNumber, accountType, balance, creationDate);
                break;

            default:
                account = new BankAccount(id, accountNumber, accountType, balance, creationDate);
                break;
        }

        serializer.Populate(jsonObject.CreateReader(), account);
        return account;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var account = (Account)value;
        var jsonObject = JObject.FromObject(value);
        jsonObject.AddFirst(new JProperty("$type", value.GetType().AssemblyQualifiedName));
        jsonObject.WriteTo(writer);
    }
}
