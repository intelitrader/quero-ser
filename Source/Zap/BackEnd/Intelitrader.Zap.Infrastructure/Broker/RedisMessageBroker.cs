using System.Text.Json;
using Intelitrader.Zap.Domain.Entities;
using Intelitrader.Zap.Domain.Interfaces;
using StackExchange.Redis;

namespace Intelitrader.Zap.Infrastructure.Broker
{
    public class RedisMessageBroker : IMessageBroker
    {
        private readonly IConnectionMultiplexer _redis;
        private const string ContactQueue = "ws_queue_contacts";
        private const string MessageStream = "ws_stream_messages";

        public RedisMessageBroker(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task PublishContactAsync(Contact contact)
        {
            var db = _redis.GetDatabase();

            var json = JsonSerializer.Serialize(contact);

            await db.ListLeftPushAsync(ContactQueue, json);
        }

        public async virtual IAsyncEnumerable<WhatsAppMessage> SubscribeMessagesAsync(
            [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
        {
            var db = _redis.GetDatabase();

            while (!ct.IsCancellationRequested)
            {
                var messages = await db.StreamReadAsync(MessageStream, "0-0", count: 1);

                foreach (var entry in messages)
                {
                    var dataField = entry.Values.FirstOrDefault(v => v.Name == "data");
                    if (!dataField.Value.IsNull)
                    {
                        var message = JsonSerializer.Deserialize<WhatsAppMessage>(dataField.Value!);
                        if (message != null) yield return message;
                    }

                    await db.StreamDeleteAsync(MessageStream, new[] { entry.Id });
                }

                await Task.Delay(500, ct);
            }
        }
    }
}