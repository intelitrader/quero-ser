# Solução do desafio "Teste Técnico Intelitrader"

## Instruções para execução da aplicação

- Dependencias: .Net 5.0 Runtime (download: https://dotnet.microsoft.com/download/dotnet/5.0)

- Via executável "Solução.exe" (Prompt de comando):

	```Solução.exe "../Caso de teste 1/c1_vendas.txt" "../Caso de teste 1/c1_produtos.txt"```
- Via Visual Studio (Solução.sln):
	1. Em "▶ Solução ▾", clicar no menu drop-down (▾).
	2. Clicar em "🔧 Propriedades de Depuração e Solução".
	3. Em "Argumentos da linha de Comando" adicionar o caminho dos arquivos.
		Ex: "../Caso de teste 1/c1_vendas.txt" "../Caso de teste 1/c1_produtos.txt" (Com aspas para cada argumento).
	4. Fechar a caixa de diálogo e Clicar em "▶ Solução ▾".
- Linux via "Solução.dll":

	```dotnet Solução.dll "../Caso de teste 1/c1_vendas.txt" "../Caso de teste 1/c1_produtos.txt"```

- Os arquivos "transfere.txt", "divergencias.txt" e "totcanais.txt" serão salvos na pasta pai (parent directory) do caminho do arquivo de produtos.
