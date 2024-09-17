using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Visa.Json.Issuer.Core
{
    public interface IVisaJsonApiRequestorService
    {
        Task<HttpResponseMessage> TokenInquiryGetAsync(string tokenRequestorID, string tokenReferenceID, IDictionary<string, string> optionalQueryParams);
        Task<HttpResponseMessage> TokenInquiryByPanPostAsync(TokenInquiryByPanRequest request);
        Task<HttpResponseMessage> UpdateCardMetadataPostAsync(UpdateCardMetadataFromIssuerRequest request);
        Task<HttpResponseMessage> TokenLifecyclePostAsync(string tokenRequestorID, string tokenReferenceID, TokenLifecycleRequest request);
    }
}