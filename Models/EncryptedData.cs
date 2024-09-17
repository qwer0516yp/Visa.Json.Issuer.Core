using Newtonsoft.Json;

namespace Visa.Json.Issuer.Core
{
    public class EncryptedData
    {
        [JsonProperty("cardholderInfo")]
        public CardholderInfo CardholderInfo { get; set; }
    }
}