<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>

    <center>
        <h2>Registration Form</h2>
        <table>
            <form action="form.php" method="post">
                <tr>
                    <td>
                        <label>First Name:</label>
                    </td>
                    <td>
                        <input type="text" pattern="[A-Za-z]+" name="fname" placeholder="Required" required>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Middle Name:</label>
                    </td>
                    <td>
                        <input type="text" pattern="[A-Za-z]+" name="mname" placeholder="Optional">
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Last Name:</label>
                    </td>
                    <td>
                        <input type="text" pattern="[A-Za-z]+" name="lname" placeholder="Required" required>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="title">Choose Title:</label>
                    </td>
                    <td>
                        <input list="title_list" id="title" name="title" placeholder="Mr, Ms etc." /><br>
                        <datalist id="title_list">
                            <option value="Mr"></option>
                            <option value="Ms"></option>
                            <option value="Mrs"></option>
                            <option value="Sir"></option>
                            <option value="Prof"></option>
                            <option value="Doc"></option>
                        </datalist>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Age:</label>
                    </td>
                    <td align="right">
                        <input type="number" name="age" placeholder="Age" min="18" max="100" required >
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Email:</label>
                    </td>
                    <td>
                        <input type="email" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" name="email"
                            placeholder="Required" required>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Phone Number:</label>
                    </td>
                    <td>
                        <input type="tel" name="telnum" placeholder="000-0000-0000">
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Date of Arrival:</label>
                    </td>
                    <td>
                        <input type="date" name="date" placeholder="Required" required>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="submit" name="submit" value="Submit">
                    </td>
                </tr>
            </form>
        </table>
    </center>
</body>

</html>