export default function cheque() {
  const inputValor = document.getElementById("cheque");
  const buttonValor = document.querySelector(".cheque-button");

  const unidades = [
    "zero",
    "um",
    "dois",
    "tres",
    "quatro",
    "cinco",
    "seis",
    "sete",
    "oito",
    "nove",
  ];
  const unicos = [
    "dez",
    "onze",
    "doze",
    "treze",
    "quatorze",
    "quinze",
    "dezesseis",
    "dezessete",
    "dezoito",
    "dezenove",
  ];
  const dezenas = [
    "",
    "dez",
    "vinte",
    "trinta",
    "quarenta",
    "cinquenta",
    "sessenta",
    "setenta",
    "oitenta",
    "noventa",
  ];
  const centenas = [
    "cem",
    "cento",
    "duzentos",
    "trezentos",
    "quatrocentos",
    "quinhetos",
    "seiscentos",
    "setecentos",
    "oitocentos",
    "novecentos",
  ];

  function constroiResultado(reaisExtenso, centavosExtenso) {
    const resultadoCheque = document.querySelector(".resultado-cheque");

    if (reaisExtenso == "um") {
      resultadoCheque.innerHTML = `${reaisExtenso} real e ${centavosExtenso} centavos`;
    } else {
      resultadoCheque.innerHTML = `${reaisExtenso} reais e ${centavosExtenso} centavos`;
    }
  }

  function mostraErro() {
    const resultadoCheque = document.querySelector(".resultado-cheque");

    resultadoCheque.innerHTML = "Digite o número válido";
  }

  function doisNumeros(numero) {
    if (numero[0] == 0) {
      return unidades[numero[1]];
    } else {
      if (numero[0] == 1) {
        return unicos[numero[1]];
      } else if (numero[1] == 0) {
        return dezenas[numero[0]];
      } else {
        return `${dezenas[numero[0]]} e ${unidades[numero[1]]}`;
      }
    }
  }

  function tresNumeros(numero) {
    if (numero[0] == 1 && numero[1] == 0 && numero[2] == 0) {
      return centenas[0];
    } else if (numero[0] == 0 && numero[1] == 0 && numero[2] == 0) {
      return "";
    } else if (numero[0] > 1 && numero[1] == 0 && numero[2] == 0) {
      return centenas[numero[0]];
    } else if (numero[0] == 0) {
      const retorno = doisNumeros(numero.replace(/^./, ""));
      return `${retorno}`;
    } else {
      const retorno = doisNumeros(numero.replace(/^./, ""));
      return `${centenas[numero[0]]} e ${retorno}`;
    }
  }

  function quatroNumeros(numero) {
    if (numero[1] == 0 && numero[2] == 0 && numero[3] == 0) {
      return `${unidades[numero[0]]} mil`;
    } else {
      const retorno = tresNumeros(numero.replace(/^./, ""));
      return `${unidades[numero[0]]} mil ${retorno}`;
    }
  }

  function cincoNumeros(numero) {
    const retorno1 = doisNumeros(numero.slice(0, 2));
    const retorno2 = tresNumeros(numero.slice(2));
    return `${retorno1} mil ${retorno2}`;
  }

  function seisNumeros(numero) {
    const retorno1 = tresNumeros(numero.slice(0, 3));
    const retorno2 = tresNumeros(numero.slice(3));
    return `${retorno1} mil ${retorno2}`;
  }

  function convertNumber() {
    const numeroInteiro = inputValor.value.split(",");
    const reais = numeroInteiro[0];
    const centavos = numeroInteiro[1];
    if (numeroInteiro.length === 1 || reais[0] == 0 || centavos.length < 2) {
      mostraErro();
    } else {
      const centavosExtenso = doisNumeros(centavos);

      if (reais.length === 1) {
        const reaisExtenso = unidades[reais];
        constroiResultado(reaisExtenso, centavosExtenso);
      } else if (reais.length === 2) {
        const reaisExtenso = doisNumeros(reais);
        constroiResultado(reaisExtenso, centavosExtenso);
      } else if (reais.length === 3) {
        const reaisExtenso = tresNumeros(reais);
        constroiResultado(reaisExtenso, centavosExtenso);
      } else if (reais.length === 4) {
        const reaisExtenso = quatroNumeros(reais);
        constroiResultado(reaisExtenso, centavosExtenso);
      } else if (reais.length === 5) {
        const reaisExtenso = cincoNumeros(reais);
        constroiResultado(reaisExtenso, centavosExtenso);
      } else if (reais.length === 6) {
        const reaisExtenso = seisNumeros(reais);
        constroiResultado(reaisExtenso, centavosExtenso);
      } else {
        mostraErro();
      }
    }
  }

  buttonValor.addEventListener("click", convertNumber);
}
