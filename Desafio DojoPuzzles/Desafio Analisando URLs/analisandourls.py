"""
Problema resolvido de acordo com o link abaixo
https://dojopuzzles.com/problems/analisando-urls/


Dada uma URL, desenvolva um programa que indique se a URL é válida ou não e, caso seja válida, retorne as suas partes constituintes.

Exemplos:

Entrada: http://www.google.com/mail/user=fulano
Saída:
protocolo: http
host: www
domínio: google.com
path: mail
parâmetros: user=fulano

Entrada: ssh://fulano%senha@git.com/
Saída:
protocolo: ssh
usuário: fulano
senha: senha
dominio: git.com
"""


from urllib.parse import urlparse

def validar_url(url):
    try:
        result = urlparse(url)
        if all([result.scheme, result.netloc]):
            partes = {
                'protocolo': result.scheme,
                'host': result.netloc.split('.')[0],
                'domínio': '.'.join(result.netloc.split('.')[1:]),
                'path': result.path.strip('/'),
                'parâmetros': result.query
            }
            return partes
        else:
            return False
    except ValueError:
        return False

url = input("Digite a URL para validar: ")

resultado = validar_url(url)
if resultado:
    for chave, valor in resultado.items():
        print(f"{chave}: {valor}")
else:
    print("URL inválida.")