<?php
    function piramide($b){
        for($i = 0; $i <= 10; $i++){
            for($k = 0; $k < $b; $k++){
                echo "&nbsp";
            }
            for($j = 0; $j < 2 *$i - 1; $j++){
                echo "*";
            }
            $b--;
            echo "<br/>";
        }
    }
?>