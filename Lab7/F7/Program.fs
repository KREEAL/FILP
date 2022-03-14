// Learn more about F# at http://fsharp.org

open System

let rec GCD x y = 
    if x = 0 || y = 0 then x + y
    else if x > y then GCD (x % y) y else GCD x (y % x)


let magicFunction n =
    let l1 = [1..n]
    let l2 = [1..n]
    let pairs = List.allPairs l1 l2
    let XYN = List.filter (fun x -> fst x * snd x = n  ) pairs //x*y=N
    let NewN = [1..List.length XYN]
    let Zeros = List.map2 (fun x y -> x - y) NewN NewN 
    let Nod = List.map2 (fun x y -> GCD(fst x)(snd x) + y) XYN Zeros//список НОД
    let ResultAB = List.map2(fun x y ->((fst x)/y),((snd x)/y)  )XYN Nod
    ResultAB

[<EntryPoint>]
let main argv =
    (*3 Для введенного числа N построить список неповторяющихся кортежей
    (a,b), таких, что существует пара (x,y): X*Y=N, НОД(X,Y)=d, a=X/d, b=Y/d .*)
    let n = Console.ReadLine() |> Int32.Parse
    Console.Write (magicFunction n)
    printfn "Hello World from F#!"
    0 // return an integer exit code
