// Learn more about F# at http://fsharp.org

open System

let rec readStrings n strings=
    match n with 
    |0 -> strings
    |_ -> 
        let s = Console.ReadLine()
        let newStrings = strings @ [s]
        let n1 = n - 1
        readStrings n1 newStrings

let rec writeStringList = function
    |[] -> let z = System.Console.ReadKey()
           0
    | (head : string)::tail -> 
                      System.Console.WriteLine(head)
                      writeStringList tail

let rec writeDoubleList = function
    |[] -> let z = System.Console.ReadKey()
           0
    | (head : double)::tail -> 
                      System.Console.WriteLine(head)
                      writeDoubleList tail


let stringFreqList string = 
    let ss = String.length string
    let afreq = String.length (String.filter (fun x -> x = 'a')  string) /ss
    let bfreq = String.length (String.filter (fun x -> x = 'b')  string) /ss
    let cfreq = String.length (String.filter (fun x -> x = 'c')  string) /ss
    let dfreq = String.length (String.filter (fun x -> x = 'd')  string) /ss
    let efreq = String.length (String.filter (fun x -> x = 'e')  string) /ss
    let (newAplhabet:'double list) = [Convert.ToDouble(afreq);Convert.ToDouble bfreq;Convert.ToDouble cfreq; Convert.ToDouble dfreq; Convert.ToDouble efreq]
    newAplhabet

[<EntryPoint>]
let main argv =
    let alphabetFrequency = [('a',0.1);('b',0.38);('c',0.21);('d',0.19);('e',0.12)]
    let strings = readStrings 2 []
    let firstString = strings.Head
    Console.Write firstString
    let (freqlist:'double list) = stringFreqList firstString
    writeDoubleList freqlist
    writeStringList strings
    //let (s:string) = "Hello"
    //let newS = String.filter (fun x -> x <> ' ')
    //list strings
    //list frequencies
    printfn "Hello World from F#!"
    0 // return an integer exit code
