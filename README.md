# Desafio Intelitrader

## Descrição 
Este projeto é a resolução de um desafio para candidatura de vaga, idealizada pela Intelitrader. 
O desafio se trata de um sistema para gerenciar vendas e estoque de um empresa, sendo que o cadastro dos produtos e das vendas deve ser feito de forma externa através de arquivos .txt, e o sistema dará como saída outros arquivos .txt (transfere.txt, totcanais.txt, e divergencias.txt).

**Link para a descrição completa do desafio [aqui](https://github.com/intelitrader/quero-ser/tree/master/Desafio)**

 ## 📁 Acesso ao projeto

Você pode ter acesso aos arquivos do projeto clicando [aqui](https://github.com/guiCarvalhoSP/desafio-intelitrader). 

## 🛠️ Como rodar o projeto

- É necessário ter previamente instalado em sua máquina o [Git](https://git-scm.com/) [NPM](https://www.npmjs.com/) e [NodeJs](https://nodejs.org/en). Após instala-los e configura-los, poderá seguir para os próximos passos.
- Use o comando ``git clone https://github.com/guiCarvalhoSP/desafio-intelitrader.git`` para clonar o projeto no diretório desejado.
- Após clonar, abra o diretório no projeto em um terminal, e execute o comando ``npm i`` ou ``npm install``, para instalar as dependências.
- Ao finalizar a instalação, você poderá executar o programa em um terminal através do comando ``npm run app``. O programa executará, e criará na raíz do projeto um diretório chamado "resultados", neste diretório estára todos os arquivos gerados.

**Importante** :
- Para o programa funcinar corretamente, deve se ter um arquivo para vendas no diretório "src\files\vendas\", e um arquivo para produtos no diretório "src\files\produtos". Caso não haja algum dos arquivos em um desses diretórios o programa gerará uma mensagem de erro no console do terminal. Não existe padrão para os nomes dos arquivos.

- O programa inicialmente vem com um arquivo de produto e de venda já nos diretórios corretos (mesmos arquivos do Caso de teste 1), e que você pode altera-los a vontade, desde que os novos arquivos sigam os moldes deles.

- Caso haja mais de um arquivo no diretório de produtos ou de venda, será considerado apenas o primeiro de cada um, em ordem alfabética.

- Pode se rodar o projeto, com os mesmos arquivos, ou arquivos diferentes de venda e produtos várias vezes, e os resultados serão salvos em ordem de execução, nos arquivos transfere.txt, totcanais.txt, e divergencias.txt do diretório "resultados" .

- Na raíz do projeto a um diretório chamado "arquivos", este diretório não é utilizado pelo projeto, e nele está armazenado dois casos de testes (Com os arquivos de entrada de produtos e vendas, e os 3 arquivos que se esperam de resultado). Use-os para realizar eventuais testes.

## ✔️ Tecnologias utilizadas
- ``Javascript``
- ``NodeJs``
- ``Biblioteca fs``

