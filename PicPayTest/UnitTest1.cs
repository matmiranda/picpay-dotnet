namespace PicPayTest
{
    public class Tests
    {
        [Test]
        public async Task MockCretaPayment()
        {
            var client = new PicPayClient(BaseUrl.ProductionEcommerce, "1234");

            var body = new PaymentRequest
            {
                AuthorizationId = "555008cef7f321d00ef236333",
                Amount = 50.05M
            };

            var request = new PicPayRequest<object>
            {
                Body = body,
                Method = Method.Post,
                Endpoint = "payments/102030/refunds"
            };

            var result = await client.ExecuteAsync(request);
            Assert.Pass();
        }
    }
}