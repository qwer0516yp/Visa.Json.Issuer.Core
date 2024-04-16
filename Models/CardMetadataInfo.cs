using Newtonsoft.Json;

namespace Visa.Json.Issuer.Core.Models
{
    public class CardMetadataInfo
    {
        [JsonProperty("profileID")]
        public string ProfileId { get; set; }
    }
}