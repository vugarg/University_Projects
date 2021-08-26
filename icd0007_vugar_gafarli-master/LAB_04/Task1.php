<?php 
    error_reporting(E_ALL);
    const KM_TO_MILES = 1.60934;

    $numOfDistances = rand(5,20);
    $arrDistances = [];

    $arrMiles = [];

    for ($i = 0; $i <= $numOfDistances; $i++){
        array_push($arrDistances, rand(1,100));
    }

    $sortedArr = $arrDistances;
    sort($sortedArr);
    $temp = 0;
    
    for($i = 0; $i < sizeof($arrDistances); $i++ ){
		if( ($i < sizeof($arrDistances) -1) && ($arrDistances[$i] == $arrDistances[$i+1]) ){
            if($temp){
				$key = strval( $arrDistances[$i]) . chr(64 + $temp);
			} else {
				$key = strval( $arrDistances[$i]);
			}
			$temp++;

		} else {
			if($temp){
				$key = strval( $arrDistances[$i]) . chr(64 + $temp);
			} else {
			    $key = strval( $arrDistances[$i]);
			}
			$temp = 0;
		}
		$arrMiles[$key] = $arrDistances[$i] * KM_TO_MILES;
	}

    function getKey($testKey, &$arr)
	{
		if (array_key_exists($testKey, $arr))
		{
			echo("\n". $arr[$testKey]);
			$value = $arr[$testKey];

			return $value;
		}
	}



    print_r($arrDistances);
   
    print_r($sortedArr);
    
    ksort($arrMiles);
    print_r($arrMiles);
   
    printf("KM \t Miles \n");
    foreach($arrMiles as $km => $miles) {
        printf("%s \t %0.3f \n",$km ,$miles);
    }

    getKey("10" ,$arrMiles);


?>

