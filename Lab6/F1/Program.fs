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
//обертка
let triplet list (f : int -> int -> int -> int) =
    //внутренняя функция. Храним предыдущие значения с голов
    let rec triplet_inside list (f : int -> int -> int -> int) last1 last2 last3 count resList = 
        match list with
        | [] ->  //пустой, но есть ли скопленные элементы?
               if count = 1|| count = 2 then 
                   let newResList = resList @ [f last1 last2 last3]
                   newResList
               else resList
        | h::t ->
                    match count with
                    |0->   //добавили первый 
                        let newLast3 = h
                        let newCount = count + 1 
                        triplet_inside t f last1 last2 newLast3 newCount resList
                    |1->    //добавили второй
                        let newLast2 = last3
                        let newLast3 = h
                        let newCount = count + 1
                        triplet_inside t f last1 newLast2 newLast3 newCount resList
                    |2->     //съели все и обнулились
                        let nowRes = resList @ [f last2 last3 h] 
                        triplet_inside t f 1 1 1 0 nowRes
        
    triplet_inside list f 1 1 1 0 []
    
    //a::t
    //a::b::t
    //a::b::c::d
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine()|>Int32.Parse
    let list = readList n
    Console.WriteLine()
    writeList(triplet list (fun x y z-> x+y+z))

    

