// Learn more about F# at http://fsharp.org

open System

let rec readList n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToInt32
    let Tail = readList (n-1)
    Head::Tail


let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

let rec getByIndex list i =
    match list with 
    |[]-> -1
    |h::t ->
            if i = 0  then h
            else
                getByIndex t (i-1)

[<EntryPoint>]
let main argv =
    
    

    Console.Write(getByIndex (readList 5) 3 )
    0 // return an integer exit code
