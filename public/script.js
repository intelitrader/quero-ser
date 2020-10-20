// VISUALIZAÇÃO DOS DESAFIOS
const menu = document.querySelectorAll('.menu button');
const todosProblemas = document.querySelectorAll('.troco, .celular, .nuvem');


menu.forEach(btn => {
    btn.addEventListener('click', function(e) {
      ocultarProblemas();
      document.querySelector(`.${e.target.id}`).classList.remove('hidden');
      e.target.classList.add('active');
    })
})


function ocultarProblemas() {
  todosProblemas.forEach(problema => {
    problema.classList.add('hidden');
  });

  menu.forEach(btn => {
    btn.classList.remove('active');
  })
}










// PROBLEMA #1: TROCO
const trocoForm = document.querySelector('.troco-form');
const trocoResultado = document.querySelector('.troco-resultado');


trocoForm.addEventListener('submit', (e) => {
  e.preventDefault();

  const valorGasto = e.target.gasto.value.replace(/,/g, '.');
  const valorPago = e.target.pago.value.replace(/,/g, '.');
  const resultado = troco(valorGasto, valorPago);

  trocoResultado.innerHTML = '';

  resultado.forEach(resultadoLinha => {
    const elemento = document.createElement('p');
    elemento.innerText = resultadoLinha;
    trocoResultado.appendChild(elemento);
  })
});


function troco(valorGasto, valorPago) {
  const dinheiro = [10000, 5000, 1000, 500, 100, 50, 10, 5, 1];
  const troco = (parseFloat(valorPago) * 100) - (parseFloat(valorGasto) * 100);
  const resultadoNumero = [];
  const resultadoTexto = [];
  
  dinheiro.reduce((acumulador, valor) => {
    const quantidade = acumulador >= valor ? Math.floor(acumulador / valor) : 0;
    resultadoNumero.push(quantidade);
    return acumulador - valor * quantidade;
  }, troco);

  resultadoNumero.forEach((valor, indice) => {
    const dinheiro = [100, 50, 10, 5, 1, 0.50, 0.10, 0.05, 0.01];
    const moeda = dinheiro[indice] === 0.01 ? 'centavo' : 'centavos';
    const nota = dinheiro[indice] === 1 ? 'real' : 'reais';
    const tipoValor = dinheiro[indice] >= 1 ? nota : moeda;
    const tipoCedulas = dinheiro[indice] >= 1 ? 'nota' : 'moeda';
    const tipoCedulasPlural = valor > 1 ? tipoCedulas + 's' : tipoCedulas;
    const dinheiroPrecisao = dinheiro[indice] < 1 ? dinheiro[indice] * 100 : dinheiro[indice];

    valor > 0 && resultadoTexto.push(`${valor} ${tipoCedulasPlural} de ${dinheiroPrecisao} ${tipoValor}.`);
  })

  return resultadoTexto;
}










// PROBLEMA #2: ESCREVENDO NO CELULAR
// CODIFICA UMA MENSAGEM DE TEXTO
const inputText = document.querySelector('#text-to-number');
const resultadoText = document.querySelector('.celular-resultado-text');


inputText.addEventListener('input', (e) => {
  const resultado = textToNumber(e.target.value);
  resultadoText.innerText = resultado;
});


function textToNumber(frase) {
  const alfabeto = [' ', '?', 'ABC', 'DEF', 'GHI', 'JKL', 'MNO', 'PQRS', 'TUV', 'WXYZ'];
  const fraseSplit = frase.toUpperCase().split('');
  let fraseCodificada = '';

  fraseSplit.forEach(caracter => {
    const numero = (alfabeto.findIndex(letra => letra.includes(caracter))).toString();
    const quantidade = alfabeto[numero].indexOf(caracter) + 1;

    fraseCodificada.endsWith(numero) && (fraseCodificada += '_');
    fraseCodificada += numero.repeat(quantidade);
  })
  
  return fraseCodificada;
}


// DECODIFICA UMA MENSAGEM
const inputNumber = document.querySelector('#number-to-text');
const resultadoNumber = document.querySelector('.celular-resultado-number');


inputNumber.addEventListener('input', (e) => {
  const resultado = numberToText(e.target.value);
  resultadoNumber.innerText = resultado;
})


function numberToText(frase) {
  const alfabeto = [' ', '?', 'ABC', 'DEF', 'GHI', 'JKL', 'MNO', 'PQRS', 'TUV', 'WXYZ'];
  const fraseSplit = frase.split('');
  let fraseDecodificada = '';
  let quantidade = 0;

  fraseSplit.forEach((caracter, indice) => {
    const valorIndice = alfabeto[Number(caracter)];
    let caracterIndice = caracter === '_' ? -1 : Number(fraseSplit[indice + 1]);
    if (caracter === '_') {
      quantidade = 0;
    } else {
      if (Number(caracter) == caracterIndice) {
        quantidade++;
      } else {
        fraseDecodificada += `${valorIndice[quantidade]}`;
        quantidade = 0;
      }
    }
  })

  return fraseDecodificada;
}










// PROBLEMA #3: NUVEM DE CINZAS
const nuvemForm = document.querySelector('.nuvem-form');
const nuvemResultado = document.querySelector('.nuvem-resultado');
const nuvemResultadoTexto = document.querySelector('.nuvem-resultado-texto');


nuvemForm.addEventListener('submit', (e) => {
  e.preventDefault();

  const colunas = e.target.colunas.value;
  const linhas = e.target.linhas.value;
  const nuvens = e.target.nuvens.value;
  const aeroportos = e.target.aeroportos.value;
  
  nuvemResultado.innerHTML = '';
  nuvemResultadoTexto.innerHTML = '';
  nuvemDeCinzas(colunas, linhas, nuvens, aeroportos);
});


function nuvemDeCinzas(colunas, linhas, nuvens, aeroportos) {
  let mapa = [];
  let totalDias = 0;
  
  for (let i = 0; i < linhas; i++) {
    mapa.push([]);
    for (let j = 0; j < colunas; j++) {
      mapa[i].push('o');
    }
  }
 
  estadoInicial(aeroportos, nuvens, mapa, colunas, linhas, totalDias);
  espalharNuvens(mapa, totalDias, aeroportos, true, true);
}


function espalharNuvens(mapa, totalDias, aeroportos, primeiroAeroporto, ultimoAeroporto) {
  const mapaTemp = [];
  let totalAeroportos = 0;

  mapa.forEach(linha => {
    const info = [...linha];
    mapaTemp.push(info);
  })

  for (let i = 0; i < mapaTemp.length; i++) {
    for (let j = 0; j < mapaTemp[i].length; j++) {
      if(mapa[i][j] === '*') {
        if (mapaTemp[i][j - 1]) mapaTemp[i][j - 1] = '*';
        if (mapaTemp[i][j + 1]) mapaTemp[i][j + 1] = '*';
        if (mapaTemp[i - 1]) mapaTemp[i - 1][j] = '*';
        if (mapaTemp[i + 1]) mapaTemp[i + 1][j] = '*';
      }
    }
  }

  totalDias++;
  
  viewMap(mapaTemp, totalDias);

  mapaTemp.forEach( linha => {
    linha.forEach(item => {
      item === 'A' && totalAeroportos++;
    })
  })
  
  const espalharNuvensRepetir = mapaTemp.some(linha => {
    const cond = linha.some(item => item === 'o' || item === 'A');
    return cond;
  });
  
  if (aeroportos - totalAeroportos > 0 && primeiroAeroporto) {
    const elemento = document.createElement('p');
    elemento.innerText = `O primeiro aeroporto ficou encoberto no dia: ${totalDias}.`;
    nuvemResultadoTexto.appendChild(elemento);
    primeiroAeroporto = false;
  }

  if (aeroportos - totalAeroportos == aeroportos && ultimoAeroporto) {
    const elemento = document.createElement('p');
    elemento.innerText = `O último aeroporto ficou encoberto no dia: ${totalDias}.`;
    nuvemResultadoTexto.appendChild(elemento);
    ultimoAeroporto = false;
  }

  if (!espalharNuvensRepetir) {
    const elemento = document.createElement('p');
    elemento.innerText = `O mapa inteiro ficou encoberto no dia: ${totalDias}.`;
    nuvemResultadoTexto.appendChild(elemento);
  }
  
  espalharNuvensRepetir && espalharNuvens(mapaTemp, totalDias, aeroportos, primeiroAeroporto, ultimoAeroporto);
  totalAeroportos = 0;
}


function viewMap(mapa, totalDias) {
  const container = document.createElement('table');
  const texto = document.createElement('p');
  texto.innerText = `Dia: ${totalDias}`;

  mapa.forEach( (linha, indiceLinha) => {
    const elementoLinha = document.createElement('tr');
    
    linha.forEach((item, indiceItem) => {
      const elementoItem = document.createElement('td');
      elementoItem.innerText = mapa[indiceLinha][indiceItem];
      elementoLinha.appendChild(elementoItem);
    });

    container.appendChild(elementoLinha);
  });

  nuvemResultado.appendChild(texto);
  nuvemResultado.appendChild(container);
}


function estadoInicial(aeroportos, nuvens, mapa, colunas, linhas, totalDias) {
  inserirElemento(aeroportos, mapa, 'A', colunas, linhas);
  inserirElemento(nuvens, mapa, '*', colunas, linhas);
  viewMap(mapa, totalDias);
}


function inserirElemento(condicao, mapa, caracter, colunas, linhas) {
  for (let i = 0; i < condicao; i++) {
    let posicao = posicaoRandomSemDuplicados(colunas, linhas, mapa);
    mapa[posicao[0]][posicao[1]] = caracter;
  }
}


function posicaoRandomSemDuplicados(colunas, linhas, mapa) {
  let posicao = posicaoRandom(colunas, linhas);
  
  while (mapa[posicao[0]][posicao[1]] !== 'o') {
    posicao = posicaoRandom(colunas, linhas);
  }

  return posicao;
}


function posicaoRandom(colunas, linhas) {
  const posicaoX = random(0, linhas);
  const posicaoY = random(0, colunas);
  return [posicaoX, posicaoY];
}


function random(min, max) {
  return Math.floor(Math.random() * (max - min) ) + min;
}
