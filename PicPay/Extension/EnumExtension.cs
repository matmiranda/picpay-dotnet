namespace PicPay
{
    public static class EnumExtension
    {
        public static string GetDescription(this BaseUrl value)
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? ((DescriptionAttribute)attributes[0]).Description
                : value.ToString();
        }
    }
}
