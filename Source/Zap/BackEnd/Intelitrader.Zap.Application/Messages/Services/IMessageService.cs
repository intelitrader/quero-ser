using Intelitrader.Zap.Domain.Interfaces;
using Intelitrader.Zap.Application.Dtos;
using System.Runtime.CompilerServices;

namespace Intelitrader.Zap.Application.Messages.Services;

public interface IMessageService
{
    IAsyncEnumerable<WhatsAppMessageDto> GetMessageStreamAsync(CancellationToken ct);
}

public class MessageService : IMessageService
{
    private readonly IMessageBroker _messageBroker;

    public MessageService(IMessageBroker messageBroker) => _messageBroker = messageBroker;

    public async virtual IAsyncEnumerable<WhatsAppMessageDto> GetMessageStreamAsync([EnumeratorCancellation] CancellationToken ct)
    {
        await foreach (var msg in _messageBroker.SubscribeMessagesAsync(ct))
        {
            yield return new WhatsAppMessageDto(msg.ExternalId, msg.Sender, msg.Content, msg.Timestamp);
        }
    }
}