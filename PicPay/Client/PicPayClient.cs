namespace PicPay
{
    public class PicPayClient : IPicPayClient
    {
        private readonly PicPayConfig _picPayConfig;

        public PicPayClient(PicPayConfig picPayConfig)
        {
            picPayConfig.RestClient ??= new RestClient(picPayConfig.BaseUrl.GetDescription());
            _picPayConfig = picPayConfig;
            Payment = new PaymentService(_picPayConfig);
        }

        public PaymentService Payment { get; }
    }
}
