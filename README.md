# Quero ser Intelitrader

## Como rodar a aplicação
O código da aplicação foi desenvolvido em [c++11](https://pt.wikipedia.org/wiki/C%2B%2B11), portanto você precisará desse compilador para compilar o código.

### Como compilar
O arquivo **app.cpp** se encontra dentro do diretório **Challenge**
```terminal
$ g++-11 app.cpp -o app
```
Ao executar o compilador, será gerado um arquivo executável dentro do mesmo diretório.

### Como executar

Execute o arquivo **app** via terminal, inserindo respectivamente o caminho dos arquivos **produtos.txt** e **vendas.txt**.

```terminal
$ ./app "../Caso de teste 1/c1_produtos.txt" "../Caso de teste 1/c1_vendas.txt"
```
### Saída
Os três relatórios serão criados dentro do diretório **Output**



### Observações importantes

Alguns pontos foram encontrados com relação a problemas nos requisitos informados, de qualquer forma o código foi desenvolvido baseado no que interpretei dos resultados dos casos de teste informados para que os relatórios gerados fiquem iguais.

1. Não foi informada uma ordem de priodidade com relação as divergências, portanto, existem casos em que uma venda pode apresentar duas divergências, entretanto, o arquivo de saída de teste informa apenas uma. Por exemplo:
> - Na linha 14 do arquivo c1_vendas.txt o código do produto não existe em c1_produtos.txt, alé disso essa venda também apresenta o código 999 referente a um erro desconhecido.    
> - Nesse caso o teste informa sobre o código 999 mas ignora o fato de não existir o código do produto

2. No arquivo **c1_totcanal.txt** estão sendo contabilizadas as vendas de produtos que não existem mas possuem código 100 ou 102 (Referente a uma venda efetuada).

> - Isso seria impossível numa aplicação real, visto que é impossível realizar uma venda de um produto que não existe.



