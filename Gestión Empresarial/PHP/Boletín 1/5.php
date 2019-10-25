<?php
//Diseña una función que reciba un número entre 0 y 255 y lo devuelva en binario
    function numToBin(int $i){
        if(!($i < 0 || $i > 255)){
            return decbin($i);
        }
    }

    echo numToBin(156);
?>