def letras(letra1, letra2):
    alfabeto = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"]
    if alfabeto.index(letra1) > alfabeto.index(letra2):
        print("Digite em ordem alfabética.")
    else:
        distancia = alfabeto.index(letra2) - alfabeto.index(letra1) -1
        print("'{letra1}','{letra2}' = {distancia}".
            format(letra1 = letra1, letra2=letra2, distancia=distancia))
