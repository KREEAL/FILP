// Learn more about F# at http://fsharp.org

open System

let readRussianArray n =
    let rec readArray_inside n arr = 
        if n = 0 then arr
        else
        let tail = System.Console.ReadLine()
        let newArr = Array.append arr [|tail|]
        let n1 = n - 1
        readArray_inside n1 newArr
    readArray_inside n Array.empty

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : string)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

//let readString =
   // Console.ReadLine()



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


(*let split (s:string) (list:'string list) = 
    let newWord = s.Split [|' '|]
    newWord*)

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

let rec accCond list (f : string -> int -> int) p acc = 
    match list with
    | [] -> acc
    | h::t ->
                let newAcc = f h acc
                if p h then accCond t f p newAcc
                else accCond t f p acc

let evenWordsCount (s:string) = 
    let res = accCond (split s) (fun x y-> if (x.Length % 2 = 0) then y + 1 else y ) (fun x-> true) 0
    res

let russianArray (arr:string array) = 
    let newAr = Array.sortBy (fun (x:string) -> x.[1]) arr
    newAr

let defaultFunc s = 
    Console.Write("Прости, но нет такой возможности");

let chosedQuestion ask s =
    match ask with
    |1 -> permuteWords s
    |2 -> evenWordsCount s
    |3 -> russianArray s
    |_ ->defaultFunc s

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
    (*let input = (Console.ReadLine(),Console.ReadLine()|>Convert.ToInt32)
    let output = chosedQuestion(fst input)(snd input) //каррирование
    Console.WriteLine("Результат применения к функции {1} строки {0}",fst input,output)   *)

    let almostRussian = readRussianArray 3
    //printfn "%A" (russianArray arr)
    0 // return an integer exit code
