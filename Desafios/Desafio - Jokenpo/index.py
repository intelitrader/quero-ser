from messages import (Player1VictoryMessage, Player2VictoryMessage,
                      drawMessage, errorMessage)

while True:
  while True:
    try:
      player1 = int(input("Jogador 1, escolha entre pedra [1], papel [2] e tesoura [3]: "))
      if player1 > 3:
        raise
      break
    except:
      errorMessage()
      continue
  while True:
    try:
      player2 = int(input("Jogador 2, escolha entre pedra [1], papel [2] e tesoura [3]: "))
      if player1 > 3:
        raise
      break
    except:
      errorMessage()
      continue
  if player1 == player2:
    drawMessage()
  elif player1 == 1 and player2 == 2:
    Player2VictoryMessage()
  elif player1 == 2 and player2 == 3:
    Player2VictoryMessage()
  elif player1 == 3 and player2 == 1:
    Player2VictoryMessage()
  elif player1 == 3 and player2 == 2:
    Player1VictoryMessage()
  elif player1 == 2 and player2 == 1:
    Player1VictoryMessage()
  elif player1 == 1 and player2 == 3:
    Player1VictoryMessage()

  





  


