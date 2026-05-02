saque = int(input("Qual valor do saque? "))
print("Serão fornecidas notas de 10, 20, 50 e 100 reais.")

cem = saque//100
cinquenta = saque%100//50
vinte = ((saque % 100) % 50)// 20
dez = (((saque%100) % 50) % 20)//10


if cem != 0:
    print(f"Receberá {cem} notas de R$100,00")
if cinquenta != 0:
    print(f"Receberá {cinquenta} notas de R$50,00")
if vinte != 0:
    print(f"Receberá {vinte} notas de R$20,00")
if dez != 0:
    print(f"Receberá {dez} notas de R$10,00")
print(f"Você sacou R${saque},00")