namespace PicPay
{
    public class PicPayClient : IPicPayClient
    {
        private readonly string _token;
        private readonly BaseUrl _baseUrl;
        private readonly IRestClient _restClient;

        public PicPayClient(BaseUrl baseUrl, string token, IRestClient? restClient = null)
        {
            _token = token;
            _baseUrl = baseUrl;
            _restClient = restClient ?? new RestClient(baseUrl.GetDescription());
        }

        public async Task<RestResponse> ExecuteAsync<T>(PicPayRequest<T> picPayRequest) where T : class
        {
            var request = new RestRequest(picPayRequest.Endpoint, (RestSharp.Method)picPayRequest.Method);
            if (picPayRequest.Body != null)
                request.AddJsonBody(picPayRequest.Body, ContentType.Json);
            if (_baseUrl == BaseUrl.ProductionEcommerce)
                request.AddOrUpdateHeader("x-picpay-token", _token);
            request.AddOrUpdateHeader("accept", ContentType.Json);
            request.AddOrUpdateHeader("user-agent", PicPayUtil.GetUserAgent());
            if (picPayRequest.Headers != null)
                foreach (var header in picPayRequest.Headers)
                    request.AddOrUpdateHeader(header.Key, header.Value);
            return await _restClient.ExecuteAsync(request);
        }
    }
}
