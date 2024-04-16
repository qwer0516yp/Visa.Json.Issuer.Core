namespace Visa.Json.Issuer.Core
{
    public interface IVisaJsonRequestManager
    {
        string GetXPayToken(string resourcePath, string queryString, string requestBody);
        string GetApiKey();
    }
}
