def abrir_arquivo(caminho, modo):
    arquivo = open(caminho, modo, encoding="UTF-8")
    return arquivo

def fechar_arquivo(arquivo):
    arquivo.close()

def info_produtos(produtos):
    '''Função que abre o arquivo produtos.TXT e o devolve em forma de dicionario, onde
    as chaves do dicio_produtos equivale ao código de produto e os valores são quantidade min e quantidade em estoque.'''
    file_produtos = abrir_arquivo(produtos, "r")
    dicionario = {}
    for i in file_produtos:
        linha_arquivo = i
        lista_arquivo = linha_arquivo.strip()
        info_dividida = lista_arquivo.split(";")
        dicionario_linhas = {info_dividida[0]: info_dividida[1:]}
        dicionario.update(dicionario_linhas)
    return dicionario

def escreverArquivo(pathArquivo,nomeArquivo, texto):
    arquivo = abrir_arquivo(pathArquivo+"/"+f"{nomeArquivo}", "w+")
    arquivo.write(texto)
    fechar_arquivo(arquivo)

def relatorioCanais(dicioCanais):
    texto = "Quantidades de Vendas por canal\n"
    texto = texto + "\n1 - Representantes		"+str(dicioCanais["Representantes"])
    texto = texto + "\n2 - Website			"+str(dicioCanais["Website"])
    texto = texto + "\n3 - App móvel Android		"+str(dicioCanais["Android"])
    texto = texto + "\n4 - App móvel iPhone		"+str(dicioCanais["Iphone"])
    path = "C:/Users/Eduardo/Documents/Codiguin"
    nomeArquivo = "TOTCANAIS.TXT"
    escreverArquivo(path, nomeArquivo, texto)

def gerarDivergencias(divegencia):
    texto = ""
    for linha in divegencia:
        texto += linha
    path = "C:/Users/Eduardo/Documents/Codiguin"
    nomeArquivo = "DIVERGENCIAS.TXT"
    escreverArquivo(path,nomeArquivo, texto)

def registrar_vendas(info_produtos, vendas):
    file_vendas = abrir_arquivo(vendas, "r")
    divergencias = []
    contLinhas = 1
    canais = {"Representantes": 0, "Website": 0, "Android": 0, "Iphone": 0}
    relatorioFinal = []
    for i in file_vendas:
        linha_arquivo = i
        lista_arquivo = linha_arquivo.strip()
        info_dividada = lista_arquivo.split(";")
        if info_dividada[0] not in info_produtos:
            divergencias.append(f"Linha {contLinhas} - Código de Produto não encontrado [{info_dividada[0]}].\n")
        elif info_dividada[2] == "135":
            divergencias.append(f"Linha {contLinhas} – Venda cancelada.\n")
        elif info_dividada[2] == "190":
            divergencias.append(f"Linha {contLinhas} – Venda não finalizada.\n")
        elif info_dividada[2] == "999":
            divergencias.append(f"Linha {contLinhas} – Erro desconhecido. Acionar equipe de TI.\n")
        else:
            relatorioProduto = []
            qtCo = int(info_produtos[info_dividada[0]][0])
            qtMin = int(info_produtos[info_dividada[0]][1])
            qtVendas = int(info_dividada[1])
            estoque_pos_venda = qtCo - qtVendas
            necessidade = 0
            transferencia = 0
            if estoque_pos_venda < qtMin:
                necessidade = qtMin - estoque_pos_venda
                transferencia = necessidade
                if necessidade > 1 and necessidade < 10:
                    transferencia = 10
            relatorioProduto.append(info_dividada[0])
            relatorioProduto.append(qtCo)
            relatorioProduto.append(qtMin)
            relatorioProduto.append(qtVendas)
            relatorioProduto.append(estoque_pos_venda)
            relatorioProduto.append(necessidade)
            relatorioProduto.append(transferencia)
            relatorioFinal.append(relatorioProduto)
            if info_dividada[3] == "1":
                canais["Representantes"] += qtVendas
            elif info_dividada[3] == "2":
                canais["Website"] += qtVendas
            elif info_dividada[3] == "3":
                canais["Android"] += qtVendas
            else:
                canais["Iphone"] += qtVendas
        contLinhas += 1
    relatorioCanais(canais)
    gerarDivergencias(divergencias)

caminhoProdutos = "C:/Users/Eduardo/Documents/GitHub/quero-ser/Desafio/Caso de teste 1/c1_produtos.txt"
dicioProdutos = info_produtos(caminhoProdutos)

caminhoVendas = "C:/Users/Eduardo/Documents/GitHub/quero-ser/Desafio/Caso de teste 1/c1_vendas.txt"

registrar_vendas(dicioProdutos, caminhoVendas)