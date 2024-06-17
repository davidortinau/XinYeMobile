
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XinYeMobile.Messages;

namespace XinYeMobile.Service
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        private string? jwt = null;
        IHttpsClientHandlerService _httpsClientHandlerService;
        public RestService(IHttpsClientHandlerService service)
        {
#if DEBUG
            _httpsClientHandlerService = service;
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                //_client = new HttpClient(handler);
                _client = new HttpClient();
            else
                _client = new HttpClient();
#else
            _client = new HttpClient();
#endif
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        }


        //public string? Jwt { get => jwt; set {
        //        jwt = value;
        //        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",value);
        //    } }

        public async Task<HttpResponseMessage> DeleteAsync(string route)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl + route, string.Empty));
            HttpResponseMessage response = await _client.DeleteAsync(uri);
            return response;

        }

        public async Task<HttpResponseMessage> GetAsync(string route)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl + route, string.Empty));
            return await _client.GetAsync(uri);
        }

        public async Task<HttpResponseMessage> PatchAsync(string route, string jsonString)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl + route, string.Empty));
            StringContent httpcontent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync(uri, httpcontent);
            return response;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string route, T obj)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl + route, string.Empty));
            string json = JsonSerializer.Serialize<T>(obj, _serializerOptions);
            StringContent httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(uri, httpcontent);
            return response;
        }
        public async Task<HttpResponseMessage> PostAsync(string route, string content)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl + route, string.Empty));
            StringContent httpcontent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(uri, httpcontent);
            return response;
        }
        public async Task<HttpResponseMessage> PutAsync<T>(string route, T obj)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl + route, string.Empty));
            string json = JsonSerializer.Serialize<T>(obj, _serializerOptions);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(uri, httpContent);
            return response;
        }
        public async Task<HttpResponseMessage> PutAsync(string route, string jsonString)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl + route, string.Empty));
            StringContent httpcontent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(uri, httpcontent);
            return response;
        }
    }
}
