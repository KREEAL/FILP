// Learn more about F# at http://fsharp.org

open System

let f n predicate init =
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
    
[<EntryPoint>]
let main argv =

    System.Console.WriteLine(f 12 (fun x y -> x + y) 0)

    0 // return an integer exit code
