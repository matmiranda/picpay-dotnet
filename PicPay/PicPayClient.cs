using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;

namespace PicPay
{
    public class PicPayClient
    {
        internal const string BaseAddress = "https://appws.picpay.com/ecommerce/public/";
        internal static HttpClient HttpClient = null;
        internal static string Token = string.Empty;
        public PicPayClient(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("Token is null or empty");
            Token = token;
            if (HttpClient == null)
            {
                HttpClient = new HttpClient();
                HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpClient.DefaultRequestHeaders.Add("User-Agent", $"PicPay {FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion}");
                HttpClient.BaseAddress = new Uri(BaseAddress);
                HttpClient.DefaultRequestHeaders.Add("x-picpay-token", token);
            }
        }
        public PaymentControllers Payment { get { return new PaymentControllers(); } }
        public NotificationControllers Notification { get { return new NotificationControllers(); } }
    }
}
