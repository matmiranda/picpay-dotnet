using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace PokeSpace.Application.PicPay.Models.Response
{
    public class PaymentResponse
    {
        [JsonProperty("message", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("referenceId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ReferenceId { get; set; }

        [JsonProperty("paymentUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PaymentUrl { get; set; }

        [JsonProperty("errors", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<Error> Errors { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("qrcode", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Qrcode QrCode { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
    }
}
