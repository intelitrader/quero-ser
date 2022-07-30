
const min = 1
const max = 100

for(var i = min; i <= max; i++){
  
  if(i % 3 == 0){
   console.log(i + "-" +"fizz")
}
  else if(i % 5 == 0){
    console.log(i + "-" +"buzz")
}
  
  if(i % 3 == 0 && i % 5 == 0){
       console.log(i + "-" +"fizzbuzz")
  } else{
    console.log(i)
  }
 
}