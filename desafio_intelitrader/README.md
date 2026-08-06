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
## Sobre o código

### Leitura dos arquivos de entrada
Na home existem dois campos de seleção de arquivo, onde o primeiro deve selecionar produtos.txt e o segundo vendas.txt. O conteúdo das linhas dos arquivos são transformados em listas, salvos em states, e são enviados para serem tratados na página de tabelas, por meio do clique no botão "Ver tabelas" da home.

```
export default function Home(){
    # referências aos inputs da interface
    const inputProdutos = useRef(null);
    const inputVendas = useRef(null);
    
    # states para armazenar as listas com os dados de produtos.txt e vendas.txt
    const [ produtos, setProdutos ] = useState([]);
    const [ vendas, setVendas ] = useState([]);
    
    # o useEffect é responsável por adicionar listeners nos inputs de arquivos, para então executar os scripts de conversão dos arquivos em listas dentro dos sets do states 
    useEffect(() => {
        inputProdutos.current.addEventListener('change', (evt) => {
            setProdutos(lerArquivoProdutos(evt));
        });

        inputVendas.current.addEventListener('change', (evt) => {
            setVendas(lerArquivoVendas(evt));
        });
    }, []);

    return(
        <Container>
            <section>
                <FileArea>
                    <label for='produtos'>Selecione o arquivo produtos.txt</label>
                    <input type='file' name='produtos' ref={inputProdutos}/>
                </FileArea>
                <FileArea>
                    <label for='vendas'>Selecione o arquivo vendas.txt</label>
                    <input type='file' name='vendas' ref={inputVendas}/>
                </FileArea>
            </section>
            <Link to='/tables' state={{produtos: produtos, vendas: vendas}}>
                <button>Ver tabelas</button>
            </Link>
        </Container>
    );
}

# helpers.js / scripts de leitura dos arquivos
export const lerArquivoProdutos = (e) => {
    let lista = [];
    
    e.preventDefault();
    const reader = new FileReader(); # variável para usar a função de leitura do arquivo a partir do evento vindo da interface
    reader.onload = (e) => {
        const text = e.target.result.split("\n").filter(x => x !== '');
      
        for(var i = 0; i < text.length; i++){
            let listaTemp = text[i].split(";");
            
            # cada linha do arquivo é transformada em um objeto
            lista.push({
                codigoProduto: parseInt(listaTemp[0], 10), 
                qtdEstoque: parseInt(listaTemp[1], 10), 
                qtdMinima: parseInt(listaTemp[2].split("\r")[0], 10)
            });
        }
    };
    reader.readAsText(e.target.files[0]);

    return lista; # retornada uma lista de objetos
};

# função semelhante a anterior, mas com objetos diferentes referentes a vendas.txt
export const lerArquivoVendas = (e) => {
    let lista = [];
    
    e.preventDefault();
    const reader = new FileReader();
    reader.onload = (e) => {
        const text = e.target.result.split("\n").filter(x => x !== '');

        for(var i = 0; i < text.length; i++){
            let listaTemp = text[i].split(";");

            lista.push({
                codigoProduto: parseInt(listaTemp[0], 10), 
                qtdVendas: parseInt(listaTemp[1], 10), 
                situacaoVenda: parseInt(listaTemp[2], 10), 
                canalVenda: parseInt(listaTemp[3].split("\r")[0], 10)
            });
        }
    };
    reader.readAsText(e.target.files[0]);

    return lista;
};
```

### Gerar listas resultantes
Na página de tabelas são renderizadas duas tabelas, senda uma de vendas confirmadas (referente a transfere.txt) e a outra de relatório de vendas por canais (referente a totcanais.txt). As tabelas são geradas a partir de listas feitas a partir das states recebidas da home. Na página tabelas são ainda disponiblizados para download os arquivos solicitados no desafio.

```
# As funções com nomes iniciados em "definir" são responsáveis por criar as listas referentes a transfere.txt, divergencias.txt e totcanais.txt  
export function definirVendasConfirmadas(produtos, vendas){
    let listaVendas = vendas.filter(venda => venda.situacaoVenda === 100 || venda.situacaoVenda === 102); # criada uma nova lista de vendas filtrando só pelas vendas com situação 100 ou 102
    let lista = [];

    produtos.forEach(produto => {      
        let qtdVendas = (listaVendas.filter(x => x.codigoProduto === produto.codigoProduto))
                        .reduce((soma, atual) => { 
                            return soma + atual.qtdVendas;
                        }, 0); # soma das vendas considerando filtrando por produto
        let calculoNecessidade = produto.qtdMinima - (produto.qtdEstoque - qtdVendas);
        let necessidadeRepo = calculoNecessidade < 0 ? 0 : calculoNecessidade; # a necessidade de reposição é 0 se o cálculo acima for menor que 0, caso contrário o valor da varável fica sendo o próprio cálculo acima
      
        # objeto criado
        lista.push({
            produto: produto.codigoProduto, 
            qtdco: produto.qtdEstoque, 
            qtdMin: produto.qtdMinima, 
            qtdVendas: qtdVendas, 
            estoque: produto.qtdEstoque - qtdVendas, 
            necessidadeRepo: necessidadeRepo, 
            qtdTransferida: necessidadeRepo > 1 && necessidadeRepo < 10 ? 10 : necessidadeRepo
        });
    });

    return lista;
}

# verifica se o código em cada venda é válido
function checarCodigoProduto(produtos, venda){   
    for(var i = 0; i < produtos.length; i++){
        if(produtos[i].codigoProduto === venda.codigoProduto)
            return {codigo: 0, resposta: true};
    }

    return {codigo: venda.codigoProduto, resposta: false};
}

export function definirDivegencias(produtos, vendas){
    let lista = [];

    for(var i = 0; i < vendas.length; i++){
        let verificacaoCodigoProduto = checarCodigoProduto(produtos, vendas[i]);
        
        # cada if que resulte em true cria uma divergência salva como string em uma lista
        if(verificacaoCodigoProduto.resposta === false) 
            lista.push(`Linha ${i+1} - Código de Produto não encontrado ${verificacaoCodigoProduto.codigo}`);
        if(vendas[i].situacaoVenda === 135)
            lista.push(`Linha ${i+1} - Venda cancelada`);
        if(vendas[i].situacaoVenda === 190)
            lista.push(`Linha ${i+1} - Venda não finalizada`);
        if(vendas[i].situacaoVenda === 999)
            lista.push(`Linha ${i+1} - Erro desconhecido. Acionar equipe de TI`);
    }

    return lista;
}

export function definirRelatorioCanais(vendas){
    let listaVendas = vendas.filter(venda => venda.situacaoVenda === 100 || venda.situacaoVenda === 102);

    let relatorioCanais = [
        {
            id: 1, 
            canal: 'Representantes', 
            totalVendas: listaVendas.filter(venda => venda.canalVenda === 1)
                        .reduce((soma, atual) => {return soma + atual.qtdVendas}, 0)
        },
        {
            id: 2, 
            canal: 'Website', 
            totalVendas: listaVendas.filter(venda => venda.canalVenda === 2)
                        .reduce((soma, atual) => {return soma + atual.qtdVendas}, 0)
        },
        {
            id: 3, 
            canal: 'Aplicativo móvel Android', 
            totalVendas: listaVendas.filter(venda => venda.canalVenda === 3)
                        .reduce((soma, atual) => {return soma + atual.qtdVendas}, 0)
        },
        {
            id: 4, 
            canal: 'Aplicativo móvel iPhone', 
            totalVendas: listaVendas.filter(venda => venda.canalVenda === 4)
                        .reduce((soma, atual) => {return soma + atual.qtdVendas}, 0)
        }
    ];
    
    return relatorioCanais;
}
```

### Disponibilizando para download
Os botões presentes na página tabelas disparam funções para construir strins formatadas para salvar em arquivos txt e gerar evento de download.
```
# usada para formatar as strings nos arquivos txt
function ajustarString(string, tamanho){
    let novaString = string.toString();

    if(novaString.length <= tamanho){
        for(var i = novaString.length; i < tamanho; i++){
            novaString += ' ';
        }
    }

   return novaString;
}

# as funções que iniciam em "gerar" constroem a string para ser salva em uma arquivo txt e ainda dispara o evento de download para o usuário obter o arquivo pretendido
export function gerarArquivoVendas(lista, btn){
    let conteudo = 'Necessidade de Transferência Armazém para CO\n\nProduto   QtCO   QtMin   QtVendas   Estq.após Vendas   Necess.     Transf. de Arm p/ CO\n';

    for(var i = 0; i < lista.length; i++){
        conteudo += `${lista[i].produto}     ${ajustarString(lista[i].qtdco, 5)}  ${ajustarString(lista[i].qtdMin, 5)}   ${ajustarString(lista[i].qtdVendas, 5)}      ${ajustarString(lista[i].estoque, 5)}              ${ajustarString(lista[i].necessidadeRepo, 5)}       ${ajustarString(lista[i].qtdTransferida, 5)}\n`;
    }

    btn.current.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(conteudo));
    btn.current.setAttribute('download', 'transfere.txt');
}

export function gerarArquivoDivergencias(lista, btn){
    let conteudo = '';

    for(var i = 0; i < lista.length; i++){
        conteudo += `${lista[i]}\n`
    }

    btn.current.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(conteudo));
    btn.current.setAttribute('download', 'divergencias.txt');
}

export function gerarArquivoRelatorio(lista, btn){
    let conteudo = `Quantidades de Vendas por canal\n\n${ajustarString("Canal", 34)}QtdVendas\n`;

    for(var i = 0; i < lista.length; i++){
        conteudo += `${lista[i].id} - ${ajustarString(lista[i].canal, 30)}${lista[i].totalVendas}\n`
    }

    btn.current.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(conteudo));
    btn.current.setAttribute('download', 'totcanais.txt');
}
```

## Autor

Yann Fabricio Cardoso de Figueiredo  
LinkedIn: https://www.linkedin.com/in/yann-figueiredo-5a5046102/  
Portfólio: https://portfolio-yann.netlify.app/
