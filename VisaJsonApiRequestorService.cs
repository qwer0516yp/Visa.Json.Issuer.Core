using Visa.Json.Issuer.Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Visa.Json.Issuer.Core
{
    public class VisaJsonApiRequestorService : VisaJsonApiServiceBase, IVisaJsonApiRequestorService
    {
        public VisaJsonApiRequestorService(HttpClient httpClient, IVisaJsonRequestManager visaJsonRequestManager) : base(httpClient, visaJsonRequestManager)
        {
        }

        public async Task<HttpResponseMessage> TokenInquiryGetAsync(string tokenRequestorID, string tokenReferenceID, IDictionary<string, string> optionalQueryParams)
        {
            var queryStringBuilder = new StringBuilder($"apiKey={_visaJsonRequestManager.GetApiKey()}");
            if (optionalQueryParams != null)
            {
                foreach (var queryParam in optionalQueryParams)
                {
                    queryStringBuilder.Append($"&{queryParam.Key}={queryParam.Value}");
                }
            }

            return await GetAsync(string.Format(VisaEndpointPaths.TOKEN_INQUIRY, tokenRequestorID, tokenReferenceID),
                                  queryStringBuilder.ToString());
        }

        public async Task<HttpResponseMessage> TokenInquiryByPanPostAsync(TokenInquiryByPanRequest request)
        {
            var requestBody = SerializeJsonRequestBody(request);
            return await PostAsync(VisaEndpointPaths.TOKEN_INQUIRY_BY_PAN,
                                   $"apiKey={_visaJsonRequestManager.GetApiKey()}",
                                   requestBody);
        }

        public async Task<HttpResponseMessage> UpdateCardMetadataPostAsync(UpdateCardMetadataFromIssuerRequest request)
        {
            var requestBody = SerializeJsonRequestBody(request);
            return await PostAsync(VisaEndpointPaths.UPDATE_CARD_METADATA,
                                   $"apiKey={_visaJsonRequestManager.GetApiKey()}",
                                   requestBody);
        }

        public async Task<HttpResponseMessage> TokenLifecyclePostAsync(string tokenRequestorID, string tokenReferenceID, TokenLifecycleRequest request)
        {
            var requestBody = SerializeJsonRequestBody(request);
            return await PostAsync(string.Format(VisaEndpointPaths.TOKEN_LIFECYCLE, tokenRequestorID, tokenReferenceID),
                                   $"apiKey={_visaJsonRequestManager.GetApiKey()}",
                                   requestBody);
        }

        private static string SerializeJsonRequestBody(object request)
        {
            return JsonConvert.SerializeObject(request,
                            Formatting.None,
                            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}