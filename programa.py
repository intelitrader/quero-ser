import collections 
import functools
import operator
from collections import Counter

prodQtdEtq = {}
prodNecCO = {}
qtdVendas = []
prodExiste = []

dictVendas = {}
dictEstqAposVenda = {}
dictNescRepo = {}
dictQtdRepo = {}
dictTotal = {}

def lerDados():
	#ABRE ARQUIVO PRODUTOS.TXT
	with open ('produtos.txt', 'r') as p:
		for x in p:
			t = x.split(';')
			prodQtdEtq[int(t[0])] = int(t[1])
			prodNecCO[int(t[0])] = int(t[2])
			prodExiste.append(t[0])
			
	#ABRE ARQUIVO VENDAS.TXT		
	with open ("vendas.txt", "r") as v:
		for y in v:
			a = y.split(";")
			
			#ADICIONA OS DADOS DO ARQUIVO NO DICT 
			qtdVendas.append({int(a[0]) : int(a[1])})
			
			# RETORNA O TOTAL DE VENDAS
			if a[2] == '100' or a[2] == '102':
				resVenda = dict(functools.reduce(operator.add, map(collections.Counter, qtdVendas)))
				for a, b in resVenda.items():
					dictVendas[a] = b
					
		# RETORNA ESTOQUE APÓS VENDA 
		pqe  = Counter(prodQtdEtq)
		rv = Counter(resVenda)
		eap = pqe.subtract(rv)
		for a, b in pqe.items():
			dictEstqAposVenda[a] = b
		
		# RETORNA NECESSIDADE DE REPOSIÇÃO 
		for d, e in prodNecCO.items():
			for f, g in pqe.items():
				if d == f:
					if g <= e:
						repo = e - g
						dictNescRepo[d] = repo
					else: dictNescRepo[d] = 0
						
						# RETORNA QUANTIDADE DE TRANSFERÊNCIA
					if repo > 0 and repo <= 10:
						t = 10
						dictQtdRepo[d] = t
					else: 
						t = 0
						dictQtdRepo[d] = t
	
def criaArqTransfere():
	for a, b in prodQtdEtq.items():
		for c, d in prodNecCO.items():
			for e, f in dictVendas.items():
				for g, h in dictEstqAposVenda.items():
					for i, j in dictNescRepo.items():
						for k, l in dictQtdRepo.items():
							if a == c and a == e and a == g and a == i and a == k:
								dictTotal[a] = [b, d, f, h, j, l]
	with open ("transfere.txt", "w") as arq:
		arq.write( ("{:<10} {:<10} {:<10} {:<10} {:<10} {:<10} {:<10}".format("Produto", "QtCO", "QtMin", "QtVendas", "Estq. Após Venda", "Necess", "Transf. De Arm. p/ CO \n")))
		for k, v in dictTotal.items():
			v1, v2, v3, v4, v5, v6 = v
			arq.write(("{:<10} {:> 5} {:>10} {:>10} {:>10} {:>10} {:>10} \n".format(k, v1, v2, v3, v4, v5, v6)))
			
			
def criaArqDivergencia():
	lista = []
	arqDiverg = open ("divergencias.txt", "w")
	
	with open ("vendas.txt", "r") as v:
		for y in v:
			a = y.split(";")
			lista.append(a)
			if a[0] not in prodExiste:
				valor = a
				print("Linha", lista.index(valor), "- Código de Produto não encontrado", a[0], file = arqDiverg)
			
			if a[2] == '135':
				valor = a
				if valor == a:
					print("Linha", lista.index(valor), "- Venda cancelada", file = arqDiverg)
				
			if a[2] == '190':
				valor = a
				if valor == a:
					print("Linha", lista.index(valor), "- Venda não finalizada", file = arqDiverg)
			
			if a[2] == '999': 
				valor = a
				if valor == a: 
					print("Linha", lista.index(valor), "- Erro desconhecido. Acionar equipe de TI", file = arqDiverg)


def criaArqCanaisVendas():
	canalVendas = []
	dictCanal = {}
	arqCanal = open ("totcanal.txt", "w")
	with open ("vendas.txt", "r") as v:
		for y in v:
			a = y.split(";")
			if a[2] == '100' or a[2] == '102':
				canalVendas.append({int(a[3].strip("\n")) : int(a[1])})
				resCanal = dict(functools.reduce(operator.add, map(collections.Counter, canalVendas)))
				for a, b in resCanal.items():
					dictCanal[a] = b

	print("Canais \t\t\t QtVendas", file = arqCanal)	
	for x, y in dictCanal.items():
		if x == 1: print("1 - Representantes \t", y, file = arqCanal )
		if x == 2: print("2 - Website \t\t", y, file = arqCanal)
		if x == 3: print("3 - App Móvel Android \t", y, file = arqCanal)
		if x == 4: print("4 - App Móvel IPhone \t", y, file = arqCanal)
			
lerDados()
criaArqTransfere()
criaArqDivergencia()
criaArqCanaisVendas()