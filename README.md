# Resolução do desafio

## Estrutura da resolução

A resolução foi inteiramente realizada em C. As funções que tratam da geração do arquivo TRANSFERE.TXT se encontram em `transfer.c`, as que tratam da checagem de divergências nas vendas ficam no arquivo `divergences.c`, e, por fim, as funções que tratam da análise das plataformas de vendas ficam no arquivo `channels.c`. Cada um desses módulos possui um header file, de modo a encapsular algumas funções. Fora isso, há também o módulo `shared.c` que possui constantes de uso geral. O código do programa principal é o `main.c`.

Veja a seguir como executar a solução.


## Como rodar a solução

Para rodar a solução, siga os seguintes passos:
- Compilar o código fonte. Para isso basta realizar `make all` dentro da pasta "Solução". Esse etapa irá produzir um binário chamado `desafio`;
- Inclua o arquivo VENDAS.TXT e PRODUTOS.TXT na mesma pasta que se encontra o binário; Caso tente rodar sem esses arquivos, o programa irá alertar a ausência deles;
- Rode o binário com `./desafio`. Será gerado os arquivos TOTCANAIS.TXT, TRANSFERE.TXT e DIVERGENCIAS.TXT na mesma pasta.