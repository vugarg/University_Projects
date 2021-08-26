# ICS0014 Project 2

This is ICS0014_2021 Project 2 by team_01

## Calculator API

* Calculator API with different GET methods : /calculate1 and /calculate2.
* Calculate 1 will calculate Max, MinEven, Odds
* Calculate 2 will calculate MinEven, PowerOf4, AverageOfOdd.

## Example

```
GET /calculator/calculate1?inputs=1,2,3
GET /calculator/calculate2?inputs=1,2,3
```  
Response of calculator1 with input 1,2,3
```
{
    max: 3,
    minEven: 2,
    odds: [1,3]
}
```
Response of calculator2 with input 1,2,3

```
{
    minEven: 2,
    powerOf4: [1,16,81],
    averageOfOdd: 2
}
```
## Logger Info

When GET request is sent to the server, You'll see the logger.info "Request accepted" on console log

## Built With

* [Java](https://www.java.com/en/) - Programming language
* [Gradle](https://gradle.org/) - Dependency Management

## Authors

* **Vugar Gafarli**
* **Rashad Gafarli**

## Acknowledgments

* This is course project for Taltech
* Please do not use this project for any illegal activities.