//Caixa Eletrônico - Dojo Puzzles - https://dojopuzzles.com/problems/caixa-eletronico/

const notas = [100, 50, 20, 10, 5, 2, 1, 0.5];

function sacar(quantidade: number): number[] {
  let troco = [] as number[];
  let restante = quantidade;

  notas.map((nota: number) => {
    if (restante !== 0) {
      if (nota <= restante) {
        const notasRepetidas = Math.trunc(restante / nota);

        for (let index = 0; index < notasRepetidas; index++) {
          troco.push(nota);
        }

        restante = restante % nota;
      }
    }
  });

  return troco;
}

//retorno [50, 20, 5, 2, 1]
const troco = sacar(78);
console.log(troco);
