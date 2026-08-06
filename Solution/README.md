# Introdução
Olá meu nome é **Lucas**, solucionei o desafio usando a linguagem **Java** ☕ que tenho mais facilidade!

Basicamente o programa lê os arquivos de teste, no caso foi indicado pra ler na **pasta inputs**, e com isso gera os 3 arquivos de relatório na pasta outputs.

```java
public class Main {
	public static void main(String[] args) throws IOException {
		Report report = new Report();
		report.generateReports("inputs/c1_produtos.txt", "inputs/c1_vendas.txt");
		//report.generateReports("inputs/c2_produtos.txt", "inputs/c2_vendas.txt");
		report.registerReports();
	}
}
```
Os arquivos que vão ser lidos são indicados na classe **Main** onde temos a instancia de um relatório(Report), para alterar os arquivos de entrada basta alterar o caminho até este arquivo. Por exemplo descomentando o segundo **generateReports()**  e comentando o primeiro o programa ira testar o segundo caso de teste fornecido!

> **Observação:** A cada execução do programa gera os 3 arquivos de relatório, se eles não existirem ele cria, caso já existam ele apenas sobrescreve, apagando o conteúdo anterior.


## Como executar o projeto 🚀

Vou exemplicar usando a IDE que usei para criar esse projeto o eclipse!

O que é necessário ter instalado:
- Java JDK
- Eclipse


Com isso instalado basta clonar o repositório:
```bash
git clone https://github.com/DellGarcia/quero-ser.git
```

Pronto basta abrir a pasta Solution no Eclipse e executar o projeto.