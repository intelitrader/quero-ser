
let caixaEletronico = document.querySelector('#caixaEletronico');
let cedulas = new Image(150, 50)

function sacar(valorSaque) {
     let saqueCedulas = document.createElement('div')
     caixaEletronico.appendChild(saqueCedulas);
     valorSaque = document.querySelector('#valorSaque').value;
     if (valorSaque === '' ){
          window.alert('Digite um valor para saque!')

     }else{         
          let valor = Number(valorSaque);
          while (valor >= 100) {
               cedulas = new Image(150, 50)
               cedulas.setAttribute('class', 'cedulas')
               cedulas.src = 'acets/imagens/100reais.jpg'
               saqueCedulas.appendChild(cedulas);
               valor = valor - 100
          }
          while (valor >= 50) {
               cedulas = new Image(150, 50)
               cedulas.setAttribute('class', 'cedulas')
               cedulas.src = 'acets/imagens/50reais.jpg'
               saqueCedulas.appendChild(cedulas);
               valor = valor - 50
          }
          while (valor >= 20) {
               cedulas = new Image(150, 50)
               cedulas.setAttribute('class', 'cedulas')
               cedulas.src = 'acets/imagens/20reais.jpg'
               saqueCedulas.appendChild(cedulas);
               valor = valor - 20
          }
          while (valor >= 10) {
               cedulas = new Image(150, 50)
               cedulas.setAttribute('class', 'cedulas')
               cedulas.src = 'acets/imagens/10reais.jpg'
               saqueCedulas.appendChild(cedulas);
               valor = valor - 10
          }
     }
}
function novoSaque(){
     cedulas.parentNode.remove(cedulas);
     document.querySelector('#valorSaque').value = null;
     
}
