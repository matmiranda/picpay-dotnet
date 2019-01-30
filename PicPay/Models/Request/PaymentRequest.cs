using Newtonsoft.Json;

namespace PicPay.Models
{
    public class PaymentRequest
    {
        [JsonProperty("authorizationId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AuthorizationId { get; set; }
        [JsonProperty("referenceId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ReferenceId { get; set; }
        [JsonProperty("callbackUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CallbackUrl { get; set; }
        [JsonProperty("returnUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ReturnUrl { get; set; }
        [JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Value { get; set; }
        [JsonProperty("buyer", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Buyer Buyer { get; set; }
    }
}