def rel_produtos(arq):
    a = open(arq, "rt")
    tabela = dict()
    codigo = list()
    estoque = list()
    qt_min = list()

    for linha in a:
        dados = linha.split(";")
        dados[2] = dados[2].replace("\n", "")
        codigo.append(dados[0])
        estoque.append(dados[1])
        qt_min.append(dados[2])
    
    a.close()
    tabela["Código"] = codigo[:]
    tabela["Estoque"] = estoque[:]
    tabela["QtMinCO"] = qt_min[:]
    return tabela
    

def rel_vendas(arq):
    a = open(arq, "rt")
    tabela = dict()
    codigo = list()
    qtd_vendas = list()
    situacao = list()
    canal = list()

    for linha in a:
        dados = linha.split(";")
        dados[3] = dados[3].replace("\n", "")
        codigo.append(dados[0])
        qtd_vendas.append(dados[1])
        situacao.append(dados[2])
        canal.append(dados[3])
    
    a.close()
    tabela["Código"] = codigo[:]
    tabela["Qtd. Vendas"] = qtd_vendas[:]
    tabela["Situação"] = situacao[:]
    tabela["Canal"] = canal[:]
    return tabela


def divergencias(cod,ind,tab,i):
    if ind == str(135):
        msg = "Venda cancelada"
    elif ind == str(190):
        msg = "Venda nãoo finalizada"
    elif ind == str(999):
        msg = "Erro desconhecido. Acionar equipe de TI"
    elif cod not in tab:
        msg = f"Código de Produto nao encontrado {cod}"
    try:
        a = open("DIVERGENCIAS.txt", "at")
    except:
        a = open("DIVERGENCIAS.txt", "wt+")
    else:
        a.write(f"Linha {i+1} - {msg}\n")
    finally:
        a.close()


def confere_reposicao(est, qtmin):
    my_list = list()
    reposicao = int(qtmin) - int(est)

    if 1 <= reposicao <= 10:
        my_list.append(reposicao)
        my_list.append(10)
        return my_list

    else:
        my_list.append(reposicao)
        my_list.append(reposicao)
        return my_list


def rel_canais(lista):
    cabecalho = ["Canal", "QtVendas"]
    try:
        a = open("TOTCANAIS.txt", "at")
    except:
        a = open("TOTCANAIS.txt", "wt+")
    else:
        a.write(f"Quantidades de Vendas por canal\n")
        a.write("\n")

        # Escreve o cabeçalho
        for i, valor in enumerate(cabecalho):
            if i == 0:
                a.write(f"{valor:<30}")
            if i == 1:
                a.write(f"{valor:>10}")
        a.write("\n")

        # Escreve os dados
        canal = ["Representantes", "Website", "App movel Android", "App movel iPhone"]
        for i, valor in enumerate(lista):
            a.write(f"{i+1:<2} - {canal[i]:<25}")
            a.write(f"{valor:>10}\n")
    finally:
        a.close()


def tabela_total(arquivo_produtos, arquivo_vendas):
    tabela_produtos = rel_produtos(arquivo_produtos)
    tabela_vendas = rel_vendas(arquivo_vendas)
    my_dict = dict()
    my_dict["cod_produtos"] = tabela_produtos["Código"]
    my_dict["qt_co"] = tabela_produtos["Estoque"]
    my_dict["qt_min"] = tabela_produtos["QtMinCO"]
    my_dict["qt_ven"] = [x*0 for x in range(len(tabela_produtos["Código"]))]
    my_dict["est"] = [x*0 for x in range(len(tabela_produtos["Código"]))]
    my_dict["nec"] = [x*0 for x in range(len(tabela_produtos["Código"]))]
    my_dict["transf"] = [x*0 for x in range(len(tabela_produtos["Código"]))]
    lista_canais = [0,0,0,0]

    for i, valor in enumerate(tabela_vendas["Código"]):
        
        # Verifica se o código do produto existe e se a situação da compra está em 100 ou 102.
        if valor in my_dict["cod_produtos"] and tabela_vendas["Situação"][i] == str(100) or tabela_vendas["Situação"][i] == str(102):
            
            # Índice do Código do Produto dentro do dicionário.
            z = my_dict["cod_produtos"].index(valor)
            
            # Acumula (soma) valores
            vendas = int(tabela_vendas["Qtd. Vendas"][i]) + int(my_dict["qt_ven"][z])
            my_dict["qt_ven"][z] = vendas
            estoque = int(my_dict["qt_co"][z]) - int(my_dict["qt_ven"][z])
            my_dict["est"][z] = estoque

            # Relatório por Canais
            if int(tabela_vendas["Canal"][i]) == 1:
                canal = int(tabela_vendas["Qtd. Vendas"][i]) + int(lista_canais[0])
                lista_canais[0] = canal
            elif int(tabela_vendas["Canal"][i]) == 2:
                canal = int(tabela_vendas["Qtd. Vendas"][i]) + int(lista_canais[1])
                lista_canais[1] = canal
            elif int(tabela_vendas["Canal"][i]) == 3:
                canal = int(tabela_vendas["Qtd. Vendas"][i]) + int(lista_canais[2])
                lista_canais[2] = canal
            elif int(tabela_vendas["Canal"][i]) == 4:
                canal = int(tabela_vendas["Qtd. Vendas"][i]) + int(lista_canais[3])
                lista_canais[3] = canal

            # Faz a contagem da necessidade de reposição, quando Estoque < QtMin. [Cálculo: QtMin - Est]
            if int(my_dict["est"][z]) < int(my_dict["qt_min"][z]):
                qtd = confere_reposicao(my_dict["est"][z], my_dict["qt_min"][z])
                my_dict["nec"][z] = qtd[0] # Necess.
                my_dict["transf"][z] = qtd[1] # Transf.

            # Se o Estoque for maior que a QtMin, não há necessidade de reposição e transferência.
            else:
                my_dict["nec"][z] = 0 # Necess.
                my_dict["transf"][z] = 0 # Transf.
        
        # Caso não atenda a primeira verificação, cria o arquivo "divergencias"   
        else:
            divergencias(cod=valor,ind=tabela_vendas["Situação"][i],tab=tabela_produtos["Código"],i=i)

    rel_canais(lista_canais)

    return my_dict
    

def transfere(dict):
    cabecalho = ["Produto", "QtCO", "QtMin" ,"QtVendas", "Estq. após vendas", "Necess.", "Transf. de Arm p/ CO"]
    arr = list()
    c = 0

    # Preenche os dados do dicionário em uma lista
    while len(dict["cod_produtos"]) > c:
        dado = list()
        for valor in dict.values():
            dado.append(valor[c])
        "".join(str(dado))
        
        arr.append(dado[:])
        dado.clear()
        c += 1
    
    try:
        a = open("transfere.txt", "at")
    except:
        a = open("transfere.txt", "wt+")
    else:
        a.write(f"{'':<3}Necessidade de Transferência Armazém para CO\n")
        a.write("\n")

        # Escreve o cabeçalho
        for i, valor in enumerate(cabecalho):
            if i == 4 or i == 6:
                a.write(f"{valor:>21}")
            else:
                a.write(f"{valor:>10}")
        a.write("\n")

        # Escreve os dados
        for chave in arr:
            for i, valor in enumerate(chave):
                if i == 4 or i == 6:
                    a.write(f"{valor:>21}")
                else:
                    a.write(f"{valor:>10}")
            a.write("\n")
    finally:
        a.close()
    

arquivo_produtos = "c1_produtos.txt"
arquivo_vendas = "c1_vendas.txt"
transfere(tabela_total(arquivo_produtos, arquivo_vendas))
