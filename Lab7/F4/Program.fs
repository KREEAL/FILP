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

(*let isNegativeAlternation (list : 'int list) = 
    let funcList = list
    let pairsForList = list.[1..List.length funcList]
    let commonList = list.[0..(List.length funcList - 2)]
    let mappedList = List.map2 (fun x y -> if x * y < 0 then -1 else 1) commonList pairsForList
    let res = List.length(List.filter(fun x -> x = 1) mappedList)
    if res > 0 then false else true*)

let pairsProcess (list : 'int list) f = 
    let funcList = list
    let pairsForList = list.[1..List.length funcList]
    let commonList = list.[0..(List.length funcList - 2)]
    let mappedList = List.map2 f commonList pairsForList
    let res = List.length(List.filter(fun x -> x = 1) mappedList)
    if res > 0 then false else true

[<EntryPoint>]
let main argv =
    (*1.33
    Дан целочисленный массив. Проверить, чередуются ли в нем
    положительные и отрицательные числа.*)
     
    let list = readData
    if pairsProcess list (fun x y -> if x * y < 0 then -1 else 1)  then Console.WriteLine("Чередуются")
    else Console.WriteLine("Не чередуются")
    
    0 // return an integer exit code
