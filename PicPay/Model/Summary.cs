namespace PicPay.Model
{
    public class Summary
    {
        [JsonPropertyName("authorized"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? Authorized { get; set; }
        [JsonPropertyName("paid"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? Paid { get; set; }
        [JsonPropertyName("refunded"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Refunded { get; set; }
    }
}
