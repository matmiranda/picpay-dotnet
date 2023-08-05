namespace PicPay.Model
{
    public class Qrcode
    {
        [JsonPropertyName("content"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Content { get; set; }
        [JsonPropertyName("base64"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Base64 { get; set; }
    }
}
