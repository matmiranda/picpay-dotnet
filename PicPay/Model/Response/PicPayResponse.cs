namespace PicPay.Model
{
    public class PicPayResponse
    {
        public required RestResponse RestResponse { get; set; }
        public PaymentResponse? PaymentResponse { get; set; }
    }
}
