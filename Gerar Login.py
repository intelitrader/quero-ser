# DojoPuzzle: Encontre o Telefone
# Autor: Taynan Carvalho
# Data de criação: 14/01/2022

# Importação de biblioteca
from random import shuffle # Função da biblioteca random que embaralha opções de uma lista

print('Informações cadastrais:\n')

# Inserção das informações cadastrais
nome = str(input('Nome: ')).strip().lower()
sobrenome = str(input('Sobrenome: ')).strip().lower()
email = str(input('Email: ')).strip().lower()
nasc = str(input('Data de Nascimento - (dd/mm/aaaa): '))

# Exclusão das barras, pois são meramente ilustrativas
nasc = nasc.split('/')

# Divisão da data de nascimento em
dia = nasc[0]
mes = nasc[1]
ano = nasc[2]

# Formatação do ano em aaaa ou aa
aaaa = ano[0:4]
aa = ano[2:4]

# Formação de sugestões a partir do Nome | Sobrenome | Dia de nascimento | Mês de Nascimento | Ano de nascimento
sugestoes = [nome + sobrenome, 
     nome + sobrenome + dia,
     nome + sobrenome + mes,
     nome + sobrenome + aaaa,
     nome + sobrenome + aa
     ]

# Formação de sugestões a partir do Nome | Sobrenome | Dia de nascimento | Mês de Nascimento | Ano de nascimento | Palavra 'dev'    
sugestoesdev = [nome + 'dev',
    sobrenome + 'dev',
    sobrenome + 'dev' + aaaa,
    sobrenome + 'dev' + aa, 
    'dev' + nome, 'dev' + sobrenome,
    'dev' + nome + aaaa,
    'dev' + nome + aa,
    'dev' + sobrenome + aaaa,
    'dev' + sobrenome + aa
    ]

# Embaralhamento das sugestões
shuffle(sugestoes)
shuffle(sugestoesdev)

# Sugestões demonstradas na tela, de forma aleátoria.
# Sendo duas sugestões a partir Nome | Sobrenome | Dia de nascimento | Mês de Nascimento | Ano de nascimento,
# E outra acrescentando com os mesmos quesitos, mas acrescentando a palavra 'dev'
print('\nSugestões de login: {}, {}, {}'.format(sugestoes[0], sugestoes[1], sugestoesdev[0]))

# Escolha do login pelo usuário
login = str(input('Login: '))

# Frase de confirmação do cadastro
print('\nCadastro feito com sucesso!')
