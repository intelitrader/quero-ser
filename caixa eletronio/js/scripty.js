let valor = prompt("Qual valor você gostaria de sacar");

let resto = Number(valor)

function pulaLinha() {

    document.write("<br><br>");
}
pulaLinha();
while(resto >= 100){
    document.write(' <img width="300px" heigth="130px" src="img/100.jpg">')
    resto = resto -100
}
while (resto >= 50) {
    document.write(' <img  width="300px"  heigth="130px" src="img/50.jpg">')
    resto = resto - 50
}

while (resto >= 20) {
    document.write(' <img  width="300px"  heigth="130px" src="img/20.jpg">')
    resto = resto - 20
}

while (resto >= 10) {
    document.write(' <img  width="300px"  heigth="130px" src="img/10.jpg">')
    resto = resto - 10
    
}
pulaLinha();
if (resto > 5) {
    
    document.write("Valores "+resto+" abaixo de R$5,00 e cédulas de R$200,00 estão indisponíveis")
   
}
