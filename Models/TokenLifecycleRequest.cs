using Newtonsoft.Json;

namespace Visa.Json.Issuer.Core.Models
{
    public class TokenLifecycleRequest
    {
        [JsonProperty("operatorID")]
        public string OperatorID { get; set; }
        [JsonRequired]
        [JsonProperty("operationType")]
        public string OperationType { get; set; }
        [JsonRequired]
        [JsonProperty("operationReason")]
        public string OperationReason { get; set; }
        [JsonProperty("activationCode")]
        public string ActivationCode { get; set; }
    }
}