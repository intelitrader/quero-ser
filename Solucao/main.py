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
estoque = []
idprod = []
vendas = open("c1_vendas.txt", "r")
vendaslst = []
pro = open('c1_produtos.txt')
vp1 = vp2 = vp3 = vp4 = vp5 = 0
# p1 = vendas produto 1 (16320)
# p2 = vendas produto 2 (23400)
# p3 = vendas produto 3 (26440)
# p4 = vendas produto 4 (28790)
# p5 = vemdas produto 5 (36540)
for produto in pro:
    estoque.append((produto.split(';')))
    idprod.append(produto.split(';')[0])
    for linha in vendas:
        v = linha.split(';')
        if v[2] == '100' or v[2] == '102':  # se as vendas forem confirmadas
            # if v[0] == idprod[int(produto)]:
            #     vendalst = int(vendaslst[int(produto)]) + int(v[1])
            #     vendaslst.append(vendalst)
            if v[0] == idprod[0]:  # se as vendas confirmadas tivere o codigo do p1
                vp1 += int(v[1])
            elif v[0] == idprod[1]:  # se as vendas confirmadas tivere o codigo do p2
                vp2 += int(v[1])
            elif v[0] == idprod[2]:  # se as vendas confirmadas tivere o codigo do p3
                vp3 += int(v[1])
            elif v[0] == idprod[3]:  # se as vendas confirmadas tivere o codigo do p4
                vp4 += int(v[1])
            elif v[0] == idprod[4]:  # se as vendas confirmadas tivere o codigo do p5
                vp5 += int(v[1])
print(vendaslst)
print(f"""
Produto  QtCO    QtMin  QtVendas   Estq.após    Necess.     Transf. de
					                Vendas		                Arm p/ CO
{idprod[0]}     {estoque[0][1]}	 {int(estoque[0][2])}   {vp1}	        {int(estoque[0][1]) -vp1 }          {0 if (int(estoque[0][1]) -vp1) > int(estoque[0][2]) else int(estoque[0][2]) - (int(estoque[0][1]) -vp1)}	        0
{idprod[1]}     {estoque[1][1]}	 {int(estoque[1][2])}   {vp2}	        {int(estoque[1][1]) -vp2 }          {0 if (int(estoque[1][1]) -vp2) > int(estoque[1][2]) else int(estoque[1][2]) - (int(estoque[1][1]) -vp2)}	        10
{idprod[2]}     {estoque[2][1]}	 {int(estoque[2][2])}   {vp3}	        {int(estoque[2][1]) -vp3 }         {0 if (int(estoque[2][1]) -vp3) > int(estoque[2][2]) else int(estoque[2][2]) - (int(estoque[2][1]) -vp3)}	        0
{idprod[3]}     {estoque[3][1]}	 {int(estoque[3][2])}   {vp4}	        {int(estoque[3][1]) -vp4 }           {0 if (int(estoque[3][1]) -vp4) > int(estoque[3][2]) else int(estoque[3][2]) - (int(estoque[3][1]) -vp4)}	        85
{idprod[4]}     {estoque[4][1]}	 {int(estoque[4][2])}   {vp5}          {int(estoque[4][1]) -vp5 }         {0 if (int(estoque[4][1]) -vp5) > int(estoque[4][2]) else int(estoque[4][2]) - (int(estoque[4][1]) -vp5)}        286""")
