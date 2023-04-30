def agrupar_em_intervalos(numeros):
    numeros.sort()
    intervalos = []
    inicio = numeros[0]
    for i in range(1, len(numeros)):
        if numeros[i] - numeros[i - 1] > 1:
            intervalos.append((inicio, numeros[i - 1]))
            inicio = numeros[i]
    intervalos.append((inicio, numeros[-1]))
    return [
        f"[{i[0]}-{i[1]}]" if i[0] != i[1] else f"[{i[0]}]" for i in intervalos
    ]


numeros = [100, 101, 102, 103, 104, 105, 110, 111, 113, 114, 115, 150]
intervalos = agrupar_em_intervalos(numeros)
print(intervalos)
# Saída ['[100-105]', '[110-111]', '[113-115]', '[150]']
