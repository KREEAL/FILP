// Learn more about F# at http://fsharp.org

open System

let max2 x y = if x > y then x else y

let rec readList n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToInt32
    let Tail = readList (n-1)
    Head::Tail


let rec getByIndex list i =
    match list with 
    |[]-> -1
    |h::t ->
            if i = 0  then h
            else
                getByIndex t (i-1)


let rec listElements list (f : int -> int -> int) p acc = 
    match list with
    | [] -> acc
    | head::tail ->
                let newAcc = f acc head
                if p head then listElements tail f p newAcc
                else listElements tail f p acc

let listMax list = 
    match list with 
    |[] -> 0
    | h::t -> listElements list max2 (fun x -> true) h

let isIndexedElMax list index =
    if listMax list = getByIndex list index then true
    else false

[<EntryPoint>]
let main argv =
    // 1.3  Является ли элемент по заданному индексу глобальным максимумом?
    let n = Console.ReadLine() |> Int32.Parse
    let index = Console.ReadLine() |> Int32.Parse
    let list = readList n

    let result = isIndexedElMax list index
    match result with
    |true ->Console.WriteLine "Является"
    |false ->Console.WriteLine "Не является"
       
    0 // return an integer exit code
