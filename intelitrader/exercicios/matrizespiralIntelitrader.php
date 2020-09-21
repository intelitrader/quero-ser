<div class="titulo">Matriz Espiral</div>

<form action="#" method="post">
    <div>
        <label for="linhas">Linhas</label>
        <input type="number" value=<?=$_POST['linhas'] ?? 4?> name="linhas" id="linhas">
    </div>
    <div>
        <label for="colunas">Colunas</label>
        <input type="number" value=<?=$_POST['colunas'] ?? 4?> name="colunas" id="colunas">
    </div>
    <button>Gerar Tabela</button>
</form>


<table>
    <?php 
        //Preenche a[z][x] com os valores de 1 para
        // m*n em espiral
        function matrizEspiral($fl, $fc, &$a) {
            $val = 1;

            /* fl - index final da linha
            fc - index final da coluna
            il - index inicial da linha
            ic - index inicial da coluna*/

            $il = 0;
            $ic = 0;
            while($il < $fl && $ic < $fc)
            {
                /* Print the first row from 
                the remaining rows */
                for ($i = $ic; $i < $fc; ++$i)
                    $a[$il][$i] = $val++;
                $il++;
                
                /* Print the last column from 
                the remaining columns */
                for ($i = $il; $i < $fl; ++$i)
                    $a[$i][$fc - 1] = $val++;
                $fc--;

                /* Print the last row from  
                the remaining rows */
                if($il < $fl)
                {
                    for ($i = $fc - 1; $i >= $ic; --$i)
                        $a[$fl - 1][$i] = $val++;
                    $fl--;
                }

                /* Print the first column from 
                the remaining columns */

                if($ic < $fc)
                {
                    for($i = $fl - 1; $i >= $il; --$i)
                        $a[$i][$ic] = $val++;
                    $ic++;
                }
            }
        }
        
        //Gerador tabela
        $fl = (intval($_POST['linhas'])) ?? 4;
        $fc = (intval($_POST['colunas'])) ?? 4;
        matrizEspiral($fl, $fc, $a);
        for($i=0;$i<$fl;$i++){
            echo "<tr>";
            for($j=0;$j<$fc;$j++){
                echo "<td>" . ($a[$i][$j]) . "</td>";
                echo(" ");
            }
            echo ("</tr>");
        }
    ?> 
</table>

<hr>

<a href="http://dojopuzzles.com/problemas/exibe/matriz-espiral/" target="_blank">Página do Exercício</a></p>

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