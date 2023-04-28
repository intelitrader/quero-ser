def jokenpo(jogada1, jogada2):
    if jogada1 == jogada2:
        return "Empate"
    elif jogada1 == "Pedra":
        if jogada2 == "Tesoura":
            return "Jogador 1 ganhou!"
        else:
            return "Jogador 2 ganhou!"
    elif jogada1 == "Tesoura":
        if jogada2 == "Papel":
            return "Jogador 1 ganhou!"
        else:
            return "Jogador 2 ganhou!"
    elif jogada1 == "Papel":
        if jogada2 == "Pedra":
            return "Jogador 1 ganhou!"
        else:
            return "Jogador 2 ganhou!"
    else:
        return "Jogada inválida!"

# Exemplo de uso
jogada1 = input('Qual a escolha do jogador 1?')
jogada2 = input('Qual a escolha do jogador 2?')
resultado = jokenpo(jogada1, jogada2)
print("Jogada 1:", jogada1)
print("Jogada 2:", jogada2)
print("Resultado:", resultado)