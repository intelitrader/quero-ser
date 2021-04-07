vsaque = int(input('Digite o valor do saque:'))
total = vsaque

cedula = 100
totalcedulas = 0

while True:

    if vsaque >= cedula:
        vsaque -= cedula
        totalcedulas += 1

    else:
        if totalcedulas > 0:
            print(f"Total de",totalcedulas,"cédulas é:",cedula)

        if cedula == 100:
            cedula = 50

        elif cedula == 50:
            cedula = 20

        elif cedula == 20:
            cedula = 10

        totalcedulas = 0
        if vsaque == 0:
            print("Foi realizado um saque de:",total)
            exit()
#https://dojopuzzles.com/problems/caixa-eletronico/
