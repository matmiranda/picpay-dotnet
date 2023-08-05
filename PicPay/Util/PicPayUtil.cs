namespace PicPay
{
    public class PicPayUtil
    {
        internal static string GetUserAgent()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            var version = attribute?.InformationalVersion;
            return $"picpay-dotnet/{version}";
        }

        internal static PaymentResponse? GetJsonObject(string? content)
        {
            if (!string.IsNullOrEmpty(content))
                return JsonSerializer.Deserialize<PaymentResponse>(content);
            else
                return null;
        }
    }
}
