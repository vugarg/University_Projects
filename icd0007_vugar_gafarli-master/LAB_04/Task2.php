<?php

include "incl/phonics.php";
$file = file_get_contents("data/text.txt", "r+");

$resultArr = [];

function phonicsCount($file, $vowels){
    $fileUpper = strtoupper($file);
    $lenghtOfText = strlen($file);
    $counterA = 0;
    $counterE = 0;
    $counterI = 0;
    $counterO = 0;
    $counterU = 0;
    
    for ($i = 0; $i < $lenghtOfText; $i++) {
        if ($fileUpper[$i] == $vowels[0]){
            $counterA ++ ;
        } elseif ($fileUpper[$i] == $vowels[1]){
            $counterE ++ ;
        } elseif ($fileUpper[$i] == $vowels[2]){
            $counterI ++ ;
        } elseif ($fileUpper[$i] == $vowels[3]){
            $counterO ++ ;
        } elseif ($fileUpper[$i] == $vowels[4]){
            $counterU ++ ;
        }
    }

    return $vowelsArr = ["A" => "$counterA",
                "E" => "$counterE",
                "I" => "$counterI",
                "O" => "$counterO",
                 "U" => "$counterU",] ;
}

function noWhiteSpaces($file){
    $abc = preg_replace("/\s+/", "", $file);
    return strlen($abc);

}



function linesCount($file) {
    $counterLine = 0;
    $arrText = str_split($file);
    foreach ($arrText as $char) {
        if ($char == "\n") {
            $counterLine++;
        }
    }
    return $counterLine;
}


print_r(phonicsCount($file, $vowels));

printf(noWhiteSpaces($file));

printf(linesCount($file));

?>