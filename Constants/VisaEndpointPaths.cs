namespace Visa.Json.Issuer.Core
{
    /// <summary>
    /// Inbound API Specifications (To Visa)
    /// </summary>
    public static class VisaEndpointPaths
    {
        public static readonly string PAN_LIFECYCLE = "vtis/v1/pan/lifecycle";
        public static readonly string TOKEN_INQUIRY = "vtis/v1/tokenRequestors/{0}/tokens/{1}/details";
        public static readonly string TOKEN_INQUIRY_BY_PAN = "vtis/v1/pan/retrieveTokenInfo";
        public static readonly string TOKEN_LIFECYCLE = "vtis/v1/tokenRequestors/{0}/tokens/{1}/lifecycle";
        public static readonly string UPDATE_CARD_METADATA = "vtis/v1/updateCardMetadata";
        public static readonly string RETRIEVE_NHPP_PARTICIPANTS = "vtis/v1/retrieveNHPPParticipants";
    }
}