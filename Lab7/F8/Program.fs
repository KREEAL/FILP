// Learn more about F# at http://fsharp.org

open System

let readArray n =
    let rec readArray_inside n arr = 
        if n=0 then arr
        else
        let tail = System.Convert.ToInt32(System.Console.ReadLine())
        let newArr = Array.append arr [|tail|]
        let n1 = n - 1
        readArray_inside n1 newArr
    readArray_inside n Array.empty

let writeArray arr =
    printfn "%A" arr

let concatArrays arr1 arr2 = 
    let newArray = Array.append arr1 arr2
    newArray

[<EntryPoint>]
let main argv =
    (*3 Объединить два произвольных массива в один.*)
    let n1 = Console.ReadLine() |>Int32.Parse
    let firstArray = readArray  n1
    let n2 = Console.ReadLine() |> Int32.Parse
    let secondArray = readArray n2

    let concatedArray = concatArrays firstArray secondArray
    writeArray concatedArray
    0 // return an integer exit code
