using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BaseHttpHelper
    {
        private readonly IHttpClientFactory _clientFactory;
        public BaseHttpHelper(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        protected async Task<Response> GetContent(Func<HttpRequestMessage> request)
        {
            try
            {
                var client = _clientFactory.CreateClient("IMDBApi");

                var response = await GetResponse(client, request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return new Response() { Data = content, IsSuccess = true, StatusCode = (int)response.StatusCode };
                }
                else
                {
                    return new Response() { IsSuccess = false, StatusCode = (int)response.StatusCode, ErrorMessage = $"Error loading data: Status: {response.StatusCode}." };
                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccess = false, ErrorMessage = ex.Message };
            }
        }

        private async Task<HttpResponseMessage> GetResponse(HttpClient httpClient, Func<HttpRequestMessage> requestMessage)
        {
            try
            {
                var response = await httpClient.SendAsync(requestMessage());

                return response;
            }
            catch
            {
                await Task.Delay(1000);

                return await httpClient.SendAsync(requestMessage());
            }
        }
    }
}
