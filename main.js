let valor = prompt("Digite o valor a ser sacado")

let resto = Number(valor)

while(resto >= 100){
  document.write('<img src = "C:/Users/prode/Desktop/Projetos/CaixaEletronico/img/100.jpg">')  
    resto = resto - 100
}

while(resto >= 50){
    document.write('<img src = "C:/Users/prode/Desktop/Projetos/CaixaEletronico/img/50_front.jpg">')  
      resto = resto - 50
  }

  while(resto >= 20){
    document.write('<img src = "C:/Users/prode/Desktop/Projetos/CaixaEletronico/img/20_front.jpg">')  
      resto = resto - 20
  }
  
  while(resto >= 10){
    document.write('<img src = "C:/Users/prode/Desktop/Projetos/CaixaEletronico/img/10_back.jpg">')  
      resto = resto - 10
  }

  if(resto > 0) {
        document.write("<br /><br />sobrou R$ "+resto.toFixed(2)+" , o valor será devolvido para a sua conta!")
  }