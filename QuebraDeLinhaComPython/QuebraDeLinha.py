#https://dojopuzzles.com/problems/quebra-de-linha/

# encoding: utf-8
# encoding: iso-8859-1
# encoding: win-1252


texto = input("insira um texto")
print("========================================================")
limite = input("qual o limite de caracteres você gostaria?")
print("========================================================")
atual = 1
novaString = ''

for x in texto:
    atual += 1
    if atual >= 13 and x == ' ':
        novaString = novaString + '\n' 
        atual = 1
    else:
        novaString = novaString + x    

print(novaString)