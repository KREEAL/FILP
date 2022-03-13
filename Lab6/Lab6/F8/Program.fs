// Learn more about F# at http://fsharp.org

open System

let rec readList n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToInt32
    let Tail = readList (n-1)
    Head::Tail

    
let sigmaInterval list a b =
    let rec sigmaInterval_inside list a b sum = 
        match list with
        |[]-> sum
        |h::t->
               let newSum = 
                    if h > a && h < b then 
                        sum + h 
                    else 
                        sum
               sigmaInterval_inside t a b newSum 
    sigmaInterval_inside list a b 0

[<EntryPoint>]
let main argv =
   //Дан целочисленный массив и интервал a..b. Необходимо найти сумму элементов, значение которых попадает в этот интервал
    let n = Console.ReadLine() |> Int32.Parse
    let a = Console.ReadLine() |> Int32.Parse
    let b = Console.ReadLine() |> Int32.Parse
    Console.WriteLine (sigmaInterval (readList n) a b)
    0 // return an integer exit code
