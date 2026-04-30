using Intelitrader.Zap.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Intelitrader.Zap.Domain.ValueObjects
{
    public record PhoneNumber
    {
        public string Value { get; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^\+[1-9]\d{1,14}$"))
            {
                throw new DomainException("Telefone inválido. Utilize o formato E.164 (ex: +5511999999999).");
            }
            Value = value;
        }

        public static implicit operator string(PhoneNumber phone) => phone.Value;
    }
}
