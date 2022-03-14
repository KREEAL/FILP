// Learn more about F# at http://fsharp.org

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

let f5 list = List.length (List.filter (fun x -> (List.exists (fun el -> el * el = x) list)) list)

[<EntryPoint>]
let main argv =
    (*1.33
    Дан целочисленный массив. Проверить, чередуются ли в нем
    положительные и отрицательные числа.*)

    let list = readData
    List.exactlyOne
    List.groupBy
    List.pairwise
    List.scan
    let even = list.[0]
    printfn "Hello World from F#!"
    0 // return an integer exit code
