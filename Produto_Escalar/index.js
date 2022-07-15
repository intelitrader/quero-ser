// como pegar valores aleatorios de um array
function shuffle(array) {
    var currentIndex = array.length, randomIndex;

    // Enquanto ainda houver elementos para embaralhar
    while (0 !== currentIndex) {

        // Escolha um elemento restante
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex--;

        // E troque-o com o elemento atual.
        [array[currentIndex], array[randomIndex]] = [
            array[randomIndex], array[currentIndex]];
    }
    return array;
}

// Importa o mathjs que caulcula o produto escalar dos vetores
const math = require('mathjs');

function Calculo() {

    // Definição dos 2 vetores que serão utilizados
    let Vetor1 = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    let Vetor2 = [1, 2, 3, 4, 5, 6, 7, 8, 9];

    // Embaralhamento da posição dos numeros dentro do vetor
    shuffle(Vetor1);
    shuffle(Vetor2);

    // Mostra a sequencia dos vetores após embaralhamento
    console.log("A sequencia do Vetor1 é", Vetor1);
    console.log("A sequencia do Vetor2 é", Vetor2);

    // Mostra/Produz o resultado do produto escalar
    console.log("O Produto escalar é: ")
    console.log(math.dot(Vetor1, Vetor2));
}

Calculo();





