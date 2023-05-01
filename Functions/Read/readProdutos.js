import fs from 'fs' ;

export function produtosC1() {

    try {  
        var data = fs.readFileSync('./Entrada/c1_produtos.txt', 'utf8');
        return data.toString();    
    } catch(e) {
        console.log('Error:', e.stack);
    }

}

export function produtosC2() {

    try {  
        var data = fs.readFileSync('./Entrada/c2_produtos.txt', 'utf8');
        return data.toString();    
    } catch(e) {
        console.log('Error:', e.stack);
    }

}