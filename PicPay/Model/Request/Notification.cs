namespace PicPay.Model
{
    public class Notification
    {
        [JsonPropertyName("disablePush"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DisablePush { get; set; }
        [JsonPropertyName("disableEmail"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DisableEmail { get; set; }
    }
}
