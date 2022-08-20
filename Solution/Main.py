# Algoritmo de separação, organização e armazenamento dos dados
productsRaw = list()  # Listas de organização
productsOrdered = list()

salesRaw = list()
salesOrdered = list()

productCode = list()  # Listas de armazenamento de dados
productQuantity = list()
productMinQuantity = list()

saleCode = list()
saleQuantity = list()
saleSituation = list()
saleChannel = list()

try:
    # Caso de Teste 1
    #with open("Caso de teste 1/c1_produtos.txt", "r") as products:  # Abrindo arquivo que le os produtos
       #for line in products:
            #productsRaw.append(line)  # Colocando todas as linhas lidas em uma lista

    #with open("Caso de teste 1/c1_vendas.txt", "r") as sales:
        #for line in sales:
            #salesRaw.append(line)

     #Caso de teste 2
    with open("Caso de teste 2/c2_produtos.txt", "r") as products:
        for line in products:
            productsRaw.append(line)

    with open("Caso de teste 2/c2_vendas.txt", "r") as sales:
        for line in sales:
            salesRaw.append(line)

    # Produtos
    for i in range(len(productsRaw)):  # Separando cada atributo diferente pelo ;
        productsOrdered.append(productsRaw[i].split(";"))

    for i in range(0, len(productsOrdered)):
        productCode.append(productsOrdered[i][0])
        productQuantity.append(productsOrdered[i][1])
        productMinQuantity.append(productsOrdered[i][2].strip("\n"))

    # Vendas
    for i in range(len(salesRaw)):
        salesOrdered.append(salesRaw[i].split(";"))

    for i in range(0, len(salesOrdered)):
        saleCode.append(salesOrdered[i][0])
        saleQuantity.append(salesOrdered[i][1])
        saleSituation.append(salesOrdered[i][2])
        saleChannel.append(salesOrdered[i][3].strip("\n"))
except IOError:
    print("Unable to read file.")

# Resolução do desafio

# Divergencias
divergences = ""
for i in range(len(salesOrdered)):
    if salesOrdered[i][2] == "135":
        divergences += f"Linha {i+1} - Venda cancelada\n"
    elif salesOrdered[i][2] == "190":
        divergences += f"Linha {i+1} - Venda não Finalizada\n"
    elif salesOrdered[i][2] == "999":
        divergences += f"Linha {i + 1} - Erro desconhecido. Acionar equipe de TI\n"
    elif salesOrdered[i][0] not in productCode:
        divergences += f"Linha {i + 1} - Código de Produto não encontrado {saleCode[i]}\n"

# Caso de teste 1
#with open("Caso de teste 1/c1_divergencias.txt", "w", encoding="UTF-8") as divergence:
    #divergence.write(divergences)
# Caso de teste 2
with open("Caso de teste 2/c2_divergencias.txt", "w", encoding="UTF-8") as divergence:
    divergence.write(divergences)

# Relatorios por canais

reports = ""
totalSalesChannel1 = 0
totalSalesChannel2 = 0
totalSalesChannel3 = 0
totalSalesChannel4 = 0
for i in range(len(saleSituation)):
    currentChannel = saleChannel[i]
    currentSituation = saleSituation[i]
    currentQuantity = int(saleQuantity[i])

    if currentChannel == "1" and (currentSituation == "100" or currentSituation == "102"):
        totalSalesChannel1 += currentQuantity
    if currentChannel == "2" and (currentSituation == "100" or currentSituation == "102"):
        totalSalesChannel2 += currentQuantity
    if currentChannel == "3" and (currentSituation == "100" or currentSituation == "102"):
        totalSalesChannel3 += currentQuantity
    if currentChannel == "4" and (currentSituation == "100" or currentSituation == "102"):
        totalSalesChannel4 += currentQuantity

reports += "Quantidades de Vendas por canal\n"
reports += "Canal                  QtVendas\n"
reports += f"1 - Representantes          {totalSalesChannel1}\n"
reports += f"2 - Website                 {totalSalesChannel2}\n"
reports += f"3 - App móvel Android       {totalSalesChannel3}\n"
reports += f"4 - App móvel Iphone        {totalSalesChannel4}"

# Caso de teste 1
#with open("Caso de teste 1/c1_totcanais.txt", "w", encoding="UTF-8") as report:
    #report.write(reports)
# Caso de teste 2
with open("Caso de teste 2/c2_totcanais.txt", "w", encoding="UTF-8") as report:
    report.write(reports)

# Transferencia para CO
productTotalSale = 0
necessary = 0
transferToCO = 0
storageAfterSale = 0
transfer = ""
transfer += "Necessidade de Transferência Armazém para CO\n\n"
transfer += "Produto  QtCO  QtMin  QtVendas  Estq.após  Necess.  Transf. de\n"
transfer += "                                   Vendas            Arm p/ CO\n"
for i in range(len(productCode)):
    for j in range(len(saleCode)):
        if saleCode[j] == productCode[i] and (saleSituation[j] == "100" or saleSituation[j] == "102"):
            productTotalSale += int(saleQuantity[j])
    storageAfterSale = int(productQuantity[i]) - productTotalSale
    necessary = int(productMinQuantity[i]) - storageAfterSale
    if necessary < 0:
        necessary = 0
    if 10 > necessary > 0:
        transferToCO = 10
    else:
        transferToCO = necessary
    transfer += f"{productCode[i]: <5}    {productQuantity[i]: <4}    {productMinQuantity[i]: <5}     {productTotalSale: <8}  {storageAfterSale: <6}     {necessary: <8}   {transferToCO}\n"
    productTotalSale = 0

# Caso de teste 1
#with open("Caso de teste 1/c1_transfere.txt", "w", encoding="UTF-8") as transfers:
    #transfers.write(transfer)
# Caso de teste 2
with open("Caso de teste 2/c2_transfere.txt", "w", encoding="UTF-8") as transfers:
    transfers.write(transfer)