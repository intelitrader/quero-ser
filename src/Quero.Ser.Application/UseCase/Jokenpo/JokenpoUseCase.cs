using Quero.Ser.Application.Interfaces;

namespace Quero.Ser.Application.UseCase.Jokenpo
{
    public class JokenpoUseCase : IJokenpoUseCase
    {
        public string Handler(string jogadorUm, string jogadorDois)
        {
            var resultado = "";

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
