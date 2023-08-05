namespace PicPay
{
    public interface IPicPayClient
    {
        public PaymentService Payment { get; }
    }
}
