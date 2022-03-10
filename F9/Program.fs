
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

    //максимальный простой делитель
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


    //произведение цифр не делящихся на 5
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


    //произведение цифр
let digitsApply n =
    if n = 0 then 0
    else
        let rec digitsA_inside n res =
            if n = 0 then res
            else
                let cifr = n%10
                let n1 = n/10
                let acc = res*cifr
                digitsA_inside n1 acc
        digitsA_inside n 1
        
// НОД по Евклиду
let rec GCD_Euqlid x y =
    if ((x = 0 ) || (y = 0)) then
        (x + y)
    else
        if x > y then GCD_Euqlid (x % y) y
        else GCD_Euqlid x (y % x)

//максимальный не простой нечетный делитель
let maxNotEasyOddDivider n =
    let rec maxED_inside n maxD counter =
        if counter = 0 then 0
        else 
        if counter = 1 then maxD
        else
            let newMax =
                if (isEasy counter = 0) && (n % counter = 0) && (counter > maxD) && (counter % 2<>0) then
                    counter
                else maxD
            let newCounter = counter - 1
            maxED_inside n newMax newCounter
    maxED_inside n 1 n

//...
let GCD_maxNEOD_DigApp n =
    GCD_Euqlid (maxNotEasyOddDivider n) (digitsApply n)



[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число: ")
    let n = Convert.ToInt32(Console.ReadLine())

    Console.WriteLine("Максимальный простой делитель: {0} ",(maxEasyDivider n))
    Console.WriteLine("Произведение цифр числа не делящихся на 5: {0} ",(notDivisibleBy5DigitsApp n))
    Console.WriteLine("НОД произведен... Метод 3: {0} ",(GCD_maxNEOD_DigApp n))
    
    0 // return an integer exit code
