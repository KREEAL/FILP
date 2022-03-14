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

[<EntryPoint>]
let main argv =
    (*1.13 Дан целочисленный массив. Необходимо разместить элементы,
    расположенные до минимального, в конце массива.*)
    let list = readData
    let min = List.min list
    let isGreaterThan x y = y > x
    let minIdex = List.findIndex (fun x -> x = min) list// индекс первого вхождения min
     
    let indexedList = List.indexed list
    let firstGroup = list.[0..(minIdex - 1)]
    let lastGroup = list.[minIdex..List.length list]
    writeList((lastGroup@firstGroup))

    0 // return an integer exit code
