using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class IMDBApi : BaseHttpHelper
    {
        string Url = "/en/API/SeasonEpisodes/{0}/tt1196946/1";
        string apiKey = "k_1uvuee84";
        public IMDBApi(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<Response> GetData()
        {
            HttpRequestMessage GetRequest()
            {
                var request = new HttpRequestMessage(HttpMethod.Get, string.Format(Url, apiKey));

                //request.Headers.Add("Accept", "application/json, text/plain, */*");
                return request;
            }

            return await GetContent(GetRequest);
        }
    }
}
