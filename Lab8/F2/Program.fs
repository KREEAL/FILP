// Learn more about F# at http://fsharp.org

open System

type Maybe<'a> =
    | Just of 'a
    | Nothing 

//функтор 
let fmapMaybe f p =
    match p with
    | Just a -> Just (f a)
    | Nothing -> Nothing

//Аппликативный функтор
let applyMaybe lf p =
    match lf, p with
    |Just f, Just a -> Just (f a)
    |_-> Nothing   

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
