// fizzbuzz

for(let i = 0, l = 100; i < l; i++){
    // divisivel por 3
    if(i % 3 == 0){
      console.log('fizz')
    }
    // divisivel por 5
    else if(i % 5 == 0){
      console.log('buzz')
    }
    // divisivel por ambos
    else if(i % 3 == 0 && i % 5 == 0){
      console.log('fizzbuzz')
    }
    else{
      console.log(i)
    }
}