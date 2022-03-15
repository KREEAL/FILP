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





//возвращает список кортежей буква-частота для данной строки
let freqList (s:string) = 
    let charlist = Seq.toList (s.ToLower())//строка в список чаров
    let freq = List.countBy id charlist // разбивает на кортеж (буква.кол-во)('а',3)
    let length = (String.length (String.filter (fun x-> x <> ' ') s)) //без учета пробелов работаем
    //let length = (String.length s) //с учетом пробелов
    let newMapList = [0..List.length freq]
    let symbolFreak = List.map (fun (x:char,x1:int)  -> (x , (Convert.ToDouble x1 ) / (Convert.ToDouble length)) )freq
    symbolFreak

//разность между букавами и алфавитом
let alphabetFrequencyDifference (frequedCharList: (string * ((char * float) list))) (alphabet:(char*float) list) =
    let five = 5
    let difference = snd (List.maxBy (fun x-> snd x) (snd frequedCharList)) - snd (List.find (fun x -> (fst x) = (fst (List.maxBy (fun x-> snd x) (snd frequedCharList)))) alphabet)
    difference
    //let difference = (List.find (fst (List.maxBy (fun x-> (snd x) frequedCharList)) alphabet) - (snd (List.maxBy (fun x ->(snd x)) frequedCharList))
    //difference
    

let firstTask strings =
    let frequencyList = List.map (fun x -> freqList(x)) strings

    let bigString = String.concat ("":string) (strings)//объединение всех строк - найдем частоту алфавита отсюда
    let bigStringNoSpace = String.filter( fun x -> x <> ' ') bigString
    let alphabet = freqList bigStringNoSpace //   
    let listStringPlusSymbolChastotaCortej = List.map2(fun x y -> (x,y)) strings frequencyList // совмещенное строка и "массив" символ-частота
    let SortedStrings = List.sortBy (fun x -> (alphabetFrequencyDifference x alphabet) ) listStringPlusSymbolChastotaCortej
    writeStringList (List.map (fun x-> fst x )SortedStrings)

//let difference string frequency alphabet =
  //  0

    
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
    
    (*let n = Console.ReadLine() |> Int32.Parse
    let strings = readStrings n []
    let frequencyList = List.map (fun x -> freqList(x)) strings

    //writeFrequencedList frequencyList

    let bigString = String.concat ("":string) (strings)//объединение всех строк - найдем частоту алфавита отсюда
    let bigStringNoSpace = String.filter( fun x -> x <> ' ') bigString
    let alphabet = freqList bigStringNoSpace //
    //writePairs alphabet

    let listStringPlusSymbolChastotaCortej = List.map2(fun x y -> (x,y)) strings frequencyList // совмещенное строка и "массив" символ-частота
    let SortedStrings = List.sortBy (fun x -> (alphabetFrequencyDifference x alphabet) ) listStringPlusSymbolChastotaCortej

    writeStringList (List.map (fun x-> fst x )SortedStrings)*)
    //(string * ((char * float) list))
    //let sortedStrings = List.sortBy (fun x -> (difference x alphabet)) strings 

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