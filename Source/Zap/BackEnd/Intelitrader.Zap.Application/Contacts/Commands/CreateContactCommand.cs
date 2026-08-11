using MediatR;
using Intelitrader.Zap.Domain.Entities;
using Intelitrader.Zap.Domain.Interfaces;
using Intelitrader.Zap.Application.Dtos;
namespace Intelitrader.Zap.Application.Contacts.Commands
{
    public record CreateContactCommand(string Name, string Number) : IRequest<ContactResponse>;

    public class CreateContactHandler : IRequestHandler<CreateContactCommand, ContactResponse>
    {
        private readonly IMessageBroker _messageBroker;

        public CreateContactHandler(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public async Task<ContactResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact(request.Name, request.Number);

            await _messageBroker.PublishContactAsync(contact);

            return new ContactResponse(contact.Id, contact.Name, contact.Number.Value, contact.CreatedAt);
        }
    }
}
