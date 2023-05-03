#Teste Técnico Intelitrader
class Produto:
    def __init__(self, idprod, qntest, min):
        self.idprod = idprod
        self.qntest = qntest
        self.min = min
totcanais = {}
estoque = []
vendasprod = {}
vendas = open(f"c{caso}_vendas.txt", "r+")
lstprod = []
pro = open(f'c{caso}_produtos.txt')
for produto in pro:
    infprod = produto.split(';')
    estoque.append(Produto(infprod[0], infprod[1], infprod[2]))
    idproduto = infprod[0]
    vendasprod.update({f'{idproduto}': 0})
c = 1

divergencias = open('divergencias.txt', 'w+')
for venda in vendas:
    informacoes = venda.split(';')
    informacoes[3] = informacoes[3].replace('\n', "")
    if informacoes[2] == '100' or informacoes[2] == '102':
        if not totcanais.keys().__contains__(informacoes[3]):
            totcanais.update(({f'{informacoes[3]}': 0}))
        if totcanais.keys().__contains__(informacoes[3]):
            valor = totcanais.get(informacoes[3])
            totcanais.update({f"{informacoes[3]}": valor + int(informacoes[1])})
        if vendasprod.keys().__contains__(informacoes[0]):
            valor = vendasprod.get(informacoes[0])
            vendasprod.update({f"{informacoes[0]}": valor + int(informacoes[1])})
    if informacoes[2] == '999':
        divergencias.writelines(f"""Linha {c} – Erro desconhecido. Acionar equipe de TI\n""")
    elif informacoes[2] == '190':
        divergencias.writelines(f"""Linha {c} – Venda não finalizada\n""")
    elif not vendasprod.keys().__contains__(informacoes[0]):
        divergencias.writelines(f"""Linha {c} – Código de Produto não encontrado {informacoes[0]}\n""")
    elif informacoes[2] == '135':
        divergencias.writelines(f"""Linha {c} – Venda cancelada\n""")
    c += 1

transfere = open('transfere.txt', 'w+')
transfere.writelines("""Necessidade de Transferencia Armazem para CO Produto  QtCO  QtMin  QtVendas  Estq.após  Necess.  Transf. de Vendas Arm p/ CO\n""")
for chave, valor in vendasprod.items():
    qtco = int(next(produto.qntest for produto in estoque if produto.idprod == chave))
    qtmin = int(next(produto.min for produto in estoque if produto.idprod == chave))
    restante = qtco - int(valor)
    necessario = 0 if restante > qtmin else qtmin - restante
    nec_trans = 10 if 0 < necessario < 10 else necessario
    str(transfere.writelines(f"""{chave:}    {qtco:<4}  {qtmin:<4}    {valor:<4}     {restante:<4}       {necessario:<4}     {nec_trans}\n"""))
totcanaistext = open('totcanal.txt', 'w+')
totcanaistext.writelines(f"Quantidades de Vendas por canal\n" f"\n" f"Canal QtVendas\n" f"1 - Representantes {list(totcanais.values())[0]}\n" f"2 - Website {list(totcanais.values())[2]}\n" f"3 - App móvel Android {list(totcanais.values())[1]}\n" f"4 - App móvel iPhone         {list(totcanais.values())[3]}")