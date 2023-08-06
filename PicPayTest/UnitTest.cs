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
            var paymentRequest = new PaymentRequest
            {
                ReferenceId = "102030"
            };

            var responseMock = new PaymentResponse
            {
                ReferenceId = "102030",
                PaymentUrl = "teste ok"
            };

            // Crie um mock do IRestClientWrapper
            var mockRestClient = new Mock<IRestClient>();

            // Defina o valor de retorno que você deseja para o método ExecuteAsync
            var restResponse = new RestResponse
            {
                StatusCode = HttpStatusCode.Created,
                Content = JsonSerializer.Serialize(responseMock)
            };

            // Configura o mock para retornar 'restResponse' quando o método 'ExecuteAsync' for chamado
            mockRestClient
                .Setup(x => x.ExecuteAsync(It.IsAny<RestRequest>(), default))
                .ReturnsAsync(restResponse);

            var config = new PicPayConfig
            {
                BaseUrl = BaseUrl.ProductionEcommerce,
                Token = "123",
                RestClient = mockRestClient.Object
            };

            // Create the PagBankClient using the mocked IRestClient
            var client = new PicPayClient(config);

            // Chame o método que utiliza o método ExecuteAsync
            var response = await client.Payment.CreateAsync(paymentRequest);

            // Verifique o resultado
            if (response.PaymentResponse is not null)
                Assert.That(response.PaymentResponse.PaymentUrl, Is.EqualTo("teste ok"));
            else
                Assert.Fail();

        }
    }
}