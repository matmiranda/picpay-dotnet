using Newtonsoft.Json;

namespace PicPay.Models
{
    public class NotificationRequest
    {
        [JsonProperty("authorizationId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AuthorizationId { get; set; }
        [JsonProperty("referenceId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ReferenceId { get; set; }
    }
}