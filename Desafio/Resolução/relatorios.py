produtos = open("produtos.txt", "r")
vendas = open("vendas.txt", "r")

# Ler linhas de produtos e criar um dicionário com os dados
produtos_dict = {}
for linha in produtos:
    codigo, qt_co, qt_min = linha.strip().split(";")
    produtos_dict[codigo] = {"qt_co": int(qt_co), "qt_min": int(qt_min)}

# Inicializar variáveis para contabilizar as vendas confirmadas
vendas_dict = {}
total_vendido = 0

# Ler linhas de vendas e contabilizar vendas confirmadas
for linha in vendas:
    codigo, qt_vendida, situacao, canal = linha.strip().split(";")
    if situacao == "100" or situacao == "102":
        total_vendido += int(qt_vendida)
        if codigo in vendas_dict:
            vendas_dict[codigo] += int(qt_vendida)
        else:
            vendas_dict[codigo] = int(qt_vendida)
    print(vendas_dict)
    print(produtos_dict)
# Fechar arquivos de entrada
produtos.close()
vendas.close()

# Calcular quantidades necessárias e transferências
saida = open("transfere.txt", "w")
saida.write("Produto\tQtCO\tQtMin\tQtVendas\tEstq.após\tNecess.\tTransf. de\n")
for codigo in produtos_dict:
    qt_co = produtos_dict[codigo]["qt_co"]
    qt_min = produtos_dict[codigo]["qt_min"]
    if codigo in vendas_dict:
        qt_vendida = vendas_dict[codigo]
    else:
        qt_vendida = 0
    estq_apos_vendas = qt_co - qt_vendida
    if estq_apos_vendas < qt_min:
        necessidade = qt_min - estq_apos_vendas
        if necessidade < 10:
            transf = 10
        else:
            transf = necessidade
    else:
        necessidade = 0
        transf = 0
    saida.write(
        "{}\t{}\t{}\t{}\t{}\t{}\t{}\n".format(
            codigo,
            qt_co,
            qt_min,
            qt_vendida,
            estq_apos_vendas,
            necessidade,
            transf,
        )
    )
    print(saida)
saida.close()

# Verificar divergências
divergencias = open("DIVERGENCIAS.TXT", "w")
for linha_num, linha in enumerate(vendas, start=1):
    codigo, qt_vendida, situacao, canal = linha.strip().split(";")
    if codigo not in produtos_dict:
        divergencias.write(
            "Linha {} - Código de Produto não encontrado {}\n".format(
                linha_num, codigo
            )
        )
        print(divergencias)
divergencias.close()
