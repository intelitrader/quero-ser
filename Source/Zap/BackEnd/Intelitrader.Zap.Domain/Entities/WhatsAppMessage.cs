namespace Intelitrader.Zap.Domain.Entities
{
    public class WhatsAppMessage
    {
        public string ExternalId { get; private set; } 
        public string Sender { get; private set; }
        public string Content { get; private set; }
        public DateTime Timestamp { get; private set; }
        public bool IsBusiness { get; private set; }

        public WhatsAppMessage(string externalId, string sender, string content, long unixTimestamp, bool isBusiness)
        {
            ExternalId = externalId;
            Sender = sender;
            Content = content;
            Timestamp = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).UtcDateTime;
            IsBusiness = isBusiness;
        }
    }
}
