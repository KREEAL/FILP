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

let filter list pr = 
    let rec filter1 list pr newList = 
        match list with
        | [] -> newList
        | h::t ->
                let newnewList = newList @ [h]
                if pr h then filter1 t pr newnewList
                else filter1 t pr newList
    filter1 list pr [] 

let delEL list el = filter list (fun x -> (x <> el))

let uniqueList list = 
    let rec uniqueList_inside list newList = 
        match list with
            |[] -> newList
            | h::t -> 
                        let listWithout = delEL t h
                        let newnewList = newList @ [h]
                        uniqueList_inside listWithout newnewList
    uniqueList_inside list [] 


let rec frequency list elem count =
        match list with
        |[] -> count
        | h::t -> 
                        let count1 = count + 1
                        if h = elem then frequency t elem count1 
                        else frequency t elem count

let frequencyList list = 
    let rec frequencyList_inside list mainList curList = 
            match list with
            | [] -> curList
            | h::t -> 
                        let freqElem = frequency mainList h 0
                        let newList = curList @ [freqElem]
                        frequencyList_inside t mainList newList
    frequencyList_inside list list []

[<EntryPoint>]
let main argv =
    (*1.51. Для введенного списка построить два списка L1 и L2, где элементы L1
    это неповторяющиеся элементы исходного списка, а элемент списка L2 с
    номером i показывает, сколько раз элемент списка L1 с таким номером
    повторяется в исходном.*)
    Console.WriteLine "Введите кол-во элементов"
    let n = Console.ReadLine()|>Int32.Parse
    Console.WriteLine "Введите элементы"
    let list = readList n
    Console.WriteLine "Уникальные элементы"
    writeList (uniqueList list)
    Console.WriteLine "Уникальные элементы"
    writeList (frequencyList list)
    0 // return an integer exit code
