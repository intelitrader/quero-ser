def bissexto():
    continua = True
    while continua:
        try:
            ano = int(input('Informe o ano a ser analisado: '))
        except ValueError:
            print('O valor informado é de um tipo inválido!')
        except TypeError:
            print('O valor informado deve ser positivo!')
        else:
            continua = False
            if ano % 4 == 0 and ano % 100 != 0 or ano % 400 == 0:
                print('O ano {} é bissexto!'.format(ano))
            else:
                print('O ano {} não é bissexto!'.format(ano))


bissexto()
