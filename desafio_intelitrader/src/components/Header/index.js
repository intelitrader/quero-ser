import logo from '../../assets/logo.png';
import { Container } from './styles';

export default function Header(){
    return(
        <Container>
            <img src={logo} alt='Logo da Intelitrader'/>
        </Container>
    );
}