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

let isEven n = ((n % 2) = 0)

let evenOdd list = 
    let rec evenOdd_inside list even odd index =
        match list with
        |[] -> (even @ odd)
        |h::t ->
                let newIndex = index + 1
                if isEven index then evenOdd_inside t (even @ [h]) odd newIndex
                else evenOdd_inside t even (odd @ [h]) newIndex
    evenOdd_inside list [] [] 0

[<EntryPoint>]
let main argv =
    //вывести сначала элементы с четными индексами, затем с нечетными индексами
    let n = Console.ReadLine() |> Int32.Parse
    writeList (evenOdd (readList n))
    // return an integer exit code
