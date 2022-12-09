# Canal de vendas: comerciais, website e aplicativo móvel.

# endereços: um Centro Operacional (CO) centralizado, mais próximo do consumidor e de tamanho menor
# por estar em local de aluguel mais caro. Possui também um Armazém de grande tamanho,
# menos centralizado e com custo de aluguel bem mais barato por m2
# A primeira tarefa é processar este arquivo e levantar a eventual necessidade de estoque para atender as entregas.
# Como o Centro Operacional não tem grande espaço o estoque mantido ali é limitado.
# Assim, com base nas vendas do período e no estoque pré-existente o programa deve calcular, para cada produto,
# a quantidade de itens que devem ser enviados do Armazém para o Centro Operacional.
"""print((open("c1_produtos.txt")).read())
 print((open("c1_vendas.txt")).read())"""
class Produto:
    def __init__(self, idprod, qntest, min):
        self.idprod = idprod
        self.qntest = qntest
        self.min = min

estoque = []
vendasprod = {}
vendas = open("c1_vendas.txt", "r")
lstprod = []
pro = open('c1_produtos.txt')
vp1 = vp2 = vp3 = vp4 = vp5 = 0
# p1 = vendas produto 1 (16320)
# p2 = vendas produto 2 (23400)
# p3 = vendas produto 3 (26440)
# p4 = vendas produto 4 (28790)
# p5 = vemdas produto 5 (36540)
for produto in pro:
    infprod = produto.split(';')
    estoque.append(Produto(infprod[0], infprod[1], infprod[2]))
    idproduto = infprod[0]
    vendasprod.update({f'{idproduto}' : 0})
for venda in vendas:
    informacoes = venda.split(';')
    if informacoes[2] == '100' or informacoes[2] == '102':  # se as vendas forem confirmadas
        if  vendasprod.keys().__contains__(informacoes[0]) == True:
            valor = vendasprod.get(informacoes[0])
            vendasprod.update({f"{informacoes[0]}": valor + int(informacoes[1])})



print("""Produto  QtCO    QtMin  QtVendas   Estq.após    Necess.     Transf. de
 					                         Vendas		              Arm p/ CO""")
for chave, valor in vendasprod.items():
    print(next(produto.qntest for produto in estoque if produto.idprod == chave))





# n1 = 0 if (int(estoque[0][1]) -vp1) > int(estoque[0][2]) else int(estoque[0][2]) - (int(estoque[0][1]) -vp1)
# n2 = 0 if (int(estoque[1][1]) -vp2) > int(estoque[1][2]) else int(estoque[1][2]) - (int(estoque[1][1]) -vp2)
# n3 = 0 if (int(estoque[2][1]) -vp2) > int(estoque[2][2]) else int(estoque[2][2]) - (int(estoque[2][1]) -vp3)
# n4 = 0 if (int(estoque[3][1]) -vp2) > int(estoque[3][2]) else int(estoque[3][2]) - (int(estoque[3][1]) -vp4)
# n5 = 0 if (int(estoque[4][1]) -vp2) > int(estoque[4][2]) else int(estoque[4][2]) - (int(estoque[4][1]) -vp5)
# print(f"""
# Produto  QtCO    QtMin  QtVendas   Estq.após    Necess.     Transf. de
# 					                Vendas		                Arm p/ CO
# {vendasprod[0]}     {estoque[0][1]}	 {int(estoque[0][2])}   {vp1}	        {int(estoque[0][1]) - vp1 }          {n1}                {10 if 0 < n1 < 10 else n1}
# {vendasprod[1]}     {estoque[1][1]}	 {int(estoque[1][2])}   {vp2}	        {int(estoque[1][1]) - vp2 }          {n2}                {10 if (0 < n2 < 10) else n2}
# {vendasprod[2]}     {estoque[2][1]}	 {int(estoque[2][2])}   {vp3}	        {int(estoque[2][1]) - vp3 }         {n3}                {10 if 0 < n3 < 10 else n3}
# {vendasprod[3]}     {estoque[3][1]}	 {int(estoque[3][2])}   {vp4}	        {int(estoque[3][1]) - vp4 }           {n4}               {10 if 0 < n4 < 10 else n4}
# {vendasprod[4]}     {estoque[4][1]}	 {int(estoque[4][2])}   {vp5}          {int(estoque[4][1]) - vp5 }         {n5}              {10 if 0 < n5 < 10 else n5}""")
