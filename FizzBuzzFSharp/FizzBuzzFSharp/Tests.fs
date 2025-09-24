module Tests
open Xunit
open FizzBuzz

[<Fact>]
let ``Passing 1 will return 1`` () =
  let result =  printNumber 1
  Assert.Equal( "1", result)
  
[<Fact>]
let ``Passing 3 will return Fizz`` () =
  let result =  printNumber 3
  Assert.Equal( "Fizz", result)

[<Fact>]
let ``Passing 5 will return Buzz`` () =
  let result =  printNumber 5
  Assert.Equal( "Buzz", result)
  
[<Fact>]
let ``Passing 15 will return FizzBuzz`` () =
  let result =  printNumber 15
  Assert.Equal( "FizzBuzz", result)

[<Fact>]
let ``Passing 30 will return FizzBuzz`` () =
  let result =  printNumber 30
  Assert.Equal( "FizzBuzz", result)