using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace PicPay.Models
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
        [JsonIgnore]
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}