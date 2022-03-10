// Learn more about F# at http://fsharp.org

open System

//простое или нет
let isEasy n =
    let rec isEasy_inside n cur=
        if cur = 0 then 0
        else 
        if cur = 1 then 1
        else
            if n % cur = 0 then 0
            else 
                let newCur = cur - 1
                isEasy_inside n newCur
    isEasy_inside n (n-1)


let maxEasyDivider n =
    let rec maxED_inside n maxD counter =
        if counter = 0 then 0
        else 
        if counter = 1 then maxD
        else
            let newMax =
                if (isEasy counter = 1) && (n % counter = 0) && (counter > maxD) then
                    counter
                else maxD
            let newCounter = counter - 1
            maxED_inside n newMax newCounter
    maxED_inside n 1 n

[<EntryPoint>]
let main argv =
    maxEasyDivider 20 |>Console.Write
    maxEasyDivider 19 |>Console.Write
    0 // return an integer exit code
