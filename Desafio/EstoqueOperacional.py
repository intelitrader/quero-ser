class Produto:
    def __init__(self, codigo, quantidade_inicial, quantidade_minima):
        self.codigo = codigo
        self.quantidade_inicial = quantidade_inicial
        self.quantidade_minima = quantidade_minima
    

class Venda:
    def __init__(self, codigo_produto, quantidade_vendida, situacao_venda, canal_venda):
        self.codigo_produto = codigo_produto
        self.quantidade_vendida = quantidade_vendida
        self.situacao_venda = situacao_venda
        self.canal_venda = canal_venda


def importar_produto(caminho_arquivo):
    arquivo = open(caminho_arquivo, "r", encoding="UTF-8")
    lista_produtos = []
    for linha in arquivo:  
        array = linha.split(';')

        codigo = int(array[0])
        quantidade_inicial =int(array[1])
        quantidade_minima = int(array[2])

        lista_produtos.append(Produto(codigo, quantidade_inicial, quantidade_minima))
    arquivo.close()
    return lista_produtos


def importar_vendas(caminho_arquivo):
    arquivo = open(caminho_arquivo, "r", encoding="UTF-8")
    lista_vendas = []
    for linha in arquivo:  
        array = linha.split(';')

        codigo_produto = int(array[0])
        quantidade_vendida =int(array[1])
        situacao_venda = int(array[2])
        canal_venda = int(array[3])

        venda = Venda(codigo_produto, quantidade_vendida, situacao_venda,canal_venda)
  
        if situacao_venda == 100 or situacao_venda == 102:  
            if len(lista_vendas) > 0:
                teste, index = esta_na_lista(venda, lista_vendas)
                if teste == True:
                    venda.quantidade_vendida = venda.quantidade_vendida  + lista_vendas[index].quantidade_vendida
                    lista_vendas[index] = venda
                    continue

            lista_vendas.append(venda)

    arquivo.close()
    return lista_vendas


def esta_na_lista(venda, lista):
    encontrado = False
    index = 0
    while index <= len(lista) -1:
        if lista[index].codigo_produto == venda.codigo_produto:
            encontrado = True
            break
        index += 1
    return (encontrado, index)

# Gerar arquivo transfere.txt

salvar_arquivo = open("transfere.txt", "w", encoding="UTF-8") 
salvar_arquivo.write("Necessidade de Transferência Armazém para CO\n\n")
salvar_arquivo.write("Produto  QtCO  QtMin  QtVendas  Estq.após  Necess.  Transf. de\n")
salvar_arquivo.write("                                   Vendas            Arm p/ CO\n")

lista_vendas = importar_vendas("Caso de teste 1/c1_vendas.txt")
lista_produtos = importar_produto("Caso de teste 1/c1_produtos.txt")
for venda in sorted(lista_vendas, key= lambda venda: venda.codigo_produto):
    for produto in lista_produtos:
        if(produto.codigo == venda.codigo_produto ):     
            CodProduto  = venda.codigo_produto
            QtCO = produto.quantidade_inicial
            QtMin  = produto.quantidade_minima
            QtVendas  = venda.quantidade_vendida
            EstqApos  =  QtCO - QtVendas
            Necess = EstqApos - QtMin
            Transf = 0
            if Necess > 0:
                Necess = 0
            else:
                Necess = -1 * Necess

            Transf = 0
            if 10 > Necess > 0:
                Transf = 10
            else:
                Transf = Necess
            salvar_arquivo.write(f"{str(CodProduto): <5}{str(QtCO): >8}{str(QtMin): >7}{str(QtVendas): >10}{str(EstqApos): >11}{str(Necess):>8}{str(Transf):>13}\n")
salvar_arquivo.close()

# Gerar arquivo divergencias.txt

salvar_arquivo = open("divergencias.txt", "w", encoding="UTF-8") 
ler_arquivo = open("Caso de teste 1/c1_vendas.txt", "r", encoding="UTF-8")

cont_linha = 1
for venda in ler_arquivo:  
    array = venda.split(';')
    situacao_venda = int(array[2])
    if  situacao_venda != 100 and situacao_venda != 102:
        if situacao_venda == 135:
            salvar_arquivo.write(f"Linha {cont_linha} - Venda cancelada\n")
        if situacao_venda == 190:
            salvar_arquivo.write(f"Linha {cont_linha} - Venda não finalizada\n")
        if situacao_venda == 999:
            salvar_arquivo.write(f"Linha {cont_linha} - Erro desconhecido. Acionar equipe de TI\n")
    else:
        lst_produtos = []
        for prod in lista_produtos:
            lst_produtos.append(prod.codigo)

        codigo_produto = int(array[0]) 
        if codigo_produto not in lst_produtos:
            salvar_arquivo.write(f"Linha {cont_linha} - Código de Produto não encontrado {codigo_produto}\n")

    cont_linha += 1

ler_arquivo.close()
salvar_arquivo.close()


# Gerar arquivo totcanal.txt

representgante = 0
website = 0
aplicativoAndroid = 0
aplicativoIphone = 0

ler_arquivo = open("Caso de teste 1/c1_vendas.txt", "r", encoding="UTF-8")
for linha in ler_arquivo:  
    array = linha.split(';')

    quantidade_vendida =int(array[1])
    situacao_venda = int(array[2])
    canal_venda = int(array[3])

    if situacao_venda == 100 or situacao_venda == 102:

        if canal_venda == 1:
            representgante = representgante + quantidade_vendida
        if canal_venda == 2:
            website = website + quantidade_vendida
        if canal_venda == 3:
            aplicativoAndroid = aplicativoAndroid + quantidade_vendida
        if canal_venda == 4:
            aplicativoIphone = aplicativoIphone + quantidade_vendida

ler_arquivo.close()
salvar_arquivo = open("totcanal.txt", "w", encoding="UTF-8")
salvar_arquivo.write("Quantidades de Vendas por canal\n\n")
salvar_arquivo.write("Canal                  QtVendas\n")
salvar_arquivo.write(f"1 - Representantes{representgante: >13}\n")
salvar_arquivo.write(f"2 - Website{website: >20}\n")
salvar_arquivo.write(f"3 - App móvel Android{aplicativoAndroid: >10}\n")
salvar_arquivo.write(f"4 - App móvel iPhone{aplicativoIphone: >11}\n")
salvar_arquivo.close()
