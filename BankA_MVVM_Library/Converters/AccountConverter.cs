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

        Account account = null;
        switch (accountType)
        {
            case "Депозитный":
                account = new DepositAccount(
                    (int)jsonObject["Id"],
                    (string)jsonObject["AccountNumber"],
                    (string)jsonObject["AccountType"],
                    (decimal)jsonObject["Balance"],
                    (DateTime)jsonObject["CreationDate"]
                );
                break;

            case "Не депозитный":
                account = new NonDepositAccount(
                    (int)jsonObject["Id"],
                    (string)jsonObject["AccountNumber"],
                    (string)jsonObject["AccountType"],
                    (decimal)jsonObject["Balance"],
                    (DateTime)jsonObject["CreationDate"]
                );
                break;

            default:
                account = new BankAccount(
                    (int)jsonObject["Id"],
                    (string)jsonObject["AccountNumber"],
                    (string)jsonObject["AccountType"],
                    (decimal)jsonObject["Balance"],
                    (DateTime)jsonObject["CreationDate"]
                );
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
