def lerArquivo(nomeArquivo):
  resultado = list()
  with open(f"{nomeArquivo}.txt", "r", encoding="utf-8") as arquivo:
    for linha in arquivo.readlines():
      resultado.append(linha.replace("\n","").split(";"))
    return resultado
  
def criarArquivo(nomeArquivo):
  with open(f"{nomeArquivo}.TXT", "w", encoding="utf-8") as arquivo: arquivo.write("")

def verificarProdutoExiste(codigo, listaGeral):
  for i in listaGeral:
    if codigo[0] in listaGeral[i]:
      return True
  return False

def verificarVendaCancelada(codigo):
  return True if int(codigo[2]) == 135 else False

def verificarVendaNaoFinalizada(codigo):
  return True if int(codigo[2]) ==  190 else False

def verificarErroDesconhecido(codigo):
  return True if int(codigo[2]) ==  999 else False

try:
  PRODUTOS = lerArquivo("PRODUTOS")
  VENDAS = lerArquivo("VENDAS")

  RelatorioGeral = dict()
  for i in range(0, len(PRODUTOS)):
    RelatorioGeral[i] = PRODUTOS[i]
    RelatorioGeral[i].append(0)
    for j in range(0, len(VENDAS)):
      if RelatorioGeral[i][0] == VENDAS[j][0]:
        if not verificarErroDesconhecido(VENDAS[j])\
        and not verificarVendaCancelada(VENDAS[j])\
        and not verificarVendaNaoFinalizada(VENDAS[j]):
          RelatorioGeral[i][3] += int(VENDAS[j][1])

  # EXERCÍCIO 1
  transfere = "TRANSFERE"
  criarArquivo(transfere)
  with open(f"{transfere}.TXT", "a", encoding="utf-8") as arquivo:
    arquivo.write("Necessidade de Transferência Armazém para CO\n\n" +
                  "Produto".ljust(10) + 
                  "QtCO".ljust(8) +
                  "QtMin".ljust(9) +
                  "QtVendas".ljust(12) +
                  "EstqApósVendas".ljust(18) +
                  "Necess.".ljust(11) +
                  "Trasnf. de Arm p/ CO\n\n")
      
    for i in range(0, len(RelatorioGeral)):
      produto = RelatorioGeral[i][0]
      qtCo = RelatorioGeral[i][1]
      qtMin = RelatorioGeral[i][2]
      qtVendas = str(RelatorioGeral[i][3])
      estqAposVendas = int(qtCo) - int(qtVendas)
      necess = int(qtMin) - estqAposVendas
      if necess < 0:
        necess = 0
      
      arquivo.write(
        f"{produto.ljust(10)}"
        f"{qtCo.ljust(8)}"
        f"{qtMin.ljust(9)}"
        f"{qtVendas.ljust(12)}"
        f"{str(estqAposVendas).ljust(18)}"
        f"{str(necess).ljust(11)}"
        f"{str(10 if necess < 10 and necess > 0 else necess)}\n"
        )
    
  # EXERCÍCIO 2
  divergencias = "DIVERGENCIAS" 
  criarArquivo(divergencias)
  with open(f"{divergencias}.TXT", "a", encoding="utf-8") as arquivo:
    linha = 0
    for codigo in VENDAS:
      linha += 1
      if verificarErroDesconhecido(codigo):
        arquivo.write(f"Linha {linha} - Erro desconhecido. Acionar equipe de TI.\n")
      elif not verificarProdutoExiste(codigo, RelatorioGeral):
        arquivo.write(f"Linha {linha} - Código de Produto não encontrado {codigo[0]}\n")
      elif verificarVendaCancelada(codigo):
        arquivo.write(f"Linha {linha} - Venda cancelada\n")
      elif verificarVendaNaoFinalizada(codigo):
        arquivo.write(f"Linha {linha} - Venda não finalizada\n")
      

  # EXERCÍCIO 3 
  totcanais = "TOTCANAIS"
  criarArquivo(totcanais)
  with open(f"{totcanais}.TXT", "a", encoding="utf-8") as arquivo:
    arquivo.write("Quantidades de Vendas por canal\n\n" +
                  "Canal".ljust(30) + 
                  "QtVendas\n\n")
    
    representantes = website = appAndroid = appIphone = 0
    
    for i in range(0, len(VENDAS)):
      situacaoVenda = VENDAS[i][2]
      canalVenda = VENDAS[i][3]
      qtVendas = int(VENDAS[i][1])
      if (situacaoVenda == "100" or situacaoVenda == "102"):
        if   canalVenda == "1": representantes += qtVendas
        elif canalVenda == "2": website        += qtVendas
        elif canalVenda == "3": appAndroid     += qtVendas
        elif canalVenda == "4": appIphone      += qtVendas

    arquivo.write(f"1 - Representantes".ljust(30) + str(representantes) + "\n" +
                  f"2 - Website".ljust(30) + str(website) + "\n" +
                  f"3 - App Móvel Android".ljust(30) + str(appAndroid) + "\n" +
                  f"4 - App Móvel iPhone".ljust(30) + str(appIphone) + "\n"
                )
except: 
  print("Erro durante execução do programa, verifique se os arquivos\nPRODUTOS.txt e VENDAS.txt estão presentes na pasta e preenchidos corretamente")
  input("")