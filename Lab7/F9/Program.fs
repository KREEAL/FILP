// Learn more about F# at http://fsharp.org

open System

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : string)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

let readString =
    Console.ReadLine()


//поиск ближайшего пробела
let findSpaceIndex s =
    let rec findSpaceIndex_inside s ind symbol= 
        match s with
        |""|" " -> ind + 1 
        |_->
            match symbol with
            |' ' -> ind
            |_ ->
                let newInd = ind + 1
                let newSymbol = s.[0]
                let newS = s.[1..String.length s]
                findSpaceIndex_inside newS newInd newSymbol
    findSpaceIndex_inside s 0 'a'

//разбиение строки на слова
let split (s:string) =
    let rec cutWords (s:string) (words : 'string list) = 
        match s with
        |""-> words
        |_->
            let newWord = s.[0..(findSpaceIndex s-2)]
            let newS = s.[(findSpaceIndex s) .. String.length s]
            cutWords newS (words@[newWord])
    cutWords s []

//Перемешивание листа по длине слов
let permute s =
    let newS = split s
    let permutedS = List.permute (fun x -> (x + 1) % List.length newS ) newS
    permutedS

//сборка списка слов в строчку
let listToString (list: 'string list)=
    let rec listToString list (str:string) =
        match list with
        |[]-> 
            let newS = str.[1..(String.length str - 1)]//удаляем лишний пробел
            newS
        |h::t->
            let newS = str + " " + h
            listToString t newS
    listToString list ""

let permuteWords str =
    listToString(permute str)
//
(*
let chosedQuestion ask =
    match ask with
    |1 -> permuteWords
    |2 ->
    |3 ->
    |_ ->*)

[<EntryPoint>]
let main argv =
    (*3 Дана строка в которой слова записаны через пробел. Необходимо
    перемешать все слова этой строки в случайном порядке.*)
    (*8
    Дана строка в которой записаны слова через пробел. Необходимо
    посчитать количество слов с четным количеством символов.*)
    (*16
    Дан массив в котором находятся строки "белый", "синий" и
    "красный" в случайном порядке. Необходимо упорядочить массив так,
    чтобы получился российский флаг.*)

    let s = readString
    writeList (split s)
    Console.WriteLine(permuteWords s)

    printfn "Hello World from F#!"
    0 // return an integer exit code
