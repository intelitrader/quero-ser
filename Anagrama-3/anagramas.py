def anagramas(palavra):
    resultado = set()
    
    if not palavra:
        resultado.add(palavra)
    else:
        for letra in palavra:
            sletra = palavra.replace(letra, "", 1)
            for anagrama in anagramas(sletra):
                resultado.add(letra + anagrama)
                
       
    return resultado
#https://dojopuzzles.com/problems/anagramas/
