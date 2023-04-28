notas_disponiveis = [100, 50, 20, 10]

def entregar_notas(valor):
    notas_entregues = []
    for nota in notas_disponiveis:
        while valor >= nota:
            notas_entregues.append(nota)
            valor -= nota
    return notas_entregues



# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    valor_saque = int(input('Qual o valor do Saque?'))
    notas_saque = entregar_notas(valor_saque)
    print("Valor do Saque: R$", valor_saque, " - Notas entregues:", notas_saque)
