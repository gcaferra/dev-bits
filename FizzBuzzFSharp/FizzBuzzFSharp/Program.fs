module Program

open FizzBuzz

[<EntryPoint>]
let  main _ =
    [1..100]
    |> List.map printNumber
    |> List.iter (printfn "%s")
    0
