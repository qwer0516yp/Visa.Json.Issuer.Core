using Newtonsoft.Json;

namespace Visa.Json.Issuer.Core.Models
{
    public class CardholderInfo
    {
        [JsonProperty("primaryAccountNumber")]
        public string PrimaryAccountNumber { get; set; }
    }
}