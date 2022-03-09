// Learn more about F# at http://fsharp.org

open System

let derivatives n predicate init =
    let rec f_inside x func init divider =
        if divider = 1 then init
        else
            let newInit = 
                if x % divider = 0 then 
                    func init divider 
                else init
            let newDivider = divider - 1
            f_inside x func newInit newDivider
    f_inside n predicate init (n/2)

let isEasy x y =
    let rec isEasy_inside x y curC curDer =
        if curDer = 1 then
            if curC = 0 then 1
            else 0
        else
            let newCur = 
                if (x % curDer = 0) && (y % curDer = 0) then
                    curC + 1
                else curC
            let newDer = curDer - 1
            isEasy_inside x y newCur newDer
    isEasy_inside x y 0 y

let bothEasied n predicate init =
    let rec f_inside x func init divider =
        if divider = 1 then init
        else
            let newInit = 
                if isEasy x divider = 1 then
    
                    func init divider 
                else init
            let newDivider = divider - 1
            f_inside x func newInit newDivider
    f_inside n predicate init n

[<EntryPoint>]
let main argv =
    Console.WriteLine(derivatives 10 (fun x y -> if x > y then x else y) 1)
    Console.WriteLine(bothEasied 30 (fun x y -> if x > y then x else y) 1)
    0 // return an integer exit code
