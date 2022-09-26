import { useState } from 'react';
import { Button } from './components/button';
import { Resultado } from './components/resultado';
import * as C from './styles';

const lista = () => {
  var lista = [];
  for (let i = 1; i <= 100; i++) {
    if ( i % 3 === 0 && i % 5 === 0){
    lista.push(<C.Typography primary >Fizz</C.Typography>);
    } else if ( i % 5 === 0){
      lista.push(<C.Typography primary >Buzz</C.Typography>);
      }else if ( i % 3 === 0){
        lista.push(<C.Typography primary >FizzBuzz</C.Typography>);
        }else {
      lista.push(<C.Typography primary >{i}</C.Typography>);
    }
  }
  return lista;
}

function App() {

  const [mostrar, setMostrar] = useState(false);

  const trocaMostrar = () => {
    setMostrar(true);
  }

  return (
    <C.Container>
      <C.Flex direction="column">
        <C.Typography size="30px">Teste DojoPuzzles FizzBuzz</C.Typography>
        <C.Spacer margin="5px"/>
        <C.Typography >Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha, com as seguintes exceções:</C.Typography>
        <C.Spacer margin="5px"/>
        <C.Typography >
          * Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;<br/>
          * Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;<br/>
          * Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.
        </C.Typography>
        <C.Spacer margin="5px"/>
        <Button
        onClick={trocaMostrar}
        >
        Mostrar
        </Button>{ mostrar === true && (
        <Resultado>{lista()}</Resultado>
        )}
      </C.Flex>
    </C.Container>
  );
}

export default App;
