import { Container, FileArea } from './styles';
import { useState, useRef, useEffect } from 'react';
import { lerArquivoProdutos, lerArquivoVendas } from './helpers';
import { Link } from 'react-router-dom';

export default function Home(){
    const inputProdutos = useRef(null);
    const inputVendas = useRef(null);
    
    const [ produtos, setProdutos ] = useState([]);

    const [ vendas, setVendas ] = useState([]);

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