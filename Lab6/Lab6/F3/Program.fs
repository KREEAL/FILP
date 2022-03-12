// Learn more about F# at http://fsharp.org

open System

let rec readList n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToInt32
    let Tail = readList (n-1)
    Head::Tail
let rec frequency list elem count =
    match list with
    |[] -> count
    | h::t -> 
                    let count1 = count + 1
                    if h = elem then frequency t elem count1 
                    else frequency t elem count
let findImposter list =     
    let rec find list common = 
        match list with 
        |[]->0
        |h::t ->
            if frequency common h 0 = 1 then h
            else find t common
    find list list

[<EntryPoint>]
let main argv =
    //1.11 Дан массив, в котором один элемент отличен от остальных. Найти его
    findImposter(readList 5) |> Console.Write
    0 // return an integer exit code
