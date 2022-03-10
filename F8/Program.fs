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

let notDivisibleBy5DigitsApp n = 
    let rec notDivisibleBy5DigitsApp_inside n res founded= 
        if (n=0) then
            if founded = 0 then 0
            else res
        else 
            let cifr = n % 10
            let n1 = n / 10
            let acc = (fun x y -> if y % 5 = 0 then x else x*y) res cifr
            let newFounded = 
                if cifr % 5 <> 0 then founded + 1
                else founded                
            notDivisibleBy5DigitsApp_inside n1 acc newFounded
    notDivisibleBy5DigitsApp_inside n 1 0

[<EntryPoint>]
let main argv =
    maxEasyDivider 20 |>Console.WriteLine
    maxEasyDivider 19 |>Console.WriteLine
    notDivisibleBy5DigitsApp 12534 |> Console.WriteLine
    notDivisibleBy5DigitsApp 555 |> Console.WriteLine
    notDivisibleBy5DigitsApp 0 |> Console.WriteLine
    0 // return an integer exit code
