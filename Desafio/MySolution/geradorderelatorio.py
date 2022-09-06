def geradicionarioprodutos(arquivoprodutos):

    arquivo = open(arquivoprodutos)
    content = arquivo.read()
    arquivo.close()

    content = content.split('\n')

    for i in range(len(content)):
        content[i] = content[i].split(';')

    dicionario = dict()

    for produto in content:
        dicionario[produto[0]] = [produto[1], produto[2]]

    return dicionario

def geralistavendas(arquivovendas):

    arquivo = open(arquivovendas)

    content = arquivo.read()

    arquivo.close()

    content = content.split('\n')

    for i in range(len(content)):
        content[i] = content[i].split(';')
    
    content.pop()

    return content



def gerarelatorios(arquivoprodutos, arquivovendas):
    
    listavendas = geralistavendas(arquivovendas)
    dicionarioprodutos = geradicionarioprodutos(arquivoprodutos)
                  
    
    quantidadevendida = dict()

    estoque = dict()

    necess = dict()
    
    for i in range(len(listavendas)):
        if listavendas[i][2] == '100' or listavendas[i][2] == '102' and listavendas[i][0] in dicionarioprodutos.keys():
            quantidadevendida[listavendas[i][0]] = 0
            estoque[listavendas[i][0]] = 0
            necess[listavendas[i][0]] = 0
            
    
    for venda in listavendas:
        if venda[2] == '100' or venda[2] == '102':
            if venda[0] in dicionarioprodutos.keys():
                quantidadevendida[venda[0]] += int(venda[1])

    for key in estoque.keys():
        estoque[key] = int(dicionarioprodutos[key][0]) - quantidadevendida[key]

    for key in necess.keys():
        necess[key] = int(dicionarioprodutos[key][1]) - estoque[key]

    
    print(necess)
