import pandas as pd

#Tabela de vendas, selecionando colunas utilizadas
sales_table = pd.read_csv("vendas_novo.txt", usecols=['QtVendas', 'Canal','Situacao'])

#Localizando onde os casos são 100 ou 102
new_sales_table_1 = sales_table.loc[(sales_table["Situacao"] == 100)]
new_sales_table_2 = sales_table.loc[(sales_table["Situacao"] == 102)]

#Criando lista com tabelas
tables = [new_sales_table_1, new_sales_table_2]

#Concatenando lista de tabelas
sales_concat = pd.concat(tables)

#Deletando Coluna não utilizada
del sales_concat['Situacao']

#Agrupando quantidade de vendas por canal
sales_concat = sales_concat.groupby('Canal').sum().reset_index()

stringCanais = []

#Substituindo valores dos canais pelas Strings correspondentes....
for i in range(len(sales_concat['Canal'])):
    if sales_concat['Canal'][i] == 1:
        stringCanais.append("1 - Representantes")
    elif sales_concat['Canal'][i] == 2:
        stringCanais.append("2 - Website")
    elif sales_concat['Canal'][i] == 3:
        stringCanais.append("3 - App móvel Android")
    elif sales_concat['Canal'][i] == 4:
        stringCanais.append("4 - App móvel iPhone")

sales_concat['Canal'] = stringCanais

with open("totcacanal.txt", 'w') as f:
    formatacaoString = sales_concat.to_string(header=True, index=False, justify="start")
    f.write(formatacaoString)































