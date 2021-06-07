using Newtonsoft.Json;

namespace PokeSpace.Application.PicPay.Models.Request
{
    public class NotificationRequest
    {
        [JsonProperty("authorizationId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AuthorizationId { get; set; }
        [JsonProperty("referenceId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ReferenceId { get; set; }
    }
}
