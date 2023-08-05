namespace PicPay
{
    public class PicPayConfig : IPicPayConfig
    {
        public required BaseUrl BaseUrl { get; set; }
        public required string Token { get; set; }
        public IRestClient? RestClient { get; set; }
    }
}
