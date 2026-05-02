function menorTroco(valor, pago){
    let totalPago = (valor -  pago ) * - 1
    
    
    if(pago <= valor ){
        console.log("Voce não tem troco e ainda deve " + totalPago + " R$")
    }

    if(pago > valor){
         
        console.log(`O valor pago foi  de  ${pago} seu troco pode ser :  ` )
        let troco = parseInt(totalPago/ 100)
        console.log(`${troco} nota(s) de ${100},00`)
        totalPago = totalPago % 100

         troco = parseInt(totalPago/ 50)
         console.log(`${troco} nota(s) de ${50},00`)
         totalPago = totalPago % 50

         troco = parseInt(totalPago/ 10)
         console.log(`${troco} nota(s) de ${10},00`)
         totalPago = totalPago % 10
       
         troco = parseInt(totalPago/ 5)
         console.log(`${troco} nota(s) de ${5},00`)
         totalPago = totalPago % 5
        
         troco = parseInt(totalPago/ 1)
         console.log(`${troco} nota(s) de ${1},00`)
         totalPago = totalPago % 1

         troco = parseInt(totalPago/ 0.50)
         console.log(`${troco} nota(s) de 0,50`)
         totalPago = totalPago % 0.50

         troco = parseInt(totalPago/ 0.10)
         console.log(`${troco} nota(s) de 0,10`)
         totalPago = totalPago % 0.10
         

         troco =  parseInt(totalPago/ 0.05)
         console.log(`${troco} nota(s) de 0,05`)
         totalPago = totalPago % 0.05
         
         troco = parseInt(totalPago/ 0.01)
         console.log(`${troco} nota(s) de 0,01`)
         totalPago = totalPago % 0.01
     
    }



}

menorTroco(400,650.50);