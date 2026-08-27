produtos = {}
with open('c1_produtos.txt', 'r') as f:
    for line in f:
        codigo, qtde, estoque = line.strip().split(';')
        produtos[codigo] = {'qtde': int(qtde), 'estoque': int(estoque)}

vendas = {}
with open('c1_vendas.txt', 'r') as f:
    divergencias = []
    for i, line in enumerate(f, start=1):
        codigo, qtde, situacao, canal = line.strip().split(';')
        if codigo not in produtos:
            msg = f'Linha {i} - Codigo de Produto nao encontrado {codigo}'
            divergencias.append(msg)
        elif situacao == '135':
            msg = f'Linha {i} - Venda cancelada'
            divergencias.append(msg)
        elif situacao == '190':
            msg = f'Linha {i} - Venda nao finalizada'
            divergencias.append(msg)
        elif situacao == '999':
            msg = f'Linha {i} - Erro desconhecido. Acionar equipe de TI'
            divergencias.append(msg)
        else:
            qtde = int(qtde)
            if codigo in vendas:
                vendas[codigo] += qtde
            else:
                vendas[codigo] = qtde

estoque = []
for codigo, produto in produtos.items():
    qtVendas = vendas.get(codigo, 0)
    estqApos = produto['qtde'] - qtVendas
    qtMin = produto['estoque']
    necessidade = max(0, qtMin - estqApos)
    estqAposVendas = max(0, estqApos)
    necessidadeTransferencia = max(0, qtMin - estqAposVendas)
    transfArmCo = min(necessidadeTransferencia, estqApos // 2)
    if necessidadeTransferencia > 0:
        if necessidadeTransferencia < 10:
            transfArmCo = 10
        else:
            transfArmCo = transfArmCo

    estoque.append(f"{codigo.ljust(10)}{str(estqApos).ljust(8)}{str(qtMin).ljust(10)}{str(qtVendas).ljust(12)}{str(estqAposVendas).ljust(15)}{str(necessidadeTransferencia).ljust(15)}{str(transfArmCo).ljust(8)}")
header = 'Produto  QtCO     QtMin    QtVendas Estq.após     Necess.    Transf. de Arm p/ CO'
linhaSeparadora = '-'*len(header)

with open('c1_transfere.txt', 'w') as f:
    f.write(f"{header}\n{linhaSeparadora}\n")
    f.write('\n'.join(estoque))

with open('c1_divergencias.txt', 'w') as f:
    f.write('\n'.join(divergencias))

totais_vendas_canais = []
total = sum(vendas.values())
for canal, qtde in vendas.items():
    percentual = round(qtde / total * 100, 2)
    totais_vendas_canais.append(f"{canal.ljust(10)}{str(qtde).ljust(8)}{str(percentual).ljust(12)}%")

header = 'Canal QtdeVendida % sobre total'
linhaSeparadora = '-'*len(header)

with open('c1_totcanal.txt', 'w') as f:
    f.write(f"{header}\n{linhaSeparadora}\n")
    f.write('\n'.join(totais_vendas_canais))
