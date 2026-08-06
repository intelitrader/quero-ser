<?php

/*
FizzBuzz
Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha, com as seguintes exceções:

Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;
Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.
*/

for ($cont=1; $cont<101; $cont++){
    echo "<br>";
    if(($cont % 3 == 0) || ($cont % 5 == 0)){
    if($cont % 3 == 0){
        echo "Fizz";
    }
    if($cont % 5 == 0){
        echo "Buzz";
    }
    }else{
        echo $cont;
    }
}


?>