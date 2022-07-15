while True:
  cedulaValor = 100
  cedulasUsadas = 0
  while True:
    try:
      print("-----------* Nihilbank *-----------")
      valorSaque = int(input("Quanto deseja sacar? R$"))
      break
    except:
      print("Erro de tipagem. Informe um numero inteiro para continuar :/")
      continue
  if valorSaque % 10 == 0:
    valorSaqueTotal = valorSaque
    while True:
      if valorSaqueTotal >= cedulaValor:
        valorSaqueTotal -= cedulaValor
        cedulasUsadas += 1
      else:
        if cedulasUsadas != 0:
          if cedulasUsadas > 1:
            print(f"Foram usadas {cedulasUsadas} cédulas de R${cedulaValor}")
          else:
            print(f"Foi usada {cedulasUsadas} cédula de R${cedulaValor}")
        if cedulaValor == 100:
          cedulaValor = 50
        elif cedulaValor == 50:
          cedulaValor = 20
        elif cedulaValor == 20:
          cedulaValor = 10
        cedulasUsadas = 0
        if valorSaqueTotal == 0:
          break
  else:
    print("Infelizmente não podemos sacar essa quantia com as cédulas contidas atualmente no caixa :/")




  








