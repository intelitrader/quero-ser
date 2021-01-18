// Jokenpo é uma brincadeira japonesa, onde dois jogadores escolhem um dentre três possíveis itens: Pedra, Papel ou Tesoura.

// O objetivo é fazer um juiz de Jokenpo que dada a jogada dos dois jogadores informa o resultado da partida.

// As regras são as seguintes:

// Pedra empata com Pedra e ganha de Tesoura
// Tesoura empata com Tesoura e ganha de Papel
// Papel empata com Papel e ganha de Pedra



const pedra = 'Pedra';
const papel = "Papel";
const tesoura = "Tesoura";

const escolha1 = "Escolha1";
const escolha2 = "Escolha2";




function Jokenpo(value1, value2) {
    if (value1 === value2) {
        if (value1 === pedra || value1 === papel || value1 === tesoura) {
            console.log('Empate')
        }
        else if (value2 === pedra || value2 === papel || value2 === tesoura) {
            console.log("Empate")
        }
    }
    if (value1 !== value2) {
        if (value1 !== papel && value2 !== papel) {
            console.log('Pedra venceu')
        }
        if (value1 !== pedra && value2 !== pedra) {
            console.log('Tesoura venceu')
        }
        if (value1 !== tesoura && value2 !== tesoura) {
            console.log('Papel venceu')
        }
    }
}
const resultado = Jokenpo(pedra, papel)
console.log(resultado);