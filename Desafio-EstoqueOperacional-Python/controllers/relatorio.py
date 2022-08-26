def writeTransfere(vendasConfirmadas):
    with open('transfere.txt', 'w', encoding='utf-8') as f:
        colunas = ['Produto', 'QtCO', 'QtMin', 'QtVendas', 'Estq.após', 'Necess.', 'Transf. de']

        f.write("Necessidade de Transferência Armazém para CO\n\n")
        for coluna in colunas:
            f.write(coluna.ljust(12))

        f.write('\n')
        f.write(' ' * 48 + 'Vendas'.ljust(24))
        f.write('Arm p/ CO'.ljust(12))
        f.write('\n')

        for codigo in sorted(vendasConfirmadas.keys()):
            f.write(str(codigo).ljust(12))
            f.write(str(vendasConfirmadas[codigo]['qtCO']).ljust(12))
            f.write(str(vendasConfirmadas[codigo]['qtMin']).ljust(12))
            f.write(str(vendasConfirmadas[codigo]['qtVendas']).ljust(12))
            f.write(str(vendasConfirmadas[codigo]['estoqueApos']).ljust(12))
            f.write(str(vendasConfirmadas[codigo]['necessario']).ljust(12))
            f.write(str(vendasConfirmadas[codigo]['armazemParaCO']).ljust(12))
            f.write('\n')


def writeDivergencias(divergencias):
    with open('divergencias.txt', 'w', encoding='utf-8') as f:
        f.write('\n'.join(divergencias))


def writeTotCanais(vendasPorCanal):
    with open('totcanal.txt', 'w', encoding='utf-8') as f:
        f.write("Quantidades de Vendas por canal\n\n")

        f.write('Canal'.ljust(25))
        f.write('QtVendas')
        f.write('\n')

        f.write('1 - Representantes'.ljust(25) + str(vendasPorCanal[1]) + '\n')
        f.write('2 - Website'.ljust(25) + str(vendasPorCanal[2]) + '\n')
        f.write('3 - App móvel Android'.ljust(25) + str(vendasPorCanal[3]) + '\n')
        f.write('4 - App móvel iPhone'.ljust(25) + str(vendasPorCanal[4]))
