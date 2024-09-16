/* //Você está resolvendo este problema.
Este problema foi utilizado em 294 Dojo(s).

Se os números de 1 a 5 fossem escritos em palavras: um, dois, três, quatro, cinco, então teríamos utilizado 2 + 4 + 4 + 6 + 5 = 21 letras no total.

Se todos os números de 1 até 1000 fossem escritos em palavras, quantas letras nós teríamos utilizado? */


const palavras = "um, dois, três, quatro, cinco"

let reformada = ""
for (let item of palavras) {

    if (item !== "," && item !== " ") {
        reformada += item
    }
}

let array = reformada.split("")

console.log(array.length)