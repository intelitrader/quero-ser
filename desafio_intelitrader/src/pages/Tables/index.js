import { useLocation } from 'react-router-dom';
import { useState, useRef } from 'react';
import { definirVendasConfirmadas, definirDivegencias, definirRelatorioCanais, gerarArquivoVendas, gerarArquivoDivergencias, gerarArquivoRelatorio } from './helpers';
import { Container, ContainerTables, ContainerButtons } from './styles';

export default function Tables(){
    const {state: {produtos, vendas}} = useLocation();
    const [ vendasConfirmadas, setVendasConfirmadas ] = useState(definirVendasConfirmadas(produtos, vendas));
    const [ divergencias, setDivergencias ] = useState(definirDivegencias(produtos, vendas));
    const [ relatorioCanais, setRelatorioCanais ] = useState(definirRelatorioCanais(vendas));

    const btnVendas = useRef(null);
    const btnDivergencias = useRef(null);
    const btnRelatorio = useRef(null);

    return(
        <Container>
            <ContainerTables>
                <div>
                    <table>
                        <caption>Vendas confirmadas</caption>
                        <thead>
                            <tr>
                                <th>Produto</th>
                                <th>QtCO</th>
                                <th>QtMin</th>
                                <th>QtVendas</th>
                                <th>Esq. após vendas</th>
                                <th>Necessid.</th>
                                <th>Transf. de Arm. p/ CO</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                vendasConfirmadas.map((venda, key) => (
                                    <tr key={key}>
                                        <td>{venda.produto}</td>
                                        <td>{venda.qtdco}</td>
                                        <td>{venda.qtdMin}</td>
                                        <td>{venda.qtdVendas}</td>
                                        <td>{venda.estoque}</td>
                                        <td>{venda.necessidadeRepo}</td>
                                        <td>{venda.qtdTransferida}</td>
                                    </tr>
                                ))
                            }
                        </tbody>
                    </table>
                </div>
                <div>
                    <table>
                        <caption>Relatório por canais de vendas</caption>
                        <thead>
                            <tr>
                                <th>Canal</th>
                                <th>Quantidade de vendas</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                relatorioCanais.map((relatorio, key) => (
                                    <tr key={key}>
                                        <td>{relatorio.id} - {relatorio.canal}</td>
                                        <td>{relatorio.totalVendas}</td>
                                    </tr>
                                ))
                            }
                        </tbody>
                    </table>   
                </div>
            </ContainerTables>
            <ContainerButtons>
                <a ref={btnVendas} onClick={() => {gerarArquivoVendas(vendasConfirmadas, btnVendas)}} download>
                    <button>Baixar transfere.txt</button>
                </a>
                <a ref={btnDivergencias} onClick={() => {gerarArquivoDivergencias(divergencias, btnDivergencias)}} download>
                    <button>Baixar divergencias.txt</button>
                </a>
                <a ref={btnRelatorio} onClick={() => {gerarArquivoRelatorio(relatorioCanais, btnRelatorio)}} download>
                    <button>Baixar totcanais.txt</button>
                </a>
            </ContainerButtons>
        </Container>
    );
}