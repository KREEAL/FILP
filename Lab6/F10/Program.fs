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

let moveLeft list n =
    let rec moveLeft_inside list count =
        if count >= n then
            list
        else
        match list with
        |[] -> list //никогда не будет обработано
        |h::t ->
            let newCount = count + 1
            let newTail = t @ [h]
            moveLeft_inside newTail newCount 
    moveLeft_inside list 0

let rec accCond list (f : int -> int -> int) p acc = 
    match list with
    | [] -> acc
    | h::t ->
                let newAcc = f acc h
                if p h then accCond t f p newAcc
                else accCond t f p acc

let listMin list = 
    match list with 
    |[] -> 0
    | h::t -> accCond list (fun x y -> if x < y then x else y) (fun x -> true) h

let pos list el = 
    let rec pos1 list el num = 
        match list with
            |[] -> 0
            |h::t ->    if (h = el) then num
                        else 
                            let num1 = num + 1
                            pos1 t el num1
    pos1 list el 1

let moveBefoMinToTail list =
    moveLeft list ((pos list (listMin list)) - 1) //поиск минимума, его позиция, -1, сдвиг на это значение




[<EntryPoint>]
let main argv =
    //1.13 все элементы до глобального максимума переместить в конец списка
    let n = Convert.ToInt32(Console.ReadLine())
    let list = readList n
    writeList (moveBefoMinToTail list)
    printfn "Hello World from F#!"
    0 // return an integer exit code
