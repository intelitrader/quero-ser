def mensagem_erro(value_taken):
    mensagem_erro = []
    
    if value_taken < 0:
        mensagem_erro.append('Informe um valor positivo')
    if value_taken < 10:
        mensagem_erro.append('Saque um valor acima de 10 reais')
    if value_taken % 10 != 0:
        mensagem_erro.append('Informe um valor válido para o saque')

    return mensagem_erro

def dinheiro_caixa(value_taken):
    if len(mensagem_erro(value_taken)) > 0:
        return mensagem_erro(value_taken)[0]

    possibilidades_notas = [100, 50, 20, 10]
    retornar_notas = []

    for index, note in enumerate(possibilidades_notas):
        while value_taken != 0 and value_taken >= possibilidades_notas[index]:
            retornar_notas.append(possibilidades_notas[index])
            value_taken -= possibilidades_notas[index]
    
    return retornar_notas
