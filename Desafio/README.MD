# Teste Técnico Intelitrader

## Contexto

Imagine uma empresa de que precisa preparar as entregas das vendas realizadas em um período. As vendas são realizadas através de diversos canais, como: representantes comerciais, website e aplicativo móvel. Para funcionar essa empresa mantém dois endereços: um Centro Operacional (CO) centralizado, mais próximo do consumidor e de tamanho menor por estar em local de aluguel mais caro. Possui também um Armazém de grande tamanho, menos centralizado e com custo de aluguel bem mais barato por m2 . Na rotina operacional da empresa há um momento em que as vendas realizadas pelos diversos canais são reunidas e consolidadas visando a preparação para entrega. Nesse momento é produzido um arquivo contendo as vendas do período. A primeira tarefa é processar este arquivo e levantar a eventual necessidade de estoque para atender as entregas. Como o Centro Operacional não tem grande espaço o estoque mantido ali é limitado. Assim, com base nas vendas do período e no estoque pré-existente o programa deve calcular, para cada produto, a quantidade de itens que devem ser enviados do Armazém para o Centro Operacional.

## Descrição do Trabalho

**Informações Iniciais**

Este projeto estará baseado na leitura de dois arquivos texto de entrada: PRODUTOS.TXT e VENDAS.TXT
O primeiro, PRODUTOS.TXT, contém dados básicos de produtos comercializados por uma empresa conforme o layout mostrado
abaixo. Nos campos numéricos reais lembre-se de usar o caractere ponto (.) como separador decimal. Este arquivo é fornecido
ordenado por código de produto (ordem crescente).

```
16320;344;200
23400;1435;500
26440;2899;800
28790;310;150
36540;431;100
etc...
```
Cada linha do arquivo refere-se a um produto cadastrado que contém duas informações separadas pelo caractere ";".
| Posição | Informação                                                   | Formato             | Observações                                             |
|---------|--------------------------------------------------------------|---------------------|---------------------------------------------------------|
| (1)     | Código do Produto                                            | 5 dígitos numéricos | O código de produto tem 5 dígitos (começando em 100000) |
| (2)     | Quantidade em estoque no início do período                   | Número inteiro      |                                                         |
| (3)     | Quantidade mínima que deve ser mantida no Centro Operacional | Número Inteiro      |                                                         |


O segundo arquivo, VENDAS.TXT, contém dados de vendas cuja entrega precisa ser preparada. A questão aqui é determinar se o estoque disponível atende a necessidade. Caso não atenda, é preciso calcular quanto material deve ser movimentado do Armazém para o Centro Operacional. Este arquivo tem o layout mostrado abaixo: 
```
36540;16;100;1
26440;2;100;3
16320;1;100;2
26440;5;190;3
etc...
```
| Posição | Informação         | Formato             | Observações                                                                                                                                                                              |
|---------|--------------------|---------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| (1)     | Código do Produto  | 5 dígitos numéricos | O código de produto tem 5 dígitos (começando em 100000)                                                                                                                                  |
| (2)     | Quantidade vendida | Número inteiro      |                                                                                                                                                                                          |
| (3)     | Situação da venda  | Número inteiro      | 100: venda confirmada e com pagamento ok. 102: venda confirmada, mas com pagamento pendente 135: venda cancelada 190: venda não finalizada no canal de vendas 999: erro não identificado |
| (4)     | Canal de venda     | Número inteiro      | 1: Representante comercial 2: Website 3: Aplicativo móvel Android 4: Aplicativo móvel iPhone                                                                                             |

### Pede-se neste Projeto Programa
1\. 

O resultado que se espera deste programa é a produção de um arquivo de saída contendo dados de vendas confirmadas (atenção a isso) com um layout legível formatado conforme mostrado abaixo. Este arquivo deve ter o nome **transfere.txt**

```
Necessidade de Transferência Armazém para CO

Produto	QtCO	QtMin	QtVendas	Estq.após	Necess.	Transf. de
					Vendas			Arm p/ CO
16320	344	200	128		216		0		0
23400	1435	500	937		498		2		10
26440	2899	800	239		2660		0		0
28790	310	150	245		65		85		85
36540	431	100	617		-186		286		286
...
```

**Descrição das colunas**
| Coluna               | Descrição                                                                                                                                                                                                                        |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Produto              | é o código do produto                                                                                                                                                                                                            |
| QtCO                 | é a quantidade de produto disponível no Centro Operacional no início do período. Este dado constado arquivo de entrada                                                                                                           |
| QtMin                | é a quantidade mínima de produto que deve estar no Centro Operacional. Este dado consta do arquivo de entrada                                                                                                                    |
| QtVendas             | é a quantidade vendida do produto e deve ser apurada totalizando-se todas as vendas confirmadas (que podem estar com pagamento ok ou pendente, ou seja, situação 100 ou 102)                                                     |
| Estq. após vendas    | é a quantidade que ficará em estoque depois de descontar as vendas. Corresponde a QtCO – QtVendas                                                                                                                                |
| Necess.              | é a necessidade de reposição de estoque no Centro Operacional, para que se mantenha o estoque mínimo. É a quantidade mínima menos o estoque após as vendas, quando se o estoque após as vendas for menor que a quantidade mínima |
| Transf. de Arm p/ CO | é a quantidade a ser transferida do Armazém para o Centro Operacional. Quando a Necessidade for maior que 1, porém menor que 10, devem ser transferidas 10 unidades                                                              |

2\.

**Relatório de Divergências**

Um segundo arquivo deve ser gravado com o nome DIVERGENCIAS.TXT. Nele constarão casos que são divergentes. Para cada
divergência deve-se gravar o número da linha do arquivo e a mensagem conforme descrito na tabela a seguir:
| Divergência                                                                                                                                                                                                                                     | Mensagem                                           |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------|
| Se no arquivo VENDAS.TXT houver algum código de produto que não consta do arquivo PRODUTOS.TXT deve ser gravado nas divergências a mensagem ao lado, onde LL é o número da linha do arquivo de vendas e CCCCC é o código de produto inexistente | Linha LL – Código de Produto não encontrado CCCCC  |
| Se a situação da venda (este dado consta do arquivo VENDAS.TXT) for 135 deve-se gravar a mensagem ao lado, onde LL é o número da linha do arquivo de vendas.                                                                                    | Linha LL – Venda cancelada                         |
| Se a situação da venda (este dado consta do arquivo VENDAS.TXT) for 190 deve-se gravar a mensagem ao lado, onde LL é o número da linha do arquivo de vendas.                                                                                    | Linha LL – Venda não finalizada                    |
| Se a situação da venda (este dado consta do arquivo VENDAS.TXT) for 999 deve-se gravar a mensagem ao lado, onde LL é o número da linha do arquivo de vendas.                                                                                    | Linha LL – Erro desconhecido. Acionar equipe de TI |

3\.

**Relatório por canais**

Grave um terceiro arquivo, com quantidades totais vendidas por canal de vendas, no formato mostrado abaixo. Este arquivo
deve ter o nome TOTCANAIS.TXT.
Lembrar que apenas as vendas com situação 100 ou 102 devem ser consideradas.

```
Quantidades de Vendas por canal

1 - Representantes		624
2 - Website			873
3 - App móvel Android		582
4 - App móvel iPhone		88
```

**Recursos Fornecidos**

1. Pasta "Caso de teste 1" contendo
    - Arquivos de Entrada: C1_PRODUTOS.TXT e C1_VENDAS.TXT
    - Arquivos de Saída: C1_TRANSFERE.TXT, C1_DIVERGENCIAS.TXT e C1_TOTCANAIS.TXT


2. Pasta "Caso de teste 2" contendo
    - Arquivos de Entrada: C2_PRODUTOS.TXT e C2_VENDAS.TXT
    - Arquivos de Saída: C2_TRANSFERE.TXT, C2_DIVERGENCIAS.TXT e C2_TOTCANAIS.TXT


3. Pasta "Aplicação" contendo um exemplo
    - Binários de exemplo de execução.
        - Dependencias: .Net 5.0 Runtime (download: https://dotnet.microsoft.com/download/dotnet/5.0)
    - Comandos para executar:
        - Windows: ```EstoqueOperacional.exe "../Caso de teste 1/c1_vendas.txt" "../Caso de teste 1/c1_produtos.txt"```
        - Linux: ```dotnet EstoqueOperacional.dll "../Caso de teste 1/c1_vendas.txt" "../Caso de teste 1/c1_produtos.txt"```

### Agradecimentos
Agradecimentos ao professor **Sérgio Luiz Banin** que disponibilizou os problemas utilizados em sala de aula na Faculdade de Tecnologia de São Caetano do Sul.
