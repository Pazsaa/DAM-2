<!DOCTYPE html>
<!--
Realiza una función que dibuje un cuadrado de N elementos de lado utilizando *
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title></title>
    </head>
    <body>
        <?php
            function cuadrado($n){
                for($j = 0; $j < $n; $j++){
                    for($i = 0; $i < $n; $i++){
                        echo "*";
                    }
                    echo "<br>";
                }
            }
            
            cuadrado(4);
        ?>
    </body>
</html>