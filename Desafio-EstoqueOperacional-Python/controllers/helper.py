import sys


def vendasToArray(path):
    vendas = []
    try:
        with open(path, 'r') as vendas_file:
            for line in vendas_file:
                codigo, qtVendas, situacaoDaVenda, canalDeVenda = line.strip().split(';')
                vendas.append({
                    'codigo': int(codigo),
                    'qtVendas': int(qtVendas),
                    'situacaoDaVenda': int(situacaoDaVenda),
                    'canalDeVenda': int(canalDeVenda)
                })

        # print(*vendas, sep="\n")
        # print()
        return vendas

    except FileNotFoundError:
        sys.exit(f'Arquivo vendas não encontrado. {path}')


def produtosToDict(path):
    produtos = {}
    try:
        with open(path, 'r') as produtos_file:
            for line in produtos_file:
                codigo, qtCO, qtMin = line.strip().split(';')
                produtos[int(codigo)] = {'qtCO': int(qtCO), 'qtMin': int(qtMin)}

        # print(produtos, sep="\n")
        # print()
        return produtos

    except FileNotFoundError:
        sys.exit(f'Arquivo produtos não encontrado. {path}')


def gerarRelatorioDeVendas(produtos, vendas):
    vendasConfirmadas = {}
    divergencias = []
    for i in range(len(vendas)):
        codigo = vendas[i]["codigo"]
        situacao = vendas[i]["situacaoDaVenda"]
        if situacao in [135, 190, 999]:
            divergencias.append(escreverDivergencia(situacao, codigo, i))
            continue

        if codigo in produtos:
            if codigo not in vendasConfirmadas:
                qtVendas = qtdVendasPorCodigo(codigo, vendas)
                estoqueApos = produtos[codigo]['qtCO'] - qtVendas
                necessario = 0 if estoqueApos >= produtos[codigo]['qtMin'] else produtos[codigo]['qtMin'] - estoqueApos
                armazemParaCO = 10 if 1 <= necessario <= 9 else necessario
                vendasConfirmadas[codigo] = {
                    'qtCO': produtos[codigo]['qtCO'],
                    'qtMin': produtos[codigo]['qtMin'],
                    'qtVendas': qtVendas,
                    'estoqueApos': estoqueApos,
                    'necessario': necessario,
                    'armazemParaCO': armazemParaCO
                }
        else:
            divergencias.append(escreverDivergencia(0, codigo, i))

    # print(vendasConfirmadas)
    # print(*divergencias, sep="\n")
    return [vendasConfirmadas, divergencias]


def qtdDeVendasPorCanal(vendas):
    vendasPorCanal = {1: 0, 2: 0, 3: 0, 4: 0}
    for venda in vendas:
        if venda['situacaoDaVenda'] in [100, 102]:
            canalDaVenda = venda['canalDeVenda']
            vendasPorCanal[canalDaVenda] += venda['qtVendas']

    # print(vendasPorCanal)
    return vendasPorCanal


def qtdVendasPorCodigo(codigo, vendas):
    qtdTotal = 0
    for venda in vendas:
        if venda['codigo'] == codigo and venda['situacaoDaVenda'] in [100, 102]:
            qtdTotal += venda['qtVendas']

    return qtdTotal


def escreverDivergencia(situacao, codigo, indiceVenda):
    if situacao == 0:
        return 'Linha {} - Código de produto não encontrado {}'.format(indiceVenda + 1, codigo)
    elif situacao == 135:
        return 'Linha {} - Venda cancelada'.format(indiceVenda + 1)
    elif situacao == 190:
        return 'Linha {} - Venda não finalizada'.format(indiceVenda + 1)
    elif situacao == 999:
        return 'Linha {} - Erro desconhecido. Acionar equipe de TI'.format(indiceVenda + 1)
