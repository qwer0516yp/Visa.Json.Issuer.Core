using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Visa.Json.Issuer.Core
{
    public class VisaJsonApiServiceBase
    {
        protected readonly HttpClient _httpClient;
        protected readonly IVisaJsonRequestManager _visaJsonRequestManager;

        public VisaJsonApiServiceBase(HttpClient httpClient, IVisaJsonRequestManager visaJsonRequestManager)
        {
            _httpClient = httpClient;
            _visaJsonRequestManager = visaJsonRequestManager;
        }

        public async Task<HttpResponseMessage> GetAsync(string resourcePath, string queryString)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_httpClient.BaseAddress, $"{resourcePath}?{queryString}")
            };
            request.Headers.Add(RequestHeaders.X_PAY_TOKEN,
                                _visaJsonRequestManager.GetXPayToken(resourcePath, queryString, null));
            request.Headers.Add(RequestHeaders.X_REQUEST_ID,
                                Guid.NewGuid().ToString());
            request.Headers.Add(RequestHeaders.ACCEPT, RequestHeaders.ACCEPT_VALUE);

            return await _httpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> PostAsync(string resourcePath, string queryString, string requestBody)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_httpClient.BaseAddress, $"{resourcePath}?{queryString}"),
                Content = new StringContent(requestBody, Encoding.UTF8, RequestHeaders.CONTENT_APPLICATION_JSON)
            };
            request.Headers.Add(RequestHeaders.X_PAY_TOKEN,
                                _visaJsonRequestManager.GetXPayToken(resourcePath, queryString, requestBody));
            request.Headers.Add(RequestHeaders.X_REQUEST_ID,
                                Guid.NewGuid().ToString());

            return await _httpClient.SendAsync(request);
        }
    }
}