print("Notas disponíveis R$10 R$20 R$50 R$100")
valor=int(input("Qual valor você deseja sacar?"))
total=valor
totalced=0
ced=100

while True:
    if total >= ced:
        total=total-ced
        totalced=totalced+1
    else:
        print("Total de",totalced,"cédulas de R$",ced)
        if ced==100:
            ced=50
        elif ced==50:
            ced=20
        elif ced==20:
            ced=10
        totalced=0
        if total==0:
            break


