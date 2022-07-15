import { useLocation } from 'react-router-dom';
import { useState } from 'react';

export default function Tables(){
    const {state: {produtos, vendas}} = useLocation();
    const [ vendasConfirmadas, setVendasConfirmadas ] = useState([]);
    
    return(
        <div>
            
        </div>
    );
}