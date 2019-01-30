using Newtonsoft.Json;

namespace PicPay.Models
{
    public class Buyer
    {
        [JsonProperty("firstName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FirstName { get; set; }
        [JsonProperty("lastName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LastName { get; set; }
        [JsonProperty("document", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Document { get; set; }
        [JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Phone { get; set; }
    }
}