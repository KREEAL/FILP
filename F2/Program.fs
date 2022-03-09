// Learn more about F# at http://fsharp.org

open System

let ask s =
    if (s = "F#" || s = "Prolog") then "Ты подлиза!"
    else 
        let s1 = s + " прекрасный язык))"
        s1
        

[<EntryPoint>]
let main argv =
    let lowS (s:String) = s.ToLower()
    let answer_s s = 
        match s with
        |"F#"|"Prolog"->"Подлиза"
        |_->"прекрасный язык"

    //каррирование
    Console.WriteLine("Какой у тебя любимый язык программирования?");
    (Console.ReadLine>> lowS >> answer_s>> Console.WriteLine)()

    //суперпозиция
    Console.WriteLine("Какой у тебя любимый язык программирования?");
    let user input (output:string->unit) chooser = output (chooser (input ()))
    user Console.ReadLine Console.WriteLine answer_s

    //конвеер
    Console.WriteLine("Какой у тебя любимый язык программирования?");
    Console.ReadLine()|> ask |> Console.WriteLine
    Console.ReadKey();


    0 // return an integer exit code
