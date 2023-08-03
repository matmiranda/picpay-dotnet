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
    }
}
