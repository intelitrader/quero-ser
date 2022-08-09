preço = 42.00
carrinho = {}
livros = ['Harry Potter', 'Hereges de Duna', 'Coraline', 'Uma Breve História do Tempo', 'A Dança da Morte',
          'Assim Falou Zaratrusta', 'Memórias Póstumas de Brás Cubas']
for n in range(0, 7):
    carrinho[livros[n]] = 0

# listando as opções
for n, v in enumerate(livros):
    print(f'[{n + 1}] - {v}')
print('[0] - Para Finalizar a Compra.')


cont = soma = 0
while True:
    if cont >= 1:
        print('-'*50)
        print('Seu Carrinho até agora:')
        for n, v in enumerate(carrinho):
            if carrinho[v] == 0:
                continue
            elif carrinho[v] == 2:
                somatorio = carrinho[v] * preço - preço*5/100
            elif carrinho[v] == 3:
                somatorio = carrinho[v] * preço - preço*10/100
            elif carrinho[v] == 4:
                somatorio = carrinho[v] * preço - preço*15/100
            else:
                somatorio = carrinho[v] * preço
            print(f'  {carrinho[v]} Livros [{v}]')
            print(f'Preço: R${somatorio:.2f}')
        print('-'*50)
    # adicionando ao carrinho
    escolha = int(input('Qual produto deseja adicionar ao carrinho? '))
    for c in range(1, 8):
        if escolha == c:
            carrinho[livros[c-1]] += 1
            print(f'O Livro {livros[c-1]} Foi Adicionado com sucesso!')
        else:
            continue
    if escolha == 0:
        break
    cont += 1

# Formatando o total do carrinho
total = []
for n, v in enumerate(carrinho):
    if carrinho[v] == 0:
        continue
    else:
        somatorio = carrinho[v] * preço
        total.append(somatorio)
total = sum(total)
print('--'*50)
print(f'Total da Compra: R${total:.2f}')

print('<- Volte Sempre! ->')
