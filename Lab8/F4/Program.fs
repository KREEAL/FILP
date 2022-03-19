// Learn more about F# at http://fsharp.org

open System
//Операторы async, let! И return! используются для асинхронного программирования. Но оно не рассмотрено в курсе :(

//актор. Меилбокспроцессор - встроенный класс. Агент не может пропускать через себя букву 'a', поэтому удаляет их из сообщения
let printerAgenWithNoA = MailboxProcessor.Start(fun inbox->
    // обработка сообщений
    let rec messageLoop() = async{
        // чтение сообщения
        let! msg = inbox.Receive()
        // печать сообщения
        if String.exists (fun x-> x=' ') msg then  Console.WriteLine ("Допускаются сообщения без буквы 'a'. Вот, осталось только это: " + String.filter (fun x->x<>'a')  msg)
        else Console.WriteLine("Спасибо, что ввел строку без 'a', вот твое сообщнеи" + msg)
        return! messageLoop()
        }
        // запуск обработки сообщений
    messageLoop()

    )
[<EntryPoint>]
let main argv =
    let arg1 = printerAgenWithNoA.Post("Как вкусно, ммм. Всю тарелку каши съел")
    let arg2 = printerAgenWithNoA.Post("СИИИИИ, пять по ФИЛП у меня!")
    Console.WriteLine("{0}, {1} a",arg1,arg2)
    0 // return an integer exit code
