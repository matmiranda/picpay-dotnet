namespace PicPay.Model
{
    public class Error
    {
        [JsonPropertyName("field"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Field { get; set; }
        [JsonPropertyName("message"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }
    }
}
