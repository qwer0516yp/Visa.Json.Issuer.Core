using System;
using System.Security.Cryptography;
using System.Text;

namespace Visa.Json.Issuer.Core
{
    public class VisaJsonRequestManager : IVisaJsonRequestManager
    {
        private string _apiKey { get; set; }
        private string _apiKeySharedSecret { get; set; }

        public VisaJsonRequestManager(string apiKey, string apiKeySharedSecret)
        {
            _apiKey = apiKey;
            _apiKeySharedSecret = apiKeySharedSecret;
        }

        public string GetApiKey()
        {
            return _apiKey;
        }

        /// <summary>
        /// GetXPayToken and related C# code snippets are taken from Visa developer portal
        /// https://developer.visa.com/pages/working-with-visa-apis/x-pay-token
        /// </summary>
        /// <param name="resourcePath"></param>
        /// <param name="queryString"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public string GetXPayToken(string resourcePath, string queryString, string requestBody)
        {
            string timestamp = GetTimestamp();
            string sourceString = timestamp + resourcePath + queryString + requestBody;
            string hash = GetHash(sourceString);
            string token = "xv2:" + timestamp + ":" + hash;
            return token;
        }

        private string GetTimestamp()
        {
            long timeStamp = ((long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds) / 1000;
            return timeStamp.ToString();
        }

        private string GetHash(string data)
        {
            var hashString = new HMACSHA256(Encoding.ASCII.GetBytes(_apiKeySharedSecret));
            var hashbytes = hashString.ComputeHash(Encoding.ASCII.GetBytes(data));
            string digest = String.Empty;

            foreach (byte b in hashbytes)
            {
                digest += b.ToString("x2");
            }

            return digest;
        }
    }
}