namespace PicPay.Model
{
    public class Buyer
    {
        [JsonPropertyName("firstName"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FirstName { get; set; }
        [JsonPropertyName("lastName"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LastName { get; set; }
        [JsonPropertyName("document"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Document { get; set; }
        [JsonPropertyName("email"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Email { get; set; }
        [JsonPropertyName("phone"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Phone { get; set; }
    }
}
