using Newtonsoft.Json;

namespace Visa.Json.Issuer.Core.Models
{
    public class UpdateCardMetadataFromIssuerRequest
    {
        [JsonProperty("tokenRequestorID")]
        public string TokenRequestorId { get; set; }
        [JsonProperty("tokenReferenceID")]
        public string TokenReferenceId { get; set; }
        [JsonProperty("operationReason")]
        public string OperationReason { get; set; }
        [JsonProperty("cardMetadataInfo")]
        public CardMetadataInfo CardMetadataInfo { get; set; }
        [JsonProperty("encryptedData")]
        public string EncryptedData { get; set; }
    }
}