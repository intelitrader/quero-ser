<?php

/*
Quebra de Linha

Este problema foi utilizado em 191 Dojo(s).

Escreva um programa em que dado uma frase e a quantidade de colunas que podem ser exibidas na tela, faça a quebra de linhas sem quebrar as palavras.

Por exemplo, se passarmos a frase "Um pequeno jabuti xereta viu dez cegonhas felizes." e pedirmos para ela ser exibida em 20 colunas, teremos como resposta:

Um pequeno jabuti

xereta viu dez

cegonhas felizes.
*/

//frase utilizada
$texto = "Um pequeno jabuti xereta viu dez cegonhas felizes.";

//contagem do numero de palavras
$limite = str_word_count($texto);

//divisão das palavras da frase
$divide = explode(" ", $texto, $limite);

//contador de colunas por linhas
$col = 0;

//percorre a frase contando quantas palavras cabem por linha
for ($cont = 0; $cont < $limite;){

    $col = $col + strlen($divide[$cont]) + 1;
    if ($col < 20){
        echo $divide[$cont]." ";
        $cont = $cont + 1;
    }else{
        //efetua a quebra da linha
        echo "<br>";
        $col = 0;
    }

}
?>