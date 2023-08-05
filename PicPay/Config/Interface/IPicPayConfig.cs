namespace PicPay
{
    public  interface IPicPayConfig
    {
        BaseUrl BaseUrl { get; }
        string Token { get; }
        IRestClient? RestClient { get; }
    }
}
