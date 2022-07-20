## Desafio Intelitrader
Aplicação web publicada em: https://desafiointelitrader.netlify.app/

## Tecnologias utilizadas
- JavaScript
- HTML 5
- CSS 3 (Styled Components)
- React.Js

## Telas
### Home
Tela inicial onde são carregados os arquivos produtos.txt e vendas.txt para gerar os arquivos pedidos no desafio.

<img src="https://github.com/YannFigueiredo/assets/blob/main/desafio-intelitrader-home.png"  alt="Tela home" title="Tela home"/>
<img src="https://github.com/YannFigueiredo/assets/blob/main/desafio-intelitrader-home-selecao.png"  alt="Tela home - Seleçã ode arquivo" title="Tela home - Seleção de arquivo"/>

### Tabelas
Tela onde são apresentadas as tabelas de vendas confirmadas e relatório por canais de vendas, além de serem disponibilizados, por meio de botões, os arquivos solicitados no desafio (transfere.txt, divergencias.txt e totcanais.txt).

<img src="https://github.com/YannFigueiredo/assets/blob/main/desafio-intelitrader-tabelas.png"  alt="Tela tabelas" title="Tela tabelas"/>
<img src="https://github.com/YannFigueiredo/assets/blob/main/desafio-intelitrader-tabelas-download.png"  alt="Tela tabelas - Download" title="Tela tabelas - Download"/>

### Arquivos gerados
Abaixo estão expostos como os arquivos estão formatados pela aplicação web.

<img src="https://github.com/YannFigueiredo/assets/blob/main/desafio-intelitraderarquivo-transfere.png"  alt="Arquivo transfere.txt" title="Arquivo transfere.txt"/>
<img src="https://github.com/YannFigueiredo/assets/blob/main/desafio-intelitraderarquivo-divergencias.png"  alt="Arquivo divergencias.txt" title="Arquivo divergencias.txt"/>
<img src="https://github.com/YannFigueiredo/assets/blob/main/desafio-intelitrader-arquivo-relatorio.png"  alt="Arquivo totcanais.txt" title="Arquivo totcanais.txt"/>

## Como executar o projeto
### Acessando o website
https://desafiointelitrader.netlify.app/

### Com Node.Js

```bash
# clonar o repositório
git clone https://github.com/YannFigueiredo/quero-ser-desafio-yann-figueiredo.git

# entrar na pasta da solução do desafio
cd desafio_intelitrader

# instalar as dependências
npm install

# executar o projeto
npm start
```

### Com Docker

```bash
# clonar o repositório
git clone https://github.com/YannFigueiredo/quero-ser-desafio-yann-figueiredo.git

# entrar na pasta da solução do desafio
cd desafio_intelitrader

# executar o docker
docker-compose up
```
