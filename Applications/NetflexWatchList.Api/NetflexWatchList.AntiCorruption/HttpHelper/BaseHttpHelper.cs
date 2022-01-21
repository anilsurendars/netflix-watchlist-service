namespace NetflexWatchList.AntiCorruption.HttpHelper
{
    using NetflexWatchList.Shared;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// The BaseHttpHelper.
    /// </summary>
    public class BaseHttpHelper
    {
        /// <summary>
        /// The client factory.
        /// </summary>
        protected readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHttpHelper"/> class.
        /// </summary>
        /// <param name="clientFactory">The client factory.</param>
        public BaseHttpHelper(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The responseDto.</returns>
        protected async Task<ResponseDto> GetContent(Func<HttpRequestMessage> request)
        {
            try
            {
                var client = _clientFactory.CreateClient(AppConstants.IMDbApi);

                var response = await GetResponse(client, request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return new ResponseDto() { Data = content, IsSuccess = true, StatusCode = (int)response.StatusCode };
                }
                else
                {
                    return new ResponseDto() { 
                        IsSuccess = false, 
                        StatusCode = (int)response.StatusCode, 
                        ErrorMessage = $"Error loading data: Status: {response.StatusCode}.",
                        ResponsePhrase = response.ReasonPhrase
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto() { IsSuccess = false, ErrorMessage = ex.Message };
            }
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="requestMessage">The request message.</param>
        /// <returns>The httpResponseMessage.</returns>
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
