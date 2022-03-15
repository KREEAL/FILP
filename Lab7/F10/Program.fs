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
let rec writePairs list =
    match list with
    |[] -> 0
    |_->
        Console.Write ("({0},{1}) ",fst list.Head,snd list.Head)
        writePairs list.Tail

let rec writeFrequencedList = function
    |[] -> let z = System.Console.ReadKey()
           0
    | head::tail -> 
                      writePairs head
                      Console.WriteLine " "
                      writeFrequencedList tail

let count x = Seq.filter ((=) x) >> Seq.length



//возвращает список кортежей буква-частота для данной строки
let freqList (s:string) = 
    let charlist = Seq.toList (s.ToLower())//строка в список чаров
    let freq = List.countBy id charlist // разбивает на кортеж (буква.кол-во)('а',3)
    let length = (String.length (String.filter (fun x-> x <> ' ') s)) //без учета пробелов работаем
    //let length = (String.length s) //с учетом пробелов
    let newMapList = [0..List.length freq]
    let symbolFreak = List.map (fun (x:char,x1:int)  -> (x , (Convert.ToDouble x1 ) / (Convert.ToDouble length)) )freq
    symbolFreak

let difference string frequence alphabet = 
   
    
   [<EntryPoint>]
let main argv =
    (*3
    В порядке увеличения разницы между частотой наиболее часто
    встречаемого символа в строке и частотой его появления в алфавите
    4
    В порядке увеличения квадратичного отклонения среднего веса
    ASCII-кода символа строки от среднего веса ASCII-кода символа первой
    строки*)
    (*let alphabetFrequency = [('a',0.1);('b',0.38);('c',0.21);('d',0.19);('e',0.12)])*)
    
    let n = Console.ReadLine() |> Int32.Parse
    let strings = readStrings n []
    let frequencyList = List.map (fun x -> freqList(x)) strings

    //writeFrequencedList frequencyList

    let bigString = String.concat ("":string) (strings)
    let bigStringNoSpace = String.filter( fun x -> x <> ' ') bigString
    let alphabet = freqList bigStringNoSpace
    writePairs alphabet

    List.sortBy ()
    printfn "Hello World from F#!"
    0 // return an integer exit code


(*
5
Привет я
Анатолий Вассерман
Что бы такого сказать
Ууууубью сука
пшел вон
*)