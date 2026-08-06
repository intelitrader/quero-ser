export default function caixa() {
  const inputCaixa = document.getElementById("valor");
  const buttonCaixa = document.querySelector(".caixaEletronico__button");
  const valorInvalido = document.querySelector(".valorInvalido");

  function mostraResultado(notas) {
    valorInvalido.innerHTML = "";
    const resultadoCaixa200 = document.querySelector(".resultado-caixa200");
    const resultadoCaixa100 = document.querySelector(".resultado-caixa100");
    const resultadoCaixa50 = document.querySelector(".resultado-caixa50");
    const resultadoCaixa20 = document.querySelector(".resultado-caixa20");
    const resultadoCaixa10 = document.querySelector(".resultado-caixa10");

    resultadoCaixa200.innerHTML = `${notas.nota200} de R$ 200,00`;
    resultadoCaixa100.innerHTML = `${notas.nota100} de R$ 100,00`;
    resultadoCaixa50.innerHTML = `${notas.nota50} de R$ 50,00`;
    resultadoCaixa20.innerHTML = `${notas.nota20} de R$ 20,00`;
    resultadoCaixa10.innerHTML = `${notas.nota10} de R$ 10,00`;
  }

  function sacarDinheiro() {
    let valorSacar = inputCaixa.value;
    let notas = {
      nota200: "0",
      nota100: "0",
      nota50: "0",
      nota20: "0",
      nota10: "0",
    };

    if (valorSacar % 10 === 0 && valorSacar >= 10) {
      while (valorSacar >= 10) {
        if (valorSacar >= 200) {
          notas.nota200 = Math.floor(valorSacar / 200);
          valorSacar = valorSacar - 200 * notas.nota200;
        } else if (valorSacar >= 100) {
          notas.nota100 = Math.floor(valorSacar / 100);
          valorSacar = valorSacar - 100 * notas.nota100;
        } else if (valorSacar >= 50) {
          notas.nota50 = Math.floor(valorSacar / 50);
          valorSacar = valorSacar - 50 * notas.nota50;
        } else if (valorSacar >= 20) {
          notas.nota20 = Math.floor(valorSacar / 20);
          valorSacar = valorSacar - 20 * notas.nota20;
        } else if (valorSacar >= 10) {
          notas.nota10 = Math.floor(valorSacar / 10);
          valorSacar = valorSacar - 10 * notas.nota10;
        }
      }
      mostraResultado(notas);
    } else {
      valorInvalido.innerHTML = "Somente números terminados em 0";
    }
  }

  buttonCaixa.addEventListener("click", sacarDinheiro);
}
