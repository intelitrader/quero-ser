    // LINK DO PROBLEMA: http://dojopuzzles.com/problemas/exibe/analisando-a-conjectura-de-collatz/  
    
    var sequenciaAtual;
    var sequenciaAnterior = 0;
    var numeroSequencia = 0;

    for (var i = 1; i <= 1000000; i++){
        n = i;
        var contador = 1;
        while (n > 1){
            if (n%2 == 0){
                n = n/2;
                contador++;
            } else if (n%2 > 0){
                n = 3*n + 1;
                contador++;
            }
        }
        sequenciaAtual = contador;
        if (sequenciaAtual > sequenciaAnterior) {
            sequenciaAnterior = sequenciaAtual;
            numeroSequencia = i;
        } else if (sequenciaAtual < sequenciaAnterior){
            sequenciaAnterior = sequenciaAnterior;
        }
        continue;
    }

    console.log("O número com maior sequência é: " +
                numeroSequencia + ", com uma sequência de: " +
                sequenciaAnterior + " números.");

