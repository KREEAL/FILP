// Learn more about F# at http://fsharp.org

open System

let rec GCD x y = 
    if x = 0 || y = 0 then x + y
    else if x > y then GCD (x % y) y else GCD x (y % x)

let rec writePairs list =
    match list with
    |[] -> 0
    |_->
        Console.WriteLine("({0},{1})",fst list.Head,snd list.Head)
        writePairs list.Tail

let magicFunction n =
    //let l1 = [1..n]
    //let l2 = [1..n]
    //let pairs = List.allPairs l1 l2
    //let XYN = List.filter (fun x -> fst x * snd x = n  ) (List.allPairs l1 l2) //x*y=N
    //let NewN = [1..List.length XYN]
    //let Zeros = List.map2 (fun x y -> x - y) [1..List.length XYN] [1..List.length XYN]
    //let Nod = List.map2 (fun x y -> GCD(fst x)(snd x) + y) XYN (List.map2 (fun x y -> x - y) [1..List.length XYN] [1..List.length XYN])//список НОД
    let ResultAB = List.map2(fun x y ->((fst x)/y),((snd x)/y))(List.filter (fun x -> fst x * snd x = n  ) (List.allPairs [1..n] [1..n])) (List.map2 (fun x y -> GCD(fst x)(snd x) + y) (List.filter (fun x -> fst x * snd x = n  ) (List.allPairs [1..n] [1..n])) (List.map2 (fun x y -> x - y) [1..List.length (List.filter (fun x -> fst x * snd x = n  ) (List.allPairs [1..n] [1..n]))] [1..List.length (List.filter (fun x -> fst x * snd x = n  ) (List.allPairs [1..n] [1..n]))]))
    ResultAB

[<EntryPoint>]
let main argv =
    (*3 Для введенного числа N построить список неповторяющихся кортежей
    (a,b), таких, что существует пара (x,y): X*Y=N, НОД(X,Y)=d, a=X/d, b=Y/d .*)
    let n = Console.ReadLine() |> Int32.Parse
    writePairs (magicFunction n)
    printfn "Hello World from F#!"
    0 // return an integer exit code
