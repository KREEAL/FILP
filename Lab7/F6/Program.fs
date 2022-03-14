// Learn more about F# at http://fsharp.org

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToDouble(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : double)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail


let averagedList (list : 'double list) = 
    let average = List.average list
    let maxEl = list |> List.max
    let newList = List.filter (fun x-> x > average && x<maxEl) list
    newList

[<EntryPoint>]
let main argv =
    (*1.53. Для введенного списка построить новый с элементами, большими, чем
    среднее арифметическое списка, но меньшими, чем его максимальное
    значение.*)
    let list = readData
    writeList(averagedList list)
    printfn "Hello World from F#!"
    0 // return an integer exit code
