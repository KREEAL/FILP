// Learn more about F# at http://fsharp.org

open System

let ask s =
    if (s = "F#" || s = "Prolog") then "Ты подлиза!"
    else 
        let s1 = s + " прекрасный язык))"
        s1
        

[<EntryPoint>]
let main argv =
    Console.WriteLine("Какой у тебя любимый язык программирования?");
    Console.ReadLine()|> ask |> Console.WriteLine
    Console.ReadKey();

    Console.WriteLine("Какой у тебя любимый язык программирования?");
    let s = Console.ReadLine();
    Console.WriteLine (ask s)
    Console.ReadKey();
    0 // return an integer exit code
