namespace Intelitrader.Zap.Application.Dtos
{
    public record WhatsAppMessageDto(string ExternalId, string Sender, string Content, DateTime Timestamp);
}
