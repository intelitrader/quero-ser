descont=float
valor=42
soma=0

print("Boa tarde!")
qtde=int(input("Quantos livros foram comprados?"))

if qtde == 1:
    valor

if qtde == 2:
    soma=42*2
    descont= soma*5/100
    valor=soma-descont

if qtde == 3:
    soma=42*3
    descont= soma*10/100
    valor=soma-descont

if qtde == 4:
    soma=42*4
    descont= soma*15/100
    valor=soma-descont

if qtde >= 5:
    soma=42*qtde
    descont= soma*20/100
    valor=soma-descont
        
print("O valor da sua compra foi de R$",valor,"reais!");


