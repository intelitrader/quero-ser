namespace MySolution.Models
{
    public enum ChannelModel
    {
        CommercialRepresentative = 1,
        Website,
        AndroidApp,
        IphoneApp
    }
    public static class ChannelExtensions
    {
    public static string ToFriendlyString(this Channel channel)
        {
            switch(channel)
            {
                case Channel.Representative:
                    return "Representantes";
                case Channel.Website:
                    return "Website";
                case Channel.Android:
                    return "App móvel Android";
                case Channel.Iphone:
                    return "App móvel iPhone";
                default:
                    return "";
            }
        }
    }
}