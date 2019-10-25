<!DOCTYPE html>
<!--
Dado un número cualquiera comprendido entre 1 y 10, crea su tabla de multiplicar.
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title></title>
    </head>
    <body>
        <?php
            $num = 10;

            if($num > 0 && $num <= 10){
                for($i = 0; $i <= 10 ; $i++){
                    echo $num * $i;
                    echo "<br>";
                }
            }
        ?>
    </body>
</html>

