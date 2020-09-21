<div class="titulo">Anagramas</div>

<form action="#" method="post">
    <div>
        <label for="entrada">Entrada</label>
        <input type="string" value=<?=$_POST['string'] ?? 'biro'?> name="string" id="string">
    </div>
    <button>Gerar Anagrama</button>
</form>

<style>
    form > * {
        font-size: 1.8rem;
    }
</style>

<?php

$str = (strval($_POST['string'])) ?? 'biro';

function anagrama($str,$i,$n) {
    if ($i == $n)
        print "$str<br>";
    else {
         for ($j = $i; $j < $n; $j++) {
           troca($str,$i,$j);
           anagrama($str, $i+1, $n);
           troca($str,$i,$j);
        }
    }
 }
 
 // função que troca o caractere entre as posições $i e $j da $str
     function troca(&$str,$i,$j) {
     $temp = $str[$i];
     $str[$i] = $str[$j];
     $str[$j] = $temp;
 }   
 
echo anagrama($str,0,strlen($str)); // chama a função. 
echo "<hr>";
?>

<a href="http://dojopuzzles.com/problemas/exibe/anagramas/" target="_blank">Página do Exercício</a></p>

<style>
    form * {
        font-size: 1.8rem;
    }
    
    form > div {
        margin-bottom: 10px;
    }

    table {
        border: 1px solid #444;
        border-collapse: collapse;
        margin: 20px 0px;
    }

    table tr {
        border: 1px solid #444;
    }

    table td {
        padding: 10px 20px;
    }
</style>