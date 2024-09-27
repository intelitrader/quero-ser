     

       let lista = [];

     for(let i = 1; i <= 100; i++){
           lista.push(i)
        }

     for(let i = 0; i <= lista.length ; i++)  {

        if(lista[i] % 5 == 0 && lista[i] % 3 == 0){
            lista[i] = "FizzBuzz"
        }

        if(lista[i] % 5 == 0 ){
            
            lista[i] = "Buzz"
        }
        if(lista[i] % 3 == 0 ){
            
           lista[i] = "Fizz"
        }
      
        } 
    lista.forEach(valor => {
        console.log(valor)
    })