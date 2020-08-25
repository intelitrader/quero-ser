using Quero.Ser.Application.Interfaces;
using System.Linq;

namespace Quero.Ser.Application.UseCase.Jokenpo
{
    public class JokenpoUseCase : IJokenpoUseCase
    {
        private static readonly string[] VALIDA_JOKENPO = { "papel", "pedra", "tesoura" };

        public string Handler(string jogadorUm, string jogadorDois)
        {
            if (!VALIDA_JOKENPO.Contains(jogadorUm))
                return "Escolha uma opção valida para o jogador um.";

            if (!VALIDA_JOKENPO.Contains(jogadorDois))
                return "Escolha uma opção valida para o jogador dois.";

            string resultado;

            if (jogadorUm == jogadorDois)
            {
                resultado = "empate";
            }
            else
            {
                if (jogadorUm == "pedra")
                {
                    if (jogadorDois == "papel")
                        resultado = "jogador Dois GANHOU!!!";
                    else
                        resultado = "jogador Um GANHOU!!!";
                }
                else if (jogadorUm == "papel")
                {
                    if (jogadorDois == "tesoura")
                        resultado = "jogador Dois GANHOU!!!";
                    else
                        resultado = "jogador Um GANHOU!!!";
                }
                else
                {
                    if (jogadorDois == "pedra")
                        resultado = "jogador Dois GANHOU!!!";
                    else
                        resultado = "jogador Um GANHOU!!!";
                }
            }

            return resultado;
        }
    }
}
