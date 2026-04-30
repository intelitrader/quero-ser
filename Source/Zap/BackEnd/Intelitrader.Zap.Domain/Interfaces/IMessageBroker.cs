using Intelitrader.Zap.Domain.Entities;

namespace Intelitrader.Zap.Domain.Interfaces
{
    public interface IMessageBroker
    {
        Task PublishContactAsync(Contact contact);
        IAsyncEnumerable<WhatsAppMessage> SubscribeMessagesAsync(CancellationToken ct);
    }
}
