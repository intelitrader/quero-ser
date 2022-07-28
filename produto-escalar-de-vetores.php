<?php
/*
Produto Escalar de Vetores

Este problema foi utilizado em 163 Dojo(s).

Definimos dois vetores A e B de dimensão n em termos de componentes como:

A = (a1, a2, a3, ..., an) e B = (b1, b2, b3, ..., bn)

O produto escalar entre esses vetores é descrito como:

A . B = a1 * b1 + a2 * b2 + a3 * b3 + ... + an * bn

Desenvolva um programa que, dado dois vetores de dimensão n, retorne o produto escalar entre eles.
*/

//vetores utilizados
$a = array(1, 2, 3, 4, 5);
$b = array(5, 4, 3, 2, 1);
$soma = 0;

//calculo do produto  escalar de vetores
for($cont = 0; $cont < count($a); $cont++){
    $soma = $soma + ($a[$cont] * $b[$cont]);
}

echo $soma;
?>