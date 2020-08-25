using System.Collections.Generic;

namespace Quero.Ser.Application.Interfaces
{
    public interface IFizzBuzzUseCase
    {
        IEnumerable<string> Handler(int inicio, int fim);
    }
}
