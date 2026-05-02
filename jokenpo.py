def jokenpo(player1, player2):
    regras = {"pedra": "tesoura", "tesoura": "papel", "papel": "pedra"}
    if player1 == player2:
        print("Empate")
    elif regras[player1] == player2:
        print("{player1} ganha de {player2}".format(player1 = player1,
                                                    player2 = player2))
    else:
        print("{player2} ganha de {player1}".format(player2 = player2,
                                                    player1 = player1))

