def abrir_arquivo(caminho):
    arquivo = open(caminho, "r", encoding="UTF-8")
    return arquivo

def fechar_arquivo(arquivo):
    arquivo.close()

def info_produtos(dicionario, produtos):
    '''Função que abre o arquivo produtos.TXT e o devolve em forma de dicionario, onde
    as chaves do dicio_produtos equivale ao código de produto e os valores são quantidade min e quantidade em estoque.'''
    file_produtos = abrir_arquivo(produtos)
    for i in file_produtos:
        linha_arquivo = i
        lista_arquivo = linha_arquivo.strip()
        info_dividida = lista_arquivo.split(";")
        dicionario_linhas = {info_dividida[0]:info_dividida[1:]}
        dicionario.update(dicionario_linhas)

def registrar_vendas(info_produtos, vendas):

    file_vendas = abrir_arquivo(vendas)
    divergencias = []
    contLinhas = 1
    canais = {"Representantes":0,"Website":0,"Android":0,"Iphone":0}
    relatorioFinal = []
    for i in file_vendas:
        linha_arquivo = i
        lista_arquivo = linha_arquivo.strip()
        info_dividada = lista_arquivo.split(";")
        if info_dividada[0] not in info_produtos:
            divergencias.append(f"Linha {contLinhas} - Código de Produto não encontrado [{info_dividada[0]}]./n")
        elif info_dividada[2] == "135":
            divergencias.append(f"Linha {contLinhas} – Venda cancelada./n")
        elif info_dividada[2] == "190":
            divergencias.append(f"Linha {contLinhas} – Venda não finalizada./n")
        elif info_dividada[2] == "999":
            divergencias.append(f"Linha {contLinhas} – Erro desconhecido. Acionar equipe de TI./n")
        else:
            relatorioProduto = []
            qtCo = info_produtos[info_dividada[0]].values[0]
            qtMin = info_produtos[info_dividada[0]].values[1]
            qtVendas = info_dividada[1]
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
            if info_dividada[3] == 1:
                canais["Representantes"] += 1
            elif info_dividada[3] == 2:
                canais["Website"] += 1
            elif info_dividada[3] == 3:
                canais["Android"] += 1
            else:
                canais["Iphone"] += 1