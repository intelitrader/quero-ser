# -*- JokenPo desenvolvido por Ana Ramos-*-

def jokenpo(primeiro_jogador, segundo_jogador):
    opcoes_valida = ['Pedra', 'Papel', 'Tesoura']
    opcoes_jogadores = [primeiro_jogador, segundo_jogador]
    
    if opcoes_jogadores.count('Pedra') == 1 and opcoes_jogadores.count('Tesoura') == 1:
        return 'Ganhador: Pedra'

    if opcoes_jogadores.count('Tesoura') == 1 and opcoes_jogadores.count('Papel') == 1:
        return 'Ganhador: Tesoura'

    if opcoes_jogadores.count('Papel') == 1 and opcoes_jogadores.count('Pedra') == 1:
        return 'Ganhador: Papel'
     
    if opcoes_valida.count(primeiro_jogador) == 0 or opcoes_valida.count(segundo_jogador) == 0:
        return 'Opção inválida!! Tente Pedra, Papel ou Tesoura! '

    if primeiro_jogador == segundo_jogador:
            return 'Empatou!!!'