using Newtonsoft.Json;

namespace MilitaryConsoleApp
{
    public class BillingEntries
    {
        [JsonProperty("billingEntries")]
        public BillingEntryDto[] Items { get; set; }
    }
    public class BillingEntryDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("occurredAt")]
        public DateTime OccurredAt { get; set; }

        [JsonProperty("type")]
        public BillingType Type { get; set; }

        [JsonProperty("offer")]
        public Offer Offer { get; set; }

        [JsonProperty("value")]
        public Value Value { get; set; }

        [JsonProperty("tax")]
        public Tax Tax { get; set; }

        [JsonProperty("balance")]
        public Balance Balance { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }
    }

    public class BillingType
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Offer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Value
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class Tax
    {
        [JsonProperty("percentage")]
        public string Percentage { get; set; }

        [JsonProperty("annotation")]
        public string Annotation { get; set; }
    }

    public class Balance
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class Order
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
