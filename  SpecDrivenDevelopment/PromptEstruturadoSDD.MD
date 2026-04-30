
Título do Projeto: Desafio Técnico Intelitrader - Solução de Problemas DojoPuzzles (Foco em Alta Performance)

Contexto:
Preciso resolver três desafios do DojoPuzzles para me candidatar a uma vaga de Desenvolvedor na Intelitrader, uma empresa de software de alto desempenho para o mercado financeiro. A empresa utiliza C# (.NET 8/9), Arquitetura DDD, CQRS, TDD e preza por clean code e performance otimizada.

Objetivo:
Atuar como um Arquiteto de Software Sênior para projetar a solução do problema "Livraria do Harry Potter" (e outros dois desafios similares), garantindo que a implementação reflita exatamente os padrões utilizados pela Intelitrader.

Especificações Técnicas (SDD):

Arquitetura: Implementar utilizando os princípios de DDD (Domain-Driven Design). Separe claramente as camadas de Domain, Application e Infrastructure.

Padrão de Mensageria/Comando: Utilizar CQRS para separar a lógica de cálculo (Query/Command) da execução.

Qualidade de Código: A solução deve ser guiada por TDD (Test Driven Development). Escreva primeiro a estrutura dos testes unitários (xUnit/NUnit) antes da lógica de negócio.

Performance: O algoritmo deve buscar a maior eficiência possível. Para o problema da Livraria, o foco é encontrar a combinação de descontos que resulte no menor valor para o cliente (ex: identificar que 2 conjuntos de 4 livros é melhor que 1 de 5 e 1 de 3).

Tecnologia: Use C# moderno (.NET 8/9). Utilize coleções eficientes e evite alocações desnecessárias de memória.

Instruções de Saída:
Gere a estrutura da solução para o problema "Livraria do Harry Potter" contendo:

Domínio: Entidade Livro e CestaDeCompras.

Serviço de Domínio: A lógica do algoritmo de cálculo de desconto otimizado.

Testes: Um exemplo de classe de teste que valide o cenário: (2 cópias do 1º, 2 do 2º, 2 do 3º, 1 do 4º e 1 do 5º resultando em R$ 268,80).

Restrição Importante: Não use o desafio "Ano Bissexto".

Dicas Adicionais para sua Candidatura:
Destaque sua Experiência: Como você já possui experiência sólida com DDD, CQRS e .NET 8/9, use isso a seu favor no Pull Request. A Intelitrader valoriza quem já domina esses padrões.

O Diferencial da Performance: No texto da vaga, eles mencionam "software de alto desempenho". Ao enviar sua solução, comente sobre a complexidade de tempo (Big O) do seu algoritmo de cálculo de descontos.

Home Office: O fato de você exigir 100% home office está totalmente alinhado com a cultura deles, que é remota desde 2012.

DojoPuzzles: Escolha os outros dois problemas que permitam demonstrar o uso de algoritmos mais complexos ou manipulação de dados, evitando os muito triviais.
