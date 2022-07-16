from random import choice
from time import sleep

def Player1VictoryMessage():
  sleep(.5)
  victoriousPhrases = ["Dessa vez a vitória foi do player 1!", "O player 1 é o vencedor!!!", "O player 1 teve mais sorte dessa vez...", "VITÓRIA DO PLAYER 1!!!"]
  print(choice(victoriousPhrases), "\n")
def Player2VictoryMessage():
  sleep(.5)
  victoriousPhrases = ["Dessa vez a vitória foi do player 2!", "O player 2 é o vencedor!!!", "O player 2 teve mais sorte dessa vez...", "VITÓRIA DO PLAYER 2!!!"]
  print(choice(victoriousPhrases), "\n")
def errorMessage():
  print("Detectamos um erro... Informe um numero inteiro entre 1 e 3 para continuar :/")
def drawMessage():
  print("Houve um empate, joguem novamente :)")
