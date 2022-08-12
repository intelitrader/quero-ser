let valor = prompt('Digite o valor a ser sacado');

let resto = Number(valor)

while(resto >= 100){
    document.write('<img style="width: 300px; margin-left: 10px;" src="img/100reis.jpg">')
    resto = resto - 100

}

while(resto >= 50){
    document.write('<img style="width: 300px; margin-left: 10px;" src="img/50reis.png">')
    resto = resto - 50

}

while(resto >= 20){
    document.write('<img style="width: 300px; margin-left: 10px;" src="img/20reis.jpg">')
    resto = resto - 20

}

while(resto >= 10){
    document.write('<img style="width: 300px; margin-left: 10px;" src="img/10reis.jpg">')
    resto = resto - 10

}