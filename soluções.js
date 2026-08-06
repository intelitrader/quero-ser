// POR FAVOR DESCOMENTAR SOMENTE O CÓDIGO A SER EXECUTADO

// 1. Vai Um

// function vaiUm(num1, num2){
//     let digito1 = (""+num1).split("")
//     let digito2 = (""+num2).split("")
//     let c=0

//     for(let i=0; i<digito1.length; i++){
//         let soma = parseInt(digito1[i]) + parseInt(digito2[i])
//         if(soma >= 10){
//             c++
            
//         }
//     }console.log(c)
// }
// vaiUm(123, 594)

//

// 2. geração de fatores primos

// function FatorPrimo(num){
//     let inicial = num
//     let fatores =[]
//     let divisor = 2

//     while(num >= 2){
//         if(num % divisor == 0){
//             fatores.push(divisor)
//             num = num / divisor;
//         }else{
//             divisor++
//         }

//     }console.log(inicial +' = ', fatores.join(' x '))

// }

// FatorPrimo(100)

//

// 3. Distribuição de Mictórios

// function Mictorio(quantidade, ...ocupados){
//     let realOcupados =[]
//     for(let j= 0; j<ocupados.length; j++){
//         realOcupados.push(ocupados[j])
//         realOcupados.push(ocupados[j]+1)
//         realOcupados.push(ocupados[j]-1)
//     }
    
//     for(let i = 0; i <= quantidade; i++){
        
//         if(i>=1){
//             if(realOcupados.indexOf(i) === -1){
//              if(ocupados.indexOf(i-1) || ocupados.indexOf(i+1) !== -1){
//                 console.log(i+" :livre")
//              }else{
//                 console.log(i+" :ocupado")
//              }
            
//             }
//     }
// }
// }

// Mictorio(20, 5,7,10)