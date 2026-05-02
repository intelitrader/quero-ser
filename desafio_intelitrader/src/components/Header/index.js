import logo from '../../assets/logo.png';
import { Link } from 'react-router-dom';
import { Container } from './styles';

export default function Header(){
    return(
        <Container>
            <Link to='/'>
                <img src={logo} alt='Logo da Intelitrader'/>
            </Link>
        </Container>
    );
}