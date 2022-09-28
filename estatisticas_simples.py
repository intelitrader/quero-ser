def estatisticas(numeros):
    minimo = min(numeros)
    maximo = max(numeros)
    nelementos = len(numeros)
    valorm = sum(numeros) / len(numeros)

    return minimo, maximo, nelementos, valorm;
