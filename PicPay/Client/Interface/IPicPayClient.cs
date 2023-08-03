namespace PicPay
{
    public interface IPicPayClient
    {
        Task<RestResponse> ExecuteAsync<T>(PicPayRequest<T> picPayRequest) where T : class;
    }
}
