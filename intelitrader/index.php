<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@200;300;400;500;600;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="assets\css\estilo.css">
    <title>DojoPuzzles - Intelitrader</title>
</head>
<body>
    <header class="cabecalho">
        <h1>DojoPuzzles - Intelitrader</h1>
        <h2>Índice dos Exercícios</h2>
    </header>
    <main class="principal">
        <div class="conteudo">
            <nav class="modulos">
                <div class="modulo azul-escuro">
                    <h3>1. Jo-Ken-Po</h3>
                    <ul>
                    <li><a href="exercicio.php?dir=exercicios&file=jokenpoIntelitrader">Jo-Ken-Po</a></li>
                    </ul>
                </div>
                <div class="modulo roxo-escuro">
                    <h3>2. Matriz Espiral</h3>
                    <ul>
                    <li><a href="exercicio.php?dir=exercicios&file=matrizespiralIntelitrader">Matriz Espiral</a></li>
                    </ul>
                </div>
                <div class="modulo verde-escuro">
                    <h3>3. Anagramas</h3>
                    <ul>
                    <li><a href="exercicio.php?dir=exercicios&file=anagramIntelitrader">Anagramas</a></li>
                    </ul>
                </div>
            </nav>
        </div>
    </main>
    <footer class="rodape">
        LUCAS SILVA © <?= date('Y'); ?>
    </footer>
</body>
</html>