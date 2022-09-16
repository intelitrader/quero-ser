// Aqui está minhas soluções para os desafios DojoPuzzles: Intervalos, Buraco nas letras e Caixa Eletronico, respectivamente.

// Link para os desafios: 
// https://dojopuzzles.com/problems/intervalos/ 
// https://dojopuzzles.com/problems/buracos-nas-letras/
// https://dojopuzzles.com/problems/caixa-eletronico/

function intervalos(lista) {
    let retorno = []
    while (lista.length > 0) {
        let posicaoFim = 0
        for (let i = 0; i<lista.length; i++) {
            if (lista[i] != lista[i+1]-1) {  
                posicaoFim = i
                break
            }
        }
        listaRetorno = lista.slice(0,posicaoFim+1)
        if(listaRetorno[0] != listaRetorno.at(-1)){
            const temp1 = listaRetorno[0].toString()+'-'+listaRetorno.at(-1).toString()
            retorno.push([temp1])
        }else{
            const temp2 = listaRetorno[0].toString()
            retorno.push([temp2])
        }
        lista = lista.slice(posicaoFim+1)
    }
    let resultado = retorno.toString().split(",")
    for (let i = 0; i<resultado.length; i++) {
        resultado[i] = "["+resultado[i]+"]"
    }
    resultado = resultado.toString()
    return resultado
}

function buracos(text) {
    let letras = text.toUpperCase().split("")
    let valor = 0
    for (let i = 0; i<letras.length; i++) {
        if (letras[i] === "A") {
            valor += 1
        } else if (letras[i] === "B") {
            valor += 2
        } else if (letras[i] === "D") {
            valor += 1
        } else if (letras[i] === "O") {
            valor += 1
        } else if (letras[i] === "P") {
            valor += 1
        } else if (letras[i] === "Q") {
            valor += 1
        } else if (letras[i] === "R") {
            valor += 1
        } else if (letras[i] === "P") {
            valor += 1
        } 
    }
    return valor
}

function caixa(num) {
    let temCem = Math.floor(num / 100)
    let sobrouCem = num % 100
    let temCinc = Math.floor(sobrouCem / 50)
    let sobrouCinc = sobrouCem % 50
    let temVinte = Math.floor(sobrouCinc / 20)
    let sobrouVinte = sobrouCinc % 20
    let temDez = Math.floor(sobrouVinte / 10)
    let string = "Entregar"

    if (temCem > 0) {
        string = string.concat(` ${temCem} nota de 100`)
    } 
    if (temCinc > 0) {
        string = string.concat(` ${temCinc} nota de 50`)
    } 
    if (temVinte > 0) {
        string = string.concat(` ${temVinte} nota de 20`)
    }
    if (temDez > 0) {
        string = string.concat(` ${temDez} nota de 10`)
    }
    
    return string+"."
}