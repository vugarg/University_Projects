<?php

$firstName = $_POST['fname'];
$lastName = $_POST['lname'];


if($_POST['mname']!= ""){
    $middleName =$_POST['mname'];
}

if($_POST['title']!=""){
    $salutation = $_POST['title'];
}

$telNum = $_POST['telnum'];
if($telNum == ""){
    $telNum = "undefined";
} elseif(!preg_match("/^[0-9]{3}-[0-9]{4}-[0-9]{4}$/", $telNum)) {
    die("wrong phone number format!");
} else{
    $telNum = $_POST['telnum'];
}

if($_POST['age'] < 17){
    die("You must older 18 or older!!");
} else{
    $age_t = $_POST['age'];
}

$email_t = $_POST['email'];
if (!filter_var($email_t, FILTER_VALIDATE_EMAIL)) {
    die("wrong email input");
} else {
    $email_t = $_POST['email'];
}



$dateOfArrival = "";
$date = $_POST['date'];
$array = explode("/",$date);

$day = $array[1];
$month = $array[0];
$year = $array[2];

if(checkdate($month, $day, $year)){
    $dateOfArrival = $_POST['date'];
} else {
    die("Enter correct date format: mm/dd/yyyy");
}
  

    
extract($_REQUEST);
$content = $firstName . ";" . $middleName . ";" . $lastName . ";" . $salutation . ";" . $age_t . ";" . $email_t . ";" . $telNum . ";" . $dateOfArrival . ";" . "\n" ;
$file = fopen("log.csv","a");
fwrite($file, $content);
fclose($file);

$linecount = count(file('log.csv'));


?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
<h1>Hello</h1>
<p><a href="log.csv">Download CSV file</a></p>


<?php

echo "The form was submited " . $linecount . " times";

?>
    
</body>
</html>
