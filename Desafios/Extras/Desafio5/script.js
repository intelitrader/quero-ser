//Criar uma função somar que retorna a
//soma de todos os múltiplos de 3 e 5
somar (10);
function somar (limite) {
    let multiploDe3 = 0;
    let multipoDe5 = 0;
    for (i =0; i <= limite; i++){
        if(i % 3 === 0)
            multiplosDe3 += i;
            if(i % 5 === 0)
            multiplosDe5 += i;
    }
    console.log(multiplosDe3 + multiplosDe5);
}