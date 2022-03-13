// Learn more about F# at http://fsharp.org

open System

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

let rec readList n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToInt32
    let Tail = readList (n-1)
    Head::Tail


let moveLeft list =
    let rec moveLeft_inside list head count =
        if count > 0 then
            list @ [head]
        else
        match list with
        |[] -> list //никогда не будет обработано
        |h::t ->
            let newCount = count + 1
            moveLeft_inside t h newCount 
    moveLeft_inside list 0 0

[<EntryPoint>]
let main argv =
    //циклический сдвиг влево 
    let n = Console.ReadLine() |> Convert.ToInt32
    let list = readList n
    writeList (moveLeft list)
     // return an integer exit code
        