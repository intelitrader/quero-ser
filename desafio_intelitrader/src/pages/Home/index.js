import { Container, FileArea } from './styles';

export default function Home(){
    return(
        <Container>
            <section>
                <FileArea>
                    <label for='produtos'>Selecione o arquivo produtos.txt</label>
                    <input type='file' name='produtos'/>
                </FileArea>
                <FileArea>
                    <label for='vendas'>Selecione o arquivo vendas.txt</label>
                    <input type='file' name='vendas'/>
                </FileArea>
            </section>
            <button>
                Ver tabelas
            </button>
        </Container>
    );
}