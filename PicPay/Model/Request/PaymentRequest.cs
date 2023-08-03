namespace PicPay.Model
{
    public class PaymentRequest
    {
        [JsonPropertyName("referenceId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ReferenceId { get; set; }
        [JsonPropertyName("callbackUrl"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CallbackUrl { get; set; }
        [JsonPropertyName("returnUrl"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ReturnUrl { get; set; }
        [JsonPropertyName("value"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Value { get; set; }
        [JsonPropertyName("expiresAt"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ExpiresAt { get; set; }
        [JsonPropertyName("channel"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Channel { get; set; }
        [JsonPropertyName("purchaseMode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PurchaseMode { get; set; }
        [JsonPropertyName("buyer"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Buyer? Buyer { get; set; }
        [JsonPropertyName("notification"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Notification? Notification { get; set; }
        [JsonPropertyName("softDescriptor"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SoftDescriptor { get; set; }
        [JsonPropertyName("autoCapture"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoCapture { get; set; }
        [JsonPropertyName("amount"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Amount { get; set; }
        [JsonPropertyName("authorizationId"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AuthorizationId { get; set; }
    }
}
