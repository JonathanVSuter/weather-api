using Polly;
using Polly.Retry;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WeatherAPI.Infra.Http.Extensions
{
    public static class ApiExtensions
    {
        public static HttpResponseMessage ExecuteWithToken(this RetryPolicy<HttpResponseMessage> retryPolicy, Token token, Func<Context, HttpResponseMessage> action)
        {
            return retryPolicy.Execute(action, new Dictionary<string, object> { { "AcessToken", token?.Value ?? string.Empty } });
        }
        public static HttpResponseMessage ExecuteWithToken(this PolicyWrap<HttpResponseMessage> wrap, Token token, Func<Context, HttpResponseMessage> action)
        {
            return wrap.Execute(action, new Dictionary<string, object> { { "AcessToken", token?.Value ?? string.Empty } });
        }

        public static HttpClient CreateHttpClientWithToken(string acessToken, string baseUrl)
        {
            if (string.IsNullOrEmpty(acessToken)) throw new InvalidOperationException(nameof(acessToken));

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + acessToken);

            return httpClient;
        }
        public static HttpClient CreateHttpClient(string baseUrl)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
    public class Token
    {
        public string Value { get; set; }
        public Token(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Token couldn't be null");
        }
    }
}
