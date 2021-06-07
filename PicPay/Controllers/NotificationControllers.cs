using Newtonsoft.Json;
using PokeSpace.Application.PicPay.Models.Request;
using PokeSpace.Application.PicPay.Models.Response;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokeSpace.Application.PicPay.Controllers
{
    public class NotificationControllers
    {
        public async Task<NotificationResponse> Create(NotificationRequest body, string seller_token, string url)
        {
            PicPayClient.HttpClient.DefaultRequestHeaders.Remove("x-picpay-token");
            PicPayClient.HttpClient.DefaultRequestHeaders.Add("x-seller-token", seller_token);
            string json = JsonConvert.SerializeObject(body);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await PicPayClient.HttpClient.PostAsync(url, stringContent);
            NotificationResponse notificationResponse =
                JsonConvert.DeserializeObject<NotificationResponse>(await response.Content.ReadAsStringAsync());
            notificationResponse.StatusCode = (int)response.StatusCode;
            PicPayClient.HttpClient.DefaultRequestHeaders.Remove("x-seller-token");
            PicPayClient.HttpClient.DefaultRequestHeaders.Add("x-picpay-token", PicPayClient.Token);
            return notificationResponse;
        }
    }
}
