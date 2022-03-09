// Learn more about F# at http://fsharp.org

open System

let rec appUp n =
    if n = 0 then 
        1
    else 
        (n % 10) * appUp(n / 10)

let appDown n=
    let rec appDownRec n pr=
        if n = 0 then pr
        else
            let newpr= pr*(n%10)
            let n1 = n/10
            appDownRec n1 newpr
    appDownRec n 1
    
let rec maxDigitUp n=
    if n < 10 then n
    else max (n%10) (maxDigitUp (n/10))

let maxDigitDown n =
    let rec maxDigDown n max=
        if n=0 then max
        else
            let curCif = n%10
            let n1 = n/10
            if curCif>max then maxDigDown n1 curCif else maxDigDown n1 max
    maxDigDown n 0

let rec minDigitUp n=
    if n < 10 then n
    else min (n%10) (minDigitUp (n/10))
    
let minDigitDown n =
    let rec minDigDown n min=
        if n=0 then min
        else
            let curCif = n%10
            let n1 = n/10
            if curCif<min then minDigDown n1 curCif else minDigDown n1 min
    minDigDown n 9

[<EntryPoint>]
let main argv =
    let x = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Произведение цифр числа")
    Console.WriteLine(appUp x)
    Console.WriteLine(appDown x)
    Console.WriteLine("Максимальная цифра в числе")
    Console.WriteLine(maxDigitUp x)
    Console.WriteLine(maxDigitDown x)
    Console.WriteLine("Минимальная цифра в числе")
    Console.WriteLine(minDigitUp x)
    Console.WriteLine(minDigitDown x)

    0 // return an integer exit code
