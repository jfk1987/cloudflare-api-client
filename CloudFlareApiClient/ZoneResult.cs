using System;
using System.Text.Json.Serialization;

namespace CloudFlareApiClient
{
    public class ZoneResult : Result
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("development_mode")]
        public long DevelopmentMode { get; set; }

        [JsonPropertyName("original_name_servers")]
        public string[] OriginalNameServers { get; set; }

        [JsonPropertyName("original_registrar")]
        public string OriginalRegistrar { get; set; }

        [JsonPropertyName("original_dnshost")]
        public string OriginalDnshost { get; set; }

        [JsonPropertyName("created_on")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonPropertyName("modified_on")]
        public DateTimeOffset ModifiedOn { get; set; }

        [JsonPropertyName("activated_on")]
        public DateTimeOffset ActivatedOn { get; set; }

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }

        [JsonPropertyName("account")]
        public Account Account { get; set; }

        [JsonPropertyName("permissions")]
        public string[] Permissions { get; set; }

        [JsonPropertyName("plan")]
        public Plan Plan { get; set; }

        [JsonPropertyName("plan_pending")]
        public Plan PlanPending { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("paused")]
        public bool Paused { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name_servers")]
        public string[] NameServers { get; set; }
    }

    public partial class Account
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public partial class Owner
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public partial class Plan
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public long Price { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("frequency")]
        public string Frequency { get; set; }

        [JsonPropertyName("legacy_id")]
        public string LegacyId { get; set; }

        [JsonPropertyName("is_subscribed")]
        public bool IsSubscribed { get; set; }

        [JsonPropertyName("can_subscribe")]
        public bool CanSubscribe { get; set; }
    }
}
