function caixaEletronico(){
    const saque = prompt("Digite o valor a ser sacado:")
    let valorSaque = Number(saque)
    let notas = []
    
    while(valorSaque >= 100){
        notas.push('cédula de 100')
        valorSaque = valorSaque - 100
    }
    
    while(valorSaque >= 50){
        notas.push('cédula de 50')
        valorSaque = valorSaque - 50
    }
    
    while(valorSaque >= 20){
        notas.push('cédula de 20')
        valorSaque = valorSaque - 20
    }
    
    while(valorSaque >= 10){
        notas.push('cédula de 10')
        valorSaque = valorSaque - 10
    }
    
    alert(notas)
}

caixaEletronico()