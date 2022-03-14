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

let countMin list = 
    let minEl = List.min list
    let result = List.length (List.filter (fun x -> x = minEl) list)
    result


[<EntryPoint>]
let main argv =
    (*1.43
    Дан целочисленный массив. Необходимо найти количество
    минимальных элементов.*)
    let list = readData
    Console.WriteLine(countMin list)
    printfn "Hello World from F#!"
    0 // return an integer exit code
