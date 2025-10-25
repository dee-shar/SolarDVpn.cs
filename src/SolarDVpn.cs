using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SolarDVpnApi
{
    public class SolarDVpn
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://api.dvpn.solar/api";
        public SolarDVpn()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("okhttp/4.7.2");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<string> GetDeviceToken()
        {
            var jsonContent = JsonContent.Create(new {platform = "ANDROID"});
            var response = await httpClient.PostAsync($"{apiUrl}/device", jsonContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetCurrentIp()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/vpn/ip");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCountries()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/vpn/countries");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
