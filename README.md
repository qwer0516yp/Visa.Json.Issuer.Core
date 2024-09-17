# Visa.Json.Issuer.Core
This is a netstandard 2.0 Class Library, provide an abstraction and basic implementation of Visa API key - Shared Secret (x-pay-token) Issuer RESTful API implementation.

## Installation:
### NuGet
https://www.nuget.org/packages/Visa.Json.Issuer.Core

## Usage
Say you have a dotnet 8 web API that needs to talk to Visa Json From Issuer API.
In appsettings.json you have the following:
```
{
    ...
    "VisaJsonApi": {
        "BaseAddress": "https://cert.api.visa.com",
        "ApiKey": "yourTestApiKey",
        "ApiKeySharedSecret": "yourTestApiKeySharedSecret"
    }
    ...
}
```

In program.cs, you can DI services to your web application container:
```
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IVisaJsonRequestManager>(new VisaJsonRequestManager(builder.Configuration["VisaJsonApi:ApiKey"],
                                                                                  builder.Configuration["VisaJsonApi:ApiKeySharedSecret"]));
builder.Services.AddScoped<IVisaJsonApiRequestorService, VisaJsonApiRequestorService>();
builder.Services.AddHttpClient<IVisaJsonApiRequestorService, VisaJsonApiRequestorService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["VisaJsonApi:BaseAddress"]);
});
``` 

Then, at the place you need to send Visa GET/POST From Issuer request, call method from your VisaJsonApiRequestorService instance:
```
var visaResponse = await _visaJsonApiRequestorService.TokenInquiryGetAsync("tokenRequestorID", "tokenReferenceID");
var visaResponseBody = await visaResponse.Content.ReadAsStringAsync();
``` 

## Reference:
* https://developer.visa.com/pages/working-with-visa-apis/x-pay-token
