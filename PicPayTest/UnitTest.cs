using Moq;
using NUnit.Framework;
using PicPay;
using PicPay.Model;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace PicPayTest
{
    public class Tests
    {
        [Test]
        public async Task CretaPaymentAysc()
        {
            var config = new PicPayConfig
            {
                BaseUrl = BaseUrl.ProductionEcommerce,
                Token = "your-token"
            };

            var client = new PicPayClient(config);

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

var response = await client.Payment.CreateAsync(body);

            Assert.That(response.RestResponse.IsSuccessStatusCode, Is.False);
        }

        [Test]
        public async Task MockCretaPaymentAysc()
        {
            var body = new PaymentRequest
            {
                ReferenceId = "102030"
            };
            var mockRestClient = new Mock<IRestClient>();

            var mockPicPayConfig = new Mock<IPicPayConfig>();
            mockPicPayConfig.SetupGet(config => config.Token).Returns("your-token");
            mockPicPayConfig.Setup(config => config.RestClient).Returns(mockRestClient.Object);

            var paymentService = new PaymentService(mockPicPayConfig.Object);
            var paymentRequest = new PaymentRequest();
            var expectedResponse = new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonSerializer.Serialize(body)
            };

            mockRestClient
                .Setup(client => client.ExecuteAsync(It.IsAny<RestRequest>(), default))
                .ReturnsAsync(expectedResponse);

            var result = await paymentService.CreateAsync(paymentRequest);

            if (result.PaymentResponse is null)
                Assert.Fail("PaymentResponse is null");
            else
                Assert.That(result.PaymentResponse.ReferenceId, Is.EqualTo("102030"));
        }
    }
}