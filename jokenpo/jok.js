const pedra = document.getElementById("pedra");
const papel = document.getElementById("papel");
const tesoura = document.getElementById("tesoura")
const pc = document.getElementById("pc")
const result = document.getElementById("result")
const button = document.getElementById("button")
const reset = document.getElementById("zerar")

reset.addEventListener('click', ()=>{
    pc.innerText = "";
    result.innerText = "";
    location.reload()
    
})

button.addEventListener('click', ()=>{
  if(pedra.checked == false && tesoura.checked==false && papel.checked==false){
    alert('selecione uma opcão')
  }
  
  else{
    const sort = Math.floor(Math.random()*3)
    switch(sort){
      case 0: 
        pc.innerText= "pedra"
        break;
        
        case 1:
        pc.innerText= "papel"
        break;
        
        case 2: 
        pc.innerText= "tesoura"
        break;
      }
    
    if((pedra.checked == true && sort == 0) || 
     (papel.checked == true && sort == 0) || 
     (tesoura.checked == true && sort == 0)){
    result.innerText= "Empate!!"
  }
  
   else if((pedra.checked == true && sort == 2) || 
     (papel.checked == true && sort == 1) || 
     (tesoura.checked == true && sort == 0)){
        result.innerText= "Jogador venceu!!"
   } 
  else{
    result.innerText= "Computador venceu!!"
}
    
  }
  
})