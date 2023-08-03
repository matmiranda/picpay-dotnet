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
                ReferenceId = "102030",
                CallbackUrl = "http://www.sualoja.com.br/callback",
                ReturnUrl = "http://www.sualoja.com.br/cliente/pedido/102030",
                Value = 20.51M,
                Buyer = new Buyer
                {
                    FirstName = "João",
                    LastName = "Da Silva",
                    Document = "123.456.789-10",
                    Email = "test@picpay.com",
                    Phone = "+55 27 12345-6789"
                }
            };

            var request = new PicPayRequest<object>
            {
                Body = body,
                Method = Method.Post,
                Endpoint = "{seu_endpoint}"
            };

            var result = await client.ExecuteAsync(request);
            Assert.Pass();
        }
    }
}