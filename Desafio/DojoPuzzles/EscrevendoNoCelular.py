def mensagem_para_numeros(mensagem):
    letras_para_numeros = {
        "ABC": "2",
        "DEF": "3",
        "GHI": "4",
        "JKL": "5",
        "MNO": "6",
        "PQRS": "7",
        "TUV": "8",
        "WXYZ": "9",
        " ": "0",
    }
    mensagem_numeros = ""
    for letra in mensagem:
        letra = letra.upper()
        for letras, numero in letras_para_numeros.items():
            if letra in letras:
                if mensagem_numeros[-1:] == numero:
                    mensagem_numeros += "_"
                mensagem_numeros += numero * (letras.index(letra) + 1)
                break
    return mensagem_numeros


# Exemplo de uso
mensagem = "SEMPRE ACESSO O DOJOPUZZLES"
print(mensagem_para_numeros(mensagem))
# Saída: 77773367_7773302_222337777_777766606660366656667889999_9999555337777
