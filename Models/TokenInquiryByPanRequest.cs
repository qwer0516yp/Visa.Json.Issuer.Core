using Newtonsoft.Json;

namespace Visa.Json.Issuer.Core
{
    public class TokenInquiryByPanRequest
    {
        [JsonProperty("panReferenceID")]
        public string PanReferenceID { get; set; }
        [JsonProperty("encryptedData")]
        public string EncryptedData { get; set; }
    }
}