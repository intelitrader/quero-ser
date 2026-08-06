namespace MySolution.Models
{
    public enum ChannelModel
    {
            Representative = 1,
            Website = 2,
            Android = 3,
            Iphone = 4,
    }
    public static class ChannelExtensions
    {
    public static string ToFriendlyString(this ChannelModel channel)
        {
            switch(channel)
            {
                case ChannelModel.Representative:
                    return "Representantes";
                case ChannelModel.Website:
                    return "Website";
                case ChannelModel.Android:
                    return "App móvel Android";
                case ChannelModel.Iphone:
                    return "App móvel iPhone";
                default:
                    return "";
            }
        }
    }
}