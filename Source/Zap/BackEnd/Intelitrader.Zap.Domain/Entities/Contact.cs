using Intelitrader.Zap.Domain.ValueObjects;

namespace Intelitrader.Zap.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public PhoneNumber Number { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Contact(string name, string number)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exceptions.DomainException("O nome do contato é obrigatório.");

            Id = Guid.NewGuid();
            Name = name;
            Number = new PhoneNumber(number); 
            CreatedAt = DateTime.UtcNow;
        }
    }
}
