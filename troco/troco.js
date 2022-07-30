const notas = [100,50,20,10,5,2,1,0.50,0.25,0.10,0.05];
const pago = 100
const compra = 45.20
let troco = (pago - compra);

function Troco(){
   arr = new Array();	
 	
   for (x in notas) {
       if (notas[x] > troco) continue;
       
       const lengthCedula = parseInt(troco / notas[x]);
       arr.push([lengthCedula, notas[x]]);
       
     troco = troco - (lengthCedula * notas[x]);
   }
   
   return arr;
}
console.log(Troco());