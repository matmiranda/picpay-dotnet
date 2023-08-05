namespace PicPay
{
    public class PaymentService
    {
        private readonly IPicPayConfig _picPayConfig;

        public PaymentService(IPicPayConfig picPayConfig)
        {
            _picPayConfig = picPayConfig;
        }

        private IRestClient RestClient
        {
            get
            {
                var MsgError = "RestClient is null. Make sure it's properly configured.";
                if (_picPayConfig.RestClient is null)
                    throw new InvalidOperationException(MsgError);
                return _picPayConfig.RestClient;
            }
        }

        public async Task<PicPayResponse> CreateAsync(PaymentRequest body)
        {
            var endpoint = "payments";
            var request = new RestRequest(endpoint, (RestSharp.Method)Method.Post);
            request.AddJsonBody(body, ContentType.Json);
            request.AddOrUpdateHeader("x-picpay-token", _picPayConfig.Token);
            request.AddOrUpdateHeader("accept", ContentType.Json);
            request.AddOrUpdateHeader("user-agent", PicPayUtil.GetUserAgent());

            var response = await RestClient.ExecuteAsync(request);

            return new()
            {
                RestResponse = response,
                PaymentResponse = PicPayUtil.GetJsonObject(response.Content)
            };
        }

        public async Task<PicPayResponse> CaptureAsync(PaymentRequest body, string referenceId)
        {
            var endpoint = $"payments/{referenceId}/capture";
            var request = new RestRequest(endpoint, (RestSharp.Method)Method.Post);
            request.AddJsonBody(body, ContentType.Json);
            request.AddOrUpdateHeader("x-picpay-token", _picPayConfig.Token);
            request.AddOrUpdateHeader("accept", ContentType.Json);
            request.AddOrUpdateHeader("user-agent", PicPayUtil.GetUserAgent());

            var response = await RestClient.ExecuteAsync(request);

            return new()
            {
                RestResponse = response,
                PaymentResponse = PicPayUtil.GetJsonObject(response.Content)
            };
        }

        public async Task<PicPayResponse> CancelAsync(PaymentRequest body, string referenceId)
        {
            var endpoint = $"payments/{referenceId}/refunds";
            var request = new RestRequest(endpoint, (RestSharp.Method)Method.Post);
            request.AddJsonBody(body, ContentType.Json);
            request.AddOrUpdateHeader("x-picpay-token", _picPayConfig.Token);
            request.AddOrUpdateHeader("accept", ContentType.Json);
            request.AddOrUpdateHeader("user-agent", PicPayUtil.GetUserAgent());

            var response = await RestClient.ExecuteAsync(request);

            return new()
            {
                RestResponse = response,
                PaymentResponse = PicPayUtil.GetJsonObject(response.Content)
            };
        }

        public async Task<PicPayResponse> StatusAsync(string referenceId)
        {
            var endpoint = $"payments/{referenceId}/status";
            var request = new RestRequest(endpoint, (RestSharp.Method)Method.Get);
            request.AddOrUpdateHeader("x-picpay-token", _picPayConfig.Token);
            request.AddOrUpdateHeader("accept", ContentType.Json);
            request.AddOrUpdateHeader("user-agent", PicPayUtil.GetUserAgent());

            var response = await RestClient.ExecuteAsync(request);

            return new()
            {
                RestResponse = response,
                PaymentResponse = PicPayUtil.GetJsonObject(response.Content)
            };
        }
    }
}
