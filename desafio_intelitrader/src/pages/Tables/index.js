import { useLocation } from 'react-router-dom';
import { useState } from 'react';
import { definirVendasConfirmadas, definirDivegencias } from './helpers';

export default function Tables(){
    const {state: {produtos, vendas}} = useLocation();
    const [ vendasConfirmadas, setVendasConfirmadas ] = useState(definirVendasConfirmadas(produtos, vendas));
    const [ divergencias, setDivergencias ] = useState(definirDivegencias(produtos, vendas));

    return(
        <div>
            
        </div>
    );
}