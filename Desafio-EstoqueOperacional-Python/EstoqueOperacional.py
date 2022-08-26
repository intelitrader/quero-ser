import sys
import controllers.helper as helper
import controllers.relatorio as relatorio


def initRelatorios(vendasPath, produtosPath):
    vendas = helper.vendasToArray(vendasPath)
    produtos = helper.produtosToDict(produtosPath)

    vendasConfirmadas, divergencias = helper.gerarRelatorioDeVendas(produtos, vendas)
    vendasPorCanal = helper.qtdDeVendasPorCanal(vendas)

    relatorio.writeTransfere(vendasConfirmadas)
    relatorio.writeDivergencias(divergencias)
    relatorio.writeTotCanais(vendasPorCanal)


if __name__ == "__main__":
    # print(sys.argv)
    if len(sys.argv) != 3:
        print('\nModo de usar: python EstoqueOperacional.py <arquivo vendas> <arquivo produtos>')
        print('Exemplo 1: python EstoqueOperacional.py "..\\dados\\c1_vendas.txt" "..\\dados\\c1_produtos.txt"')
        print('Exemplo 2: python EstoqueOperacional.py "C:\\users\\intelitrader\\dados\\c1_vendas.txt" "C:\\users\\intelitrader\\dados\\c1_produtos.txt"\n')
        sys.exit()

    initRelatorios(sys.argv[1], sys.argv[2])
