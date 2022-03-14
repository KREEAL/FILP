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
    (*1.23
    Дан целочисленный массив. Необходимо найти два наименьших
    элемента.*)
    let list = readData
    let min1 = List.min list
    let listWithout = List.filter (fun x -> x <> min1) list
    let min2 = if List.isEmpty listWithout then min1 else List.min listWithout
    Console.WriteLine("{0} {1}",min1,min2)
    0 // return an integer exit code
