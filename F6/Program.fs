// Learn more about F# at http://fsharp.org

open System
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

let Euler n= 
    let rec euler_inside n y count =
        if y = 0 then count
        else
            let newCount =
                if isEasy n y = 1 then 
                    count + 1
                else count
            let newY = y - 1
            euler_inside n newY newCount

    euler_inside n (n-1) 0

let GCD x y =
    let rec gcd_inside x y curDer maxDer =
        if curDer = 0 then maxDer
        else
            let newMax = 
                if (x % curDer =0)&&(y % curDer = 0) && curDer>maxDer then 
                curDer
                else maxDer
            let newDer = curDer - 1
            gcd_inside (max x y) (min x y) newDer newMax

    gcd_inside (max x y) (min x y) (min x y) -1

[<EntryPoint>]
let main argv =
    Console.WriteLine(Euler 12)//(12) = 1 5 7 11 (4) 
    Console.WriteLine(Euler 30)//(30) = 1 7 11 13 17 19 23 29 (8)
    Console.WriteLine(GCD 60 50)// 10
    Console.WriteLine(GCD 45 60)// 15
    0 // return an integer exit code
