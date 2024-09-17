using Newtonsoft.Json;

namespace Visa.Json.Issuer.Core
{
    public class CardMetadataInfo
    {
        [JsonProperty("profileID")]
        public string ProfileId { get; set; }
    }
}