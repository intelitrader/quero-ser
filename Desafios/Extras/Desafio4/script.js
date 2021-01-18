//Velocidade máxima de até 70
// a cada 5KM acima do limite você perde 1 ponto
//caso pontos maior que 12 -> "Carteira Suspendida"
verificarVelocidade(15);

function verificarVelocidade(velocidade) {
    const VelocidadeMáxima = 70;
    const KmPorPonto = 5;
    const PontosCarteiraSuspendida = 12
    
    if(velocidade <= VelocidadeMáxima){
        return console.log('Ok')
    }
    else {
        const pontos = Math.floor((velocidade -VelocidadeMáxima)/KmPorPonto)
        if(pontos >= PontosCarteiraSuspendida)
        {
            console.log('Carteira Suspendida')
        }
        else {
            console.log('Pontos', pontos)
        }
    }
}