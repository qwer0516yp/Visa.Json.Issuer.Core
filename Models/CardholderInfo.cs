using Newtonsoft.Json;

namespace Visa.Json.Issuer.Core
{
    public class CardholderInfo
    {
        [JsonProperty("primaryAccountNumber")]
        public string PrimaryAccountNumber { get; set; }
    }
}