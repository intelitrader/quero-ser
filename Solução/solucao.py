def info_produtos():
    '''Função que abre o arquivo produtos.TXT e o devolve em forma de dicionario, onde
    as chaves do dicio_produtos equivale ao código de produto e os valores são quantidade min e quantidade em estoque.'''
    dicionario_produtos = {}
    caminho = input("Digite o caminho do arquivo produtos: ")
    file_produtos = open(caminho, "r", encoding="UTF-8")
    for i in file_produtos:
        linha_arquivo = i
        lista_arquivo = linha_arquivo.strip()
        info_dividida = lista_arquivo.split(";")
        dicionario_linhas = {info_dividida[0]:info_dividida[1:]}
        dicionario_produtos.update(dicionario_linhas)
    file_produtos.close()
    return dicionario_produtos