import pandas as pd

# Lendo os dados de estoque
df_produtos = pd.read_csv('produtos_novo.txt')

# Lendo os dados de vendas
df_vendas = pd.read_csv('vendas_novo.txt')

listaProdutos = []
naoConsta = []

#Coletando produtos cadastrados no depósito...
for row in df_produtos['Produto']:
    listaProdutos.append(row)

#Verificando a existência do código do produto
#Listando produtos não encontrados
for i in range(len(df_vendas['Produto'])):
    if df_vendas['Produto'][i] not in listaProdutos:
        naoConsta.append(f"Linha {i} – Código de Produto não encontrado {df_vendas['Produto'][i]}")

print(naoConsta)

listaSituacao = []
listaDetalhes = []

for row in df_vendas['Situacao']:
    listaSituacao.append(row)

for i in range(len(df_vendas['Situacao'])):
    if listaSituacao[i] == 135:
        listaDetalhes.append(f"Linha {i} – Venda cancelada")
    elif listaSituacao[i] == 190:
        listaDetalhes.append(f"Linha {i} – Venda  Venda não finalizada")
    elif listaSituacao[i] == 999:
        listaDetalhes.append(f"Linha {i} – Erro desconhecido. Acionar equipe de TI")

print(listaDetalhes)

with open("divergencias.txt", 'w') as f:
    for i in naoConsta:
        f.write(i)
        f.write("\n")
    for i in listaDetalhes:
        f.write(i)
        f.write("\n")




























