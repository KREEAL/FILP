// Learn more about F# at http://fsharp.org

open System

let rec readList n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToInt32
    let Tail = readList (n-1)
    Head::Tail

let listSize list =
    let rec listSize_inside list res = 
        match list with
        |[]-> res
        |h::t ->
            let newRes = res + 1
            listSize_inside t newRes 
    listSize_inside list 0


let rec getByIndex list i =
    match list with 
    |[]-> -1
    |h::t ->
            if i = 0  then h
            else
                getByIndex t (i-1)


let isLocalMax list i =
    if listSize list = 1 then true
    else
    let lastInd = (listSize list - 1)
    match i with
    |0 ->
        if getByIndex list i > getByIndex list (i + 1) then true
        else false
    |lastInd -> 
        if getByIndex list i > getByIndex list (i - 1) then true
        else false
    |_ -> 
        if getByIndex list i > getByIndex list (i + 1) && getByIndex list i > getByIndex list (i + 1) then true else false


[<EntryPoint>]
let main argv =
    //Является ли элемент по указанному индексу локальным минимумом?
    let n = Console.ReadLine() |> Convert.ToInt32
    let index = Console.ReadLine() |> Convert.ToInt32
    let list = readList n
    Console.WriteLine (isLocalMax list index)
    0 // return an integer exit code
