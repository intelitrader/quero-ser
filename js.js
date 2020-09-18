

   
function controle(num,k){
    k = k-1;
    if(num == 0){
        var valor = document.getElementsByTagName("input");
            valor[k].getAttribute("id");
            valor[k].setAttribute('value','*');
            alert("VOCÊ PERDEU!")
                 
       
          
    }
    
   else{
        var valor = document.getElementsByTagName("input");
        valor[k].getAttribute("id");
        valor[k].setAttribute('value',num);

    }
}