from pathlib import Path

def abrir_arquivo(caminho, modo):
    arquivo = open(caminho, modo, encoding="UTF-8")
    return arquivo

def fechar_arquivo(arquivo):
    arquivo.close()

def escreverArquivo(pathArquivo,nomeArquivo, texto):
    pathArquivo = Path(pathArquivo+"/"+f"{nomeArquivo}")
    arquivo = abrir_arquivo(pathArquivo, "w+")
    arquivo.write(texto)
    fechar_arquivo(arquivo)

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
    fechar_arquivo(file_produtos)
    return dicionario

def relatorioCanais(dicioVendas):
    '''Função que pecorre o dicionario com as informações de venda e as relaciona com seus devidos canais'''
    canais = [0,0,0,0] #Iniciando a lista de canais
    for vendas in dicioVendas.values(): #Pecorrendo o dicionario de vendas
        canais[0] += vendas[1] #Somando as vendas por representantes
        canais[1] += vendas[2] #Somando as vendas por website
        canais[2] += vendas[3] #Somando as vendas por Android
        canais[3] += vendas[4] #Somando as vendas por Iphone
    texto = "Quantidades de Vendas por canal\n"
    texto = texto + "\n1 - Representantes		" + str(canais[0])
    texto = texto + "\n2 - Website			" + str(canais[1])
    texto = texto + "\n3 - App móvel Android		" + str(canais[2])
    texto = texto + "\n4 - App móvel iPhone		" + str(canais[3]) 
    pathCanais = input("Digite o caminho onde deseja salvar o relatorio sobre os canais de vendas: ")
    nomeArquivo = "TOTCANAIS.TXT"
    escreverArquivo(pathCanais, nomeArquivo, texto)

def gerarDivergencias(divegencia):
    texto = ""
    for linha in divegencia:
        texto += linha
    pathDivergencias = input("Digite o caminho onde deseja salvar o relatorio de divergencias: ")
    nomeArquivo = "DIVERGENCIAS.TXT"
    escreverArquivo(pathDivergencias,nomeArquivo, texto)

def gerarRelatorioTransferencia(infoProdutos, infoVendas):
    texto = "Necessidade de Transferência Armazém para CO\n"
    texto += "Produto	QtCO	QtMin	QtVendas	Estq.após	Necess.	Transf. de"
    texto += "\n					Vendas			Arm p/ CO\n"
    for produto in infoProdutos.keys():
        qtCo = int(infoProdutos[produto][0])
        qtMin = int(infoProdutos[produto][1])
        qtVendas = infoVendas[produto][0]
        estoque = qtCo - qtVendas
        necessidade = 0
        if estoque < qtMin:
            necessidade = qtMin - estoque
            if necessidade > 1 and necessidade < 10:
                necessidade = 10
        transferencia = necessidade
        texto += f"\n{produto}	{qtCo}	{qtMin}	{qtVendas}		{estoque}		{necessidade}		{transferencia}"
    pathTransferencia = input("Digite o caminho onde deseja salvar o relatorio de transferencia: ")
    nomeArquivo = "transfere.txt"
    escreverArquivo(pathTransferencia,nomeArquivo, texto)

def main(info_produtos, arquivoVendas):
    divergencias = []
    contLinhas = 1
    dicioVendas = {}
    file_vendas = arquivoVendas
    for i in file_vendas:
        linha_arquivo = i
        lista_arquivo = linha_arquivo.strip()
        info_dividada = lista_arquivo.split(";")
        if info_dividada[0] not in info_produtos:
            divergencias.append(f"Linha {contLinhas} - Código de Produto não encontrado [{info_dividada[0]}].\n")
        else:
            if info_dividada[2] == "135":
                divergencias.append(f"Linha {contLinhas} – Venda cancelada.\n")
            elif info_dividada[2] == "190":
                divergencias.append(f"Linha {contLinhas} – Venda não finalizada.\n")
            elif info_dividada[2] == "999":
                divergencias.append(f"Linha {contLinhas} – Erro desconhecido. Acionar equipe de TI.\n")
            else:
                if info_dividada[0] in dicioVendas:
                    dicioVendas[info_dividada[0]][0] += int(info_dividada[1])
                    if info_dividada[3] == "1":
                        dicioVendas[info_dividada[0]][1] += int(info_dividada[1])
                    elif info_dividada[3] == "2":
                        dicioVendas[info_dividada[0]][2] += int(info_dividada[1])
                    elif info_dividada[3] == "3":
                        dicioVendas[info_dividada[0]][3] += int(info_dividada[1])
                    else:
                        dicioVendas[info_dividada[0]][4] += int(info_dividada[1])
                else:
                    if info_dividada[3] == "1":
                        dicionario_linhas = {info_dividada[0]: [int(info_dividada[1]),int(info_dividada[1]),0,0,0]}
                    elif info_dividada[3] == "2":
                        dicionario_linhas = {info_dividada[0]: [int(info_dividada[1]),0,int(info_dividada[1]),0,0]}
                    elif info_dividada[3] == "3":
                        dicionario_linhas = {info_dividada[0]: [int(info_dividada[1]),0,0,int(info_dividada[1]),0]}
                    else:
                        dicionario_linhas = {info_dividada[0]: [int(info_dividada[1]),0,0,0,int(info_dividada[1])]}
                    dicioVendas.update(dicionario_linhas)
        contLinhas += 1
    relatorioCanais(dicioVendas)
    gerarDivergencias(divergencias)
    gerarRelatorioTransferencia(info_produtos, dicioVendas)

pathProdutos = input("Digite o caminho para o arquivo com as informações dos produtos:")
pathProdutos = Path(pathProdutos)
infoProdutos = info_produtos(pathProdutos)

pathVendas = input("Digite o caminho para o arquivo com as informações de vendas")
pathVendas = Path(pathVendas)
arquivoVendas = abrir_arquivo(pathVendas, "r")

main(infoProdutos, arquivoVendas)