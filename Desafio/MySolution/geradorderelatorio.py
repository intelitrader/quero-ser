def geradicionarioprodutos(arquivoprodutos):
    'Gera o dicionario de produtos'
    #Abre o arquivo, lê o conteudo e fecha o arquivo
    arquivo = open(arquivoprodutos)
    content = arquivo.read()
    arquivo.close()
    #Faz uma lista com o conteudo do arquivo separado por linhas
    content = content.split('\n')
    #Faz uma matriz com cada componente da lista virando outra lista separando por ';'
    for i in range(len(content)):
        content[i] = content[i].split(';')
    
    dicionario = dict() #Inicializa o dicionario

    for produto in content: #Preenche o dicionario com o código de produto como chave e uma lista com os valores
        dicionario[produto[0]] = [produto[1], produto[2]]   

    return dicionario   #Retorna o dicionario

def geralistavendas(arquivovendas):
    'Gera a lista com o arquivo de vendas'
    
    arquivo = open(arquivovendas)   #Abre o arquivo

    content = arquivo.read() #Lê o conteudo do arquivo e guarda na variavel content

    arquivo.close() #Fecha o arquivo

    content = content.split('\n') #Faz uma lista com o conteudo separado por quebra de linha

    for i in range(len(content)): #Faz uma matriz com a lista com cada membro virando uma lista a cada ';'
        content[i] = content[i].split(';')
    
    content.pop() #Exclui o membro vazio do fim da lista

    return content  #Retorna a lista



def geratransferetxt(arquivoprodutos, arquivovendas):
    
    listavendas = geralistavendas(arquivovendas) #Lista do arquivo vendas
    dicionarioprodutos = geradicionarioprodutos(arquivoprodutos) #Dicionario do arquivo produtos
                  
    
    quantidadevendida = dict() #Inicializa dicionario para calcular a quantidade de vendas

    estoque = dict()    #inicializa dicionario para calcular quantidade de estoque

    necess = dict() #Inicializa dicionario para calcular a quantidade de reposição

    transferencia = dict() #Inicializa dicionario para quantidade minima no centro de operações
    
    for i in range(len(listavendas)):   #Preenche dicionarios para contagem
        if (listavendas[i][2] == '100' or listavendas[i][2] == '102') and listavendas[i][0] in dicionarioprodutos.keys():
            quantidadevendida[listavendas[i][0]] = 0
            estoque[listavendas[i][0]] = 0
            necess[listavendas[i][0]] = 0
            transferencia[listavendas[i][0]] = 0
            
    for venda in listavendas:   #Calcula quantidade vendida
        if venda[0] in quantidadevendida.keys() and (venda[2] == '100' or venda[2] == '102'):
            quantidadevendida[venda[0]] += int(venda[1])
     
    for vendido in quantidadevendida.keys():    #Calcula estoque após vendas
        estoque[vendido] = int(dicionarioprodutos[vendido][0]) - int(quantidadevendida[vendido])

    for stoque in estoque.keys(): #Calcula necessidade de reposição no centro operacional
        if estoque[stoque] < int(dicionarioprodutos[stoque][1]):
                necess[stoque] = int(dicionarioprodutos[stoque][1]) - (estoque[stoque])
    
    for necessidade in necess.keys(): #Calcula tranferencia do armazem para centro operacional
        if necess[necessidade] > 1:
            if necess[necessidade] < 10:
                transferencia[necessidade] = 10
            else:
                transferencia[necessidade] = necess[necessidade]
    
    listachaves = list(quantidadevendida) #Gera uma lista de chaves para usar o metodo sort
    listachaves.sort() #Deixa a lista de chaves em ordem
    listafinal = [] #Inicializa lista para guardar valores em ordem para escrever no arquivo

    for i in range(len(listachaves)): #Gera lista de resultados para escrever no arquivo
        listafinal.append([])
        listafinal[i].append(listachaves[i])
        listafinal[i].append(dicionarioprodutos[listachaves[i]][0])
        listafinal[i].append(dicionarioprodutos[listachaves[i]][1])
        listafinal[i].append(quantidadevendida[listachaves[i]])
        listafinal[i].append(estoque[listachaves[i]])
        listafinal[i].append(necess[listachaves[i]])
        listafinal[i].append(transferencia[listachaves[i]])
    
    stringfinal = '' #Inicializa a string para ser gravada no arquivo
    
    #Gera string para escrever no arquivo
    stringfinal += 'Necessidade de Transferência Armazém para CO \n\n'
    stringfinal += '{:>7}  {:>4}  {:>5}  {:>8}  {:>9}  {:>7}  {:>10}\n'.format('Produto', 'QtCO', 'QtMin', 'QtVendas', 'Estq.após', 'Necess.', 'Transf. de')
    stringfinal += '                                   Vendas            Arm p/ CO\n'
    for elemento in listafinal:
        stringfinal += '{:<7}  {:>4}  {:>5}  {:>8}  {:>9}  {:>7}  {:>10}\n'.format(elemento[0],elemento[1], elemento[2], elemento[3], elemento[4], elemento[5], elemento[6])
    

    #Gera o arquivo transfere.txt
    arquivo = open('transfere.txt', 'w')
    arquivo.write(stringfinal)
    arquivo.close()

