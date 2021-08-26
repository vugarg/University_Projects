<?php

include_once "db_connection.php";

$link = mysqli_connect($server, $user, $password, $database);
if (!$link)die("Connection to DB failed: " . mysqli_connect_error());

if (isset($_GET['semester'])){
    $clean_ID = intval(sanitize($link, $_GET["semester"]));
    $query =   "SELECT course_code, course_name, ects_credits, semester_name 
                FROM WT_13.semesters_vugafa 
                LEFT JOIN  WT_13.courses 
                ON WT_13.semesters_vugafa.ID = WT_13.courses.Semesters_ID 
                WHERE WT_13.semesters_vugafa.ID = '".$clean_ID."';";

} 

if (isset($_POST['search'])) {
    $clean_ID = intval(sanitize($link, $_GET["semester"]));
    $input = sanitize($link, $_POST["search"]);
    $query =   "SELECT course_code, course_name, ects_credits, semester_name 
                FROM WT_13.semesters_vugafa 
                LEFT JOIN  WT_13.courses 
                ON WT_13.semesters_vugafa.ID = WT_13.courses.Semesters_ID 
                WHERE WT_13.semesters_vugafa.ID = '".$clean_ID."' 
                AND WT_13.courses.course_name LIKE '%".$input."%' 
                OR WT_13.courses.course_code LIKE '%".$input."%'";
} 

if (isset($_GET['orderBy'])) {
    $clean_ID = intval(sanitize($link, $_GET["semester"]));
    $input = sanitize($link, $_POST["search"]);
    $clean_Order = sanitize($link, $_GET["orderBy"]);
    // $ascOrDesc = "ASC";

    $query =   "SELECT course_code, course_name, ects_credits, semester_name 
                FROM WT_13.semesters_vugafa 
                LEFT JOIN  WT_13.courses 
                ON WT_13.semesters_vugafa.ID = WT_13.courses.Semesters_ID 
                WHERE WT_13.semesters_vugafa.ID = '".$clean_ID."' 
                AND WT_13.courses.course_name LIKE '%".$input."%' 
                OR WT_13.courses.course_code LIKE '%".$input."%'
                ORDER BY ".$clean_Order." ;";
}


function listCourses($link,$query){

    $result = mysqli_query($link, $query);
        
        echo "<table>";
        echo "<tr>";
        echo  "<th><a href=\"?orderBy=course_code\">Code</a></th>";
        echo  "<th><a href=\"?orderBy=course_name\">Name</a></th>";
        echo  "<th><a href=\"?orderBy=ects_credits\">Credits</a></th>";
        echo  "<th><a href=\"?orderBy=semester_name\">Semester</a></th>";
        echo "</tr>";

    while($row = mysqli_fetch_array($result, MYSQLI_NUM)){
        echo "<tr>";
        echo "<td>" . $row[0] . "</td>";
        echo "<td>" . $row[1] . "</td>";
        echo "<td>" . $row[2] . "</td>";
        echo "<td>" . $row[3] . "</td>";
        echo "</tr>";
    }
}

function semesters($link){

    $query =   "SELECT ID, semester_name 
                FROM WT_13.semesters_vugafa 
                ORDER BY ID ";
    $result = mysqli_query($link, $query);

    while($row = mysqli_fetch_array($result, MYSQLI_NUM)){
        echo "<a href=\"?semester=".$row[0]."\">$row[1]</a>"; 
        echo "&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp";
    }
}

function sanitize($link,$var){
	$var = stripslashes($var);
	$var = htmlentities($var);
	$var = strip_tags($var);
	$var = mysqli_real_escape_string($link,$var);
	return $var; 
}


semesters($link);

echo "<br>";
echo "<br>";

echo "<form action='' method='post' id='search'>
        <label for='search'>Search by code or name:</label>
        <input type='text' id='search' name='search'>
        <button type='submit' form='search' value='Submit'>Filter</button>
      </form> ";   
    
listCourses($link,$query);

?>


