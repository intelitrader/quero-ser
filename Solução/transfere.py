import csv
import pandas as pd

#Dados do Estoque....
#Adicionando o cabeçalho

first_header = ['Produto', 'QtdCO', 'Qtmin']

#Abrindo o arquivo de produtos
with open('produtos.txt', 'r') as csv_file:
    csv_reader = csv.reader(csv_file, delimiter=";")

#Criando um novo arquivo de produtos ()
    with open('produtos_novo.txt', 'w') as new_file:
        csv_writer = csv.writer(new_file)

        csv_writer.writerow(first_header)

        for line in csv_reader:
            csv_writer.writerow(line)


#Dados das Vendas....
#Adicionando o cabeçalho
second_header = ['Produto', 'QtVendas', 'Situacao', 'Canal']

#Abrindo o arquivo de vendas
with open('vendas.txt', 'r') as csv_file:
    csv_reader = csv.reader(csv_file, delimiter=";")

#Criando um novo arquivo para vendas
    with open('vendas_novo.txt', 'w') as new_file:
        csv_writer = csv.writer(new_file)

        csv_writer.writerow(second_header)

        for line in csv_reader:
            csv_writer.writerow(line)


#MESCLANDO TABELAS COM PANDAS
#TABELA DE VENDAS, EXTRAINDO COLUNAS PARA O ARQUIVO FINAL
sales_table = pd.read_csv("vendas_novo.txt", usecols=['Produto', 'QtVendas','Situacao'])

#Localizando onde os casos são 100 ou 102
new_sales_table_1 = sales_table.loc[(sales_table["Situacao"] == 100)]
new_sales_table_2 = sales_table.loc[(sales_table["Situacao"] == 102)]

#Criando lista com tabelas
sales_table = [new_sales_table_1,new_sales_table_2]

#Concatenando lista de tabelas
sales_concat = pd.concat(sales_table)

#AGRUPANDO (CODIGOS DE PRODUTOS DUPLICADOS), SOMANDO TOTAL DE VENDAS
sales_values = sales_concat.groupby(['Produto']).sum()

#TABELA DE PRODUTOS
products_table = pd.read_csv("produtos_novo.txt")

#ARQUIVO FINAL MESCLANDO DADOS TRATADOS DA TABELA DE VENDAS COM A TABELA DE PRODTUOS(ESTOQUE)
transfer_table = pd.merge(products_table, sales_values, on="Produto")

#Calculando estoque após vendas (subtração de colunas)
transfer_table["Estq.após vendas"] = transfer_table['QtdCO'] - transfer_table['QtVendas']

#Necessidade de reposição do estoque
transfer_table["Necess."] = transfer_table['Qtmin'] - transfer_table['Estq.após vendas']

necessidadeReal = transfer_table["Necess."]

pedidosReposição = [0] * len(necessidadeReal)

#Condição final do exercicios pedidos maiores que um e menores que 10
#Pedido mínimo de 10 unidades
for i in range(len(necessidadeReal)):
    if necessidadeReal[i] in range(1, 11):
        pedidosReposição[i] = 10
    else:
        pedidosReposição[i] = necessidadeReal[i]

#Ajuste da última coluna para a tabela final
transfer_table['Transf. de Arm p/CO'] = pedidosReposição

#Salvando arquivo final com a formatação solicitada
with open("transfere.txt", 'w') as f:
    formatacaoString = transfer_table.to_string(header=True, index=False)
    f.write(formatacaoString)

















































