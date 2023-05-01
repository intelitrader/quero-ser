
import fs from 'fs' ;

export function vendasC1() {

    // var fs = require('fs');
    
    try {  
        var data = fs.readFileSync('./Entrada/c1_vendas.txt', 'utf8');
        return data.toString();    
    } catch(e) {
        return console.log('Error:', e.stack);
    }

}

export function vendasC2() {

    // var fs = require('fs');
    
    try {  
        var data = fs.readFileSync('./Entrada/c2_vendas.txt', 'utf8');
        return data.toString();    
    } catch(e) {
        return console.log('Error:', e.stack);
    }

}