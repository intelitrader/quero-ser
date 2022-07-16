import { useLocation } from 'react-router-dom';
import { useState } from 'react';
import { definirVendasConfirmadas } from './helpers';

export default function Tables(){
    const {state: {produtos, vendas}} = useLocation();
    const [ vendasConfirmadas, setVendasConfirmadas ] = useState(definirVendasConfirmadas(produtos, vendas));

    return(
        <div>
            
        </div>
    );
}