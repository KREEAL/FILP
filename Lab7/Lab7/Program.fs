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

[<EntryPoint>]
let main argv =
    
   (* 1.3 Дан целочисленный массив и натуральный индекс (число, меньшее
    размера массива). Необходимо определить является ли элемент по
    указанному индексу глобальным максимумом.*)
    let list = readData
    let index = Convert.ToInt32(Console.ReadLine())
    let maxEl = List.max list
    let indexedEl = List.item index list 
    if maxEl = indexedEl then Console.WriteLine "Является"
    else Console.WriteLine "Не является"
    printfn "Hello World from F#!"
    0 // return an integer exit code
