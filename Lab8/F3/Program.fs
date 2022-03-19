// Learn more about F# at http://fsharp.org

open System
open FParsec


//алгебраический тип. Варианты - дискриминаторы
type Expr =
    | Num of float
    | Plus of Expr * Expr
    | Minus of Expr * Expr

//чтобы не читать пробелы
let pstring_ws s = spaces >>. pstring s .>> spaces
let float_ws = spaces >>. pfloat .>> spaces

//опережающие значения парсера. Implementation - ссылочное значение(ref), изменяется через := 
let parseExpression, implementation = createParserForwardedToRef<Expr, unit>() //выражение, значение - создает парсер to ref
let parsePlus = tuple2 (parseExpression .>> pstring_ws "+") parseExpression |>> Plus // вернуть пару, кинуть в плюс
let parseMinus = tuple2 (parseExpression .>> pstring_ws "-")parseExpression |>> Minus// вернуть пару, кинуть в минус
let parseOp = between (pstring_ws "(") (pstring_ws ")") (attempt parsePlus <|> parseMinus)//attempt - для двух парсеров
let parseNum = float_ws |>> Num //поиск до значения
implementation := parseNum <|> parseOp // изменение значения по ссылке

//Обработка распакованного выражения
let rec EvalExpr(e:Expr):float =
    match e with
    | Num(num) -> num //число
    | Plus(a,b) -> //плюс. два аргумента
        let left = //первый аргумент(левый)
            match a with
            | Num(num) -> num//число 
            | _ -> EvalExpr(a)//или другое выражение
        let right =
            match b with
            | Num(num) -> num 
            | _ -> EvalExpr(b)
        let res1 = left + right //собственно, сумма
        printfn "%f + %f = %f" left right res1 //вывод на экран для простоты контроля
        res1
    | Minus(a,b) -> //минус
        let left =
            match a with
            | Num(num) -> num
            | _ -> EvalExpr(a)
        let right =
            match b with
            | Num(num) -> num
            | _ -> EvalExpr(b)
        let res2 = left - right
        printfn "%f - %f = %f" left right res2
        res2

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите выражение: ")
    let (input:string) = Console.ReadLine()
    let expr1 = run parseExpression input //каждая операция сопровождается скобками. Результат (2+5)-(4+6) вычислен не будет. Но ((2+5)-(4+6)) будет
    Console.WriteLine(expr1)//распаршенное выражение
    match expr1 with
    | Success(result, _, _) ->
        let eval1 = EvalExpr(result)
        printfn "Результат вычислений: %f" eval1
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg
    0 // return an integer exit code
