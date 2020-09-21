<div class="titulo">Jo-Ken-Po</div>

<html>
<body>
<form action="#" method="POST">
    <p>Escolha um entre os três abaixo:</p>
    <h2>Pedra<input type="radio" value="pedra" name="turnoJogador"/><br />
       Papel<input type="radio" value="papel" name="turnoJogador"/><br />
       Tesoura<input type="radio" value="tesoura" name="turnoJogador"/><br />
    </h2>
    <p><input type="submit" style="font-size: 18px" value="Jogar"></p>
</form>
</body>
</html>

<?php
    if($_POST['turnoJogador']){

}

    else if(!$_POST['turnoJogador']){

}
        $turnoJogador = $_POST['turnoJogador'];
        $ppt= array('pedra', 'papel', 'tesoura');
        $rndm= rand(0,2);
        $Computador=$ppt[$rndm];

    echo '<h2>Sua escolha: '.$turnoJogador.'</h2>';
    echo '<br>';
    echo '<h2>Escolha do computador: '. $Computador .'</h2>';
    echo '<br>';
    if($turnoJogador == $Computador){
    }
    if ($turnoJogador == $Computador){
    echo '<h1>Empatou!</h1>';
    }
    else if($turnoJogador == 'pedra ' && $Computador == 'tesoura'){
    echo '<h1>Você Ganhou!</h1>';
}
    else if($turnoJogador == 'pedra' && $Computador == 'papel'){
    echo  '<h1>Você Perdeu!</h1>';
}
    else if($turnoJogador == 'tesoura' && $Computador == 'pedra'){
    echo  ' <h1>Você Perdeu!</h1> ';
}
    else if($turnoJogador == 'tesoura' && $Computador == 'papel'){
    echo '<h1>Você Ganhou!</h1>';
}
    else if($turnoJogador == 'tesoura' && $Computador == 'pedra'){
    echo '<h1>Você Ganhou!</h1>';
}
    else if($turnoJogador == 'papel' && $Computador == 'tesoura'){
    echo '<h1>Você Perdeu!</h1>' ;
}

?>

<hr>

<a href="http://dojopuzzles.com/problemas/exibe/jokenpo/" target="_blank">Página do Exercício</a></p>

<style>
    h1 {
        margin: 0px;
        font-weight: 350;
        font-size:  4.0rem;
    }

    h2 {
        margin: 0px;
        font-weight: 350;
        font-size:  2.0rem;
    }
</style>