from time import sleep
diamondLine = 1
forwardIndex = 0
centralizeIndexStart = 100
allLetters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']

while True:
  initialLetter = input("Informe a letra na qual deseja basear o diamante de strings: ").lower().strip()
  if initialLetter in allLetters and initialLetter != "a":
    break
  else:
    print("Por favor, informe uma letra entre B e Z")
i = allLetters.index(initialLetter)

for a in allLetters:
  sleep(0.2)
  if allLetters[forwardIndex] != 'a':
    print((allLetters[forwardIndex] + '-' * diamondLine  + allLetters[forwardIndex]).center(centralizeIndexStart, " "))
    diamondLine += 2
  else:
    print(allLetters[forwardIndex].center(centralizeIndexStart, " "))
  forwardIndex += 1
  if allLetters[forwardIndex] == initialLetter:
    break

for a in allLetters:
  sleep(0.2)
  if allLetters[i] != "a":
    print((allLetters[i] + '-' * diamondLine + allLetters[i]).center(centralizeIndexStart, " "))
    diamondLine -= 2
  else:
    print(allLetters[i].center(centralizeIndexStart, " "))
  i -= 1
  if allLetters[i] == "z":
    break




  


