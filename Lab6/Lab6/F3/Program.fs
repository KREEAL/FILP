// Learn more about F# at http://fsharp.org

open System

let rec readList n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToInt32
    let Tail = readList (n-1)
    Head::Tail

[<EntryPoint>]
let main argv =
    //1.11 Дан массив, в котором один элемент отличен от остальных. Найти его
    printfn "Hello World from F#!"
    0 // return an integer exit code
