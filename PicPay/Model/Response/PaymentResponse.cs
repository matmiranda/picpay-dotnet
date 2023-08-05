namespace PicPay.Model
{
    public class PaymentResponse
    {
        [JsonPropertyName("authorizationId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AuthorizationId { get; set; }
        [JsonPropertyName("referenceId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ReferenceId { get; set; }
        [JsonPropertyName("paymentUrl"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PaymentUrl { get; set; }
        [JsonPropertyName("expiresAt"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ExpiresAt { get; set; }
        [JsonPropertyName("qrcode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Qrcode? Qrcode { get; set; }
        [JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }
        [JsonPropertyName("status"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Status { get; set; }
        [JsonPropertyName("summary"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Summary? Summary { get; set; }
        [JsonPropertyName("message"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }
        [JsonPropertyName("errors"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Error>? Errors { get; set; }
    }
}
