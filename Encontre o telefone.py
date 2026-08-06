# DojoPuzzle: Encontre o Telefone
# Autor: Taynan Carvalho
# Data de criação: 14/01/2022

# Importação de biblioteca
from re import sub # Função da biblioteca re para substituir as letras pelos números

# Frase de introdução ao Puzzle
print('\033[1;31;40m-=' * 17 + '-')
print('| DozoPuzzle: Encontre o Telefone |')
print('-=' * 17 + '-\n')

# Entrada da expressão
frase = str(input('\033[0;30;0mEscreva uma expressão: ')).upper()

# Atribuição das letras com os números
frase = sub(r'A|B|C','2',frase) # ABC -> 2
frase = sub(r'D|E|F','3',frase) # DEF -> 3
frase = sub(r'G|H|I','4',frase) # GHI -> 4
frase = sub(r'J|K|L','5',frase) # JKL -> 5
frase = sub(r'M|N|O','6',frase) # MNO -> 6
frase = sub(r'P|Q|R|S','7',frase) # PQRS -> 7
frase = sub(r'T|U|V','8',frase) # TUV -> 8
frase = sub(r'W|X|Y|Z','9',frase) # WXYZ -> 9

# Telefone decodificado
print('Número de telefone da expressão: {}'.format(frase))
